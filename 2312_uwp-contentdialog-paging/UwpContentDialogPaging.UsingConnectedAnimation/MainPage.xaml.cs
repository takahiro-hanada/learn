using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace UwpContentDialogPaging.UsingConnectedAnimation
{
    sealed partial class MainPage : Page
    {
        public MainPage() => InitializeComponent();

        async protected override void OnNavigatedTo(NavigationEventArgs e) => await new MyDialog().ShowAsync();
    }
}
