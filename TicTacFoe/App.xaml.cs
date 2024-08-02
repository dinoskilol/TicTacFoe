using Microsoft.WindowsAppSDK;
using Windows.ApplicationModel.Core;
using Windows.UI.ViewManagement;

namespace TicTacFoe
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        // Change window size and center on Windows
        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = base.CreateWindow(activationState);


            // Change the window size
            window.Width = 500; window.Height = 550;
            window.Title = "TicTacFoe";

            // Center the window
            var displayInfo = DeviceDisplay.Current.MainDisplayInfo;
            window.X = (displayInfo.Width / displayInfo.Density - window.Width) / 2;
            window.Y = (displayInfo.Height / displayInfo.Density - window.Height) / 2;
            return window;
        }
    }
}
