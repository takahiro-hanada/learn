using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace My
{
    partial class App
    {
        protected override void OnActivated(IActivatedEventArgs args)
        {
            if (!(Window.Current.Content is Frame rootFrame))
            {
                rootFrame = new Frame();

                Window.Current.Content = rootFrame;
            }

            var protocolForResultsArgs = (ProtocolForResultsActivatedEventArgs)args;

            rootFrame.Navigate(typeof(MainPage), protocolForResultsArgs);

            Window.Current.Activate();
        }
    }
}
