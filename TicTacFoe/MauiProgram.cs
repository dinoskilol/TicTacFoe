using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using Microsoft.UI;
using Microsoft.UI.Windowing;


namespace TicTacFoe
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                })         
  .ConfigureLifecycleEvents(events =>

   {


#if WINDOWS

       events.AddWindows(wndLifeCycleBuilder =>

       {

           wndLifeCycleBuilder.OnWindowCreated(window =>

           {

               IntPtr nativeWindowHandle = WinRT.Interop.WindowNative.GetWindowHandle(window);

               WindowId nativeWindowId = Win32Interop.GetWindowIdFromWindow(nativeWindowHandle);

               AppWindow appWindow = AppWindow.GetFromWindowId(nativeWindowId);

               var p = appWindow.Presenter as OverlappedPresenter;

               window.ExtendsContentIntoTitleBar = false;
               p.SetBorderAndTitleBar(false, false);
               p.IsResizable = false;
           });

       });

#endif

   });

            builder.Services.AddMauiBlazorWebView();


#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif


            return builder.Build();
        }
    }
}
