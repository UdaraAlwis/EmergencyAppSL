using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EmergencyAppSL.Models;
using EmergencyAppSL.Services;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace EmergencyAppSL.ViewModels
{
	public class CreateSuspiciousReportPageViewModel : ViewModelBase
	{
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _pageDialogService;
        private readonly IReportService _reportService;
        private ImageSource _capturedPhoto;

        public ImageSource CapturedPhoto
        {
            get => _capturedPhoto;
            set => SetProperty(ref _capturedPhoto, value);
        }

        public bool IsPhotoAttached => CapturedPhoto != null;

        public DelegateCommand AddPhotoCommand { get; private set; }
        
        public DelegateCommand RemovePhotoCommand { get; private set; }

        public DelegateCommand SubmitReportCommand { get; private set; }

        public CreateSuspiciousReportPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IReportService reportService) : base(navigationService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            _reportService = reportService;

            AddPhotoCommand = new DelegateCommand(() => AddPhoto());

            RemovePhotoCommand = new DelegateCommand(() => RemovePhoto());

            SubmitReportCommand = new DelegateCommand(() => SubmitReport());
        }

        private void SubmitReport()
        {
            _reportService.CreateReport(new SuspiciousReport());
        }

        private async void AddPhoto()
        {
            var response = await _pageDialogService.DisplayActionSheetAsync(
                "Choose action", "Cancel", null, "Photo Library", "Take Photo");

            if (response is null || response.Equals("Cancel"))
                return;
            
            var cameraStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
            var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);

            if (cameraStatus != PermissionStatus.Granted || storageStatus != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Camera, Permission.Storage });
                cameraStatus = results[Permission.Camera];
                storageStatus = results[Permission.Storage];
            }

            if (cameraStatus == PermissionStatus.Granted && storageStatus == PermissionStatus.Granted)
            {
                MediaFile userCapturedPhoto = null;

                userCapturedPhoto = response.Equals("Photo Library")
                    ? await CrossMedia.Current.PickPhotoAsync()
                    : await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions()
                    {
                        Directory = "EmergencyAppSLPhotos",
                        Name = $"EmergencyAppSL_{DateTime.Now.Ticks}.jpg"
                    });

                if (userCapturedPhoto == null)
                    return;
                
                CapturedPhoto = ImageSource.FromStream(() => userCapturedPhoto.GetStream());
            }
            else
            {
                await _pageDialogService.DisplayAlertAsync("Permissions Denied", "Unable to take photos or open gallery.", "OK");
                
                //On iOS you may want to send your user to the settings screen.
                //CrossPermissions.Current.OpenAppSettings();
            }
        }

        private void RemovePhoto()
        {
            CapturedPhoto = null;
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);


        }
    }
}
