using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using EmergencyAppSL.Views;
using Prism.Navigation;

namespace EmergencyAppSL.ViewModels
{
	public class LandingPageViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;
        public DelegateCommand GoToLoginCommand { get; private set; }

        public DelegateCommand GoToRegisterCommand { get; private set; }

        public LandingPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            GoToLoginCommand = new DelegateCommand(() => GoToLogin());

            GoToRegisterCommand = new DelegateCommand(() => GoToRegister());
        }

        private void GoToRegister()
        {
            _navigationService.NavigateAsync(nameof(LoginPage));
        }

        private void GoToLogin()
        {
            _navigationService.NavigateAsync(nameof(RegistrationPage));
        }
    }
}
