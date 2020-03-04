using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPTest.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ExendedScreen : Page
    {
        internal Rect splashImageRect;
        private SplashScreen splash;
        internal bool dismissed = false;
        internal Frame rootFrame;
        public ExendedScreen(SplashScreen splashScreen, bool loadState)
        {
            this.InitializeComponent();

            Window.Current.SizeChanged += new WindowSizeChangedEventHandler(ExtendedSplash_OnResize);

            splash = splashScreen;
            if(splash != null)
            {
                splash.Dismissed += new TypedEventHandler<SplashScreen, Object>(DismissedEventHandler);
                splashImageRect = splash.ImageLocation;

                PositionImage();

                PositionRing();
                
            }
            rootFrame = new Frame();

            DismissExtendedSplash() ;
        }

        private void PositionImage()
        {
            extendedSplashImage.SetValue(Canvas.LeftProperty, splashImageRect.X);
            extendedSplashImage.SetValue(Canvas.TopProperty, splashImageRect.Y);
            extendedSplashImage.Height = splashImageRect.Height;
            extendedSplashImage.Width = splashImageRect.Width;
        }

        private void DismissedEventHandler(SplashScreen sender, object args)
        {
            dismissed = true;
        }

        private void PositionRing()
        {
            loading.SetValue(Canvas.LeftProperty, splashImageRect.X + (splashImageRect.Width * 0.5) - (loading.Width * 0.5));
            loading.SetValue(Canvas.TopProperty, splashImageRect.Y + splashImageRect.Height + splashImageRect.Height * 0.1);
        }

        private void ExtendedSplash_OnResize(object sender, WindowSizeChangedEventArgs e)
        {
            if(splash != null)
            {
                splashImageRect = splash.ImageLocation;
                PositionImage();
                PositionRing();
            }
        }
        
        async void DismissExtendedSplash()
        {
            await Task.Delay(TimeSpan.FromSeconds(3));

            rootFrame = new Frame();
            MainPage main = new MainPage();
            rootFrame.Content = main;
            Window.Current.Content = rootFrame;
            rootFrame.Navigate(typeof(MainPage));
        }


    }
}
