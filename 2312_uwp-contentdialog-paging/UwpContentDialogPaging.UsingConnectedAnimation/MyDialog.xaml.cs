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

            pinAnimation.Completed += PinAnimation_Completed;

            void PinAnimation_Completed(ConnectedAnimation _, object __)
            {
                pinAnimation.Completed -= PinAnimation_Completed;

                ItemsView.Visibility = Visibility.Collapsed;
            }

            BackButton.Visibility = Visibility.Visible;

            ContentView.Visibility = Visibility.Visible;
        }

        async void Button_Click(object sender, RoutedEventArgs e)
        {
            var animationService = ConnectedAnimationService.GetForCurrentView();
            
            var pinnedAnimation = animationService.PrepareToAnimate("Pin", ContentView);

            pinnedAnimation.Completed += PinAnimation_Completed;

            void PinAnimation_Completed(ConnectedAnimation _, object __)
            {
                pinnedAnimation.Completed -= PinAnimation_Completed;

                ContentView.Visibility = Visibility.Collapsed;
            }

            await ItemsView.TryStartConnectedAnimationAsync(pinnedAnimation
                , ViewModel.PinnedItem
                , "ItemRoot"
                );

            ViewModel.PinnedItem = null;

            ItemsView.Visibility = Visibility.Visible;

            BackButton.Visibility = Visibility.Collapsed;
        }
    }
}
