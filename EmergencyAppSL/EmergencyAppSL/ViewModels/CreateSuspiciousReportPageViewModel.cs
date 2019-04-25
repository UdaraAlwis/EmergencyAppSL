using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using Xamarin.Forms;

namespace EmergencyAppSL.ViewModels
{
	public class CreateSuspiciousReportPageViewModel : ViewModelBase
	{
        private readonly INavigationService _navigationService;

        public ImageSource CapturedImage { get; set; }

        public CreateSuspiciousReportPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
