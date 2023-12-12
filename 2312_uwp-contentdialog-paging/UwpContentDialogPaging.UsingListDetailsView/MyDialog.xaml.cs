using Windows.UI.Xaml.Controls;

namespace UwpContentDialogPaging.UsingListDetailsView
{
    sealed partial class MyDialog : ContentDialog
    {
        MyDialogViewModel ViewModel => DataContext as MyDialogViewModel;

        public MyDialog()
        {
            InitializeComponent();

            DataContext = new MyDialogViewModel();
        }

        void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ViewModel.SelectedItem = null;
        }
    }
}
