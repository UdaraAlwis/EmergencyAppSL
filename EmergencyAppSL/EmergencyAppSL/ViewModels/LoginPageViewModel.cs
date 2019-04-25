using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using EmergencyAppSL.Views;
using Prism.Navigation;

namespace EmergencyAppSL.ViewModels
{
	public class LoginPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public DelegateCommand LoginCommand { get; private set; }

        public LoginPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;

            LoginCommand = new DelegateCommand(() => Login());
        }

        private void Login()
        {
            _navigationService.NavigateAsync(nameof(ReportHistoryPage));
        }
    }
}
