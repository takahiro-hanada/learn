using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace UwpContentDialogPaging.UsingListDetailsView
{
    sealed partial class MainPage : Page
    {
        public MainPage() => InitializeComponent();

        async protected override void OnNavigatedTo(NavigationEventArgs e) => await new MyDialog().ShowAsync();

        async void Button_Click(object sender, RoutedEventArgs e) => await new MyDialog().ShowAsync();
    }
}
