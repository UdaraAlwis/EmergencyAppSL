using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Bogus;
using EmergencyAppSL.Models;
using EmergencyAppSL.Services;
using EmergencyAppSL.Views;
using Prism.Navigation;

namespace EmergencyAppSL.ViewModels
{
	public class ReportHistoryPageViewModel : ViewModelBase
	{
        private readonly INavigationService _navigationService;
        private readonly IReportService _reportService;
        private ObservableCollection<SuspiciousReport> _reportHistoryList;
        private SuspiciousReport _selectedReportItem;

        public ObservableCollection<SuspiciousReport> ReportHistoryList
        {
            get => _reportHistoryList;
            set => SetProperty(ref _reportHistoryList, value);
        }

        public SuspiciousReport SelectedReportItem
        {
            get => _selectedReportItem;
            set
            {
                if (_selectedReportItem != value)
                {
                    SetProperty(ref _selectedReportItem, value);
                    if (SelectedReportItem != null)
                        GoToSelectedReportItemCommand.Execute(SelectedReportItem);
                }
            }
        }

        public DelegateCommand<SuspiciousReport> GoToSelectedReportItemCommand { get; private set; }

        public DelegateCommand GoToCreateSuspiciousReportPageCommand { get; private set; }
        
        public ReportHistoryPageViewModel(INavigationService navigationService, IReportService reportService) : base(navigationService)
        {
            _navigationService = navigationService;
            _reportService = reportService;

            GoToSelectedReportItemCommand = new DelegateCommand<SuspiciousReport>((selectedItem) => GoToSelectedReportItem(selectedItem));

            GoToCreateSuspiciousReportPageCommand = new DelegateCommand(() => GoToCreateSuspiciousReportPage());
        }

        private void GoToCreateSuspiciousReportPage()
        {
            _navigationService.NavigateAsync(nameof(CreateSuspiciousReportPage));
        }

        private void GoToSelectedReportItem(SuspiciousReport selectedItem)
        {
            NavigationParameters navParam = new NavigationParameters()
            {
                { nameof(SelectedReportItem), selectedItem }
            };

            _navigationService.NavigateAsync(nameof(ViewSuspiciousReportPage), navParam);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            var reportHistoryList = _reportService.GetReportHistoryList();

            ReportHistoryList = new ObservableCollection<SuspiciousReport>(reportHistoryList);
        }
    }
}
