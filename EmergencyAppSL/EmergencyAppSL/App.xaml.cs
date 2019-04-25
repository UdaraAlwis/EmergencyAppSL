using EmergencyAppSL.ViewModels;
using Prism;
using Prism.Ioc;
using System;
using EmergencyAppSL.Services;
using EmergencyAppSL.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace EmergencyAppSL
{
    public partial class App 
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync($"NavigationPage/{nameof(LandingPage)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<RegistrationPage, RegistrationPageViewModel>();
            containerRegistry.RegisterForNavigation<LandingPage, LandingPageViewModel>();
            containerRegistry.RegisterForNavigation<ReportHistoryPage, ReportHistoryPageViewModel>();

            containerRegistry.Register<IReportService, ReportService>();
            containerRegistry.RegisterForNavigation<ViewSuspiciousReportPage, ViewSuspiciousReportPageViewModel>();
        }
    }
}
