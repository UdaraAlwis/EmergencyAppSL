using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using EmergencyAppSL.Views;
using Prism.Navigation;

namespace EmergencyAppSL.ViewModels
{
	public class RegistrationPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public DelegateCommand RegisterCommand { get; private set; }

        public RegistrationPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;

            RegisterCommand = new DelegateCommand(() => Register());
        }

        private void Register()
        {
            _navigationService.NavigateAsync(nameof(LoginPage));
        }
    }
}
