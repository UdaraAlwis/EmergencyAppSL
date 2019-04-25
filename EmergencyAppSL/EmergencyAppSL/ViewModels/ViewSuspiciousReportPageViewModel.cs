using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using EmergencyAppSL.Models;
using Prism.Navigation;

namespace EmergencyAppSL.ViewModels
{
	public class ViewSuspiciousReportPageViewModel : ViewModelBase
    {
        private SuspiciousReport _selectedReportItem;

        private readonly INavigationService _navigationService;

        public SuspiciousReport SelectedReportItem
        {
            get => _selectedReportItem;
            set => SetProperty(ref _selectedReportItem, value);
        }

        public ViewSuspiciousReportPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters != null && parameters.ContainsKey(nameof(SelectedReportItem)))
            {
                SelectedReportItem = parameters.GetValue<SuspiciousReport>(nameof(SelectedReportItem));
            }
        }
    }
}
