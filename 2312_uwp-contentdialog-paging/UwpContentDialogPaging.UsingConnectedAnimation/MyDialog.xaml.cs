using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace UwpContentDialogPaging.UsingConnectedAnimation
{
    sealed partial class MyDialog : ContentDialog
    {
        MyDialogViewModel ViewModel => DataContext as MyDialogViewModel;

        public MyDialog()
        {
            InitializeComponent();

            DataContext = new MyDialogViewModel();
        }

        void ItemsView_ItemClick(object sender, ItemClickEventArgs e)
        {
            ViewModel.PinnedItem = e.ClickedItem as MyItemViewModel;

            var pinAnimation = ItemsView.PrepareConnectedAnimation("Pin"
                , ViewModel.PinnedItem
                , "ItemRoot"
                );

            pinAnimation.TryStart(ContentView);

            ContentView.Visibility = BackButton.Visibility = Visibility.Visible;

            ItemsView.Visibility = Visibility.Collapsed;
        }

        async void Button_Click(object sender, RoutedEventArgs e)
        {
            var animationService = ConnectedAnimationService.GetForCurrentView();

            var pinnedAnimation = animationService.PrepareToAnimate("Pin", ContentView);

            await ItemsView.TryStartConnectedAnimationAsync(pinnedAnimation
                , ViewModel.PinnedItem
                , "ItemRoot"
                );

            ViewModel.PinnedItem = null;

            ContentView.Visibility = BackButton.Visibility = Visibility.Collapsed;

            ItemsView.Visibility = Visibility.Visible;
        }
    }
}
