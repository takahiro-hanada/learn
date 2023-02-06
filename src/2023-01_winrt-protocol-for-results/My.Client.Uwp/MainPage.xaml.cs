using MyProtocolService;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace My
{
    sealed partial class MainPage : Page
    {
        public MainPage() => InitializeComponent();

        async void Send()
        {
            var data = new ValueSet().SetRequestMessage(RequestBox.Text);

            var result = await MyProtocolClientHelper.LaunchAsync(data);

            if (result.Status == LaunchUriStatus.Success)
            {
                ResponseBox.Text = result.Result.GetResponseMessage();
                ResponseBox.Foreground = new SolidColorBrush(Colors.Black);
            }
            else
            {
                ResponseBox.Text = $"Status: {result.Status}";
                ResponseBox.Foreground = new SolidColorBrush(Colors.Red);
            }
        }
    }
}
