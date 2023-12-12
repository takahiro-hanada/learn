using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace UwpContentDialogPaging.UsingListDetailsView
{
    sealed class MyDialogViewModel : ObservableObject
    {
        public ReadOnlyCollection<MyItemViewModel> Items { get; } = Array.AsReadOnly(new[]
        {
            new MyItemViewModel("Item 1"),
            new MyItemViewModel("Item 2")
        });

        MyItemViewModel _selectedItem;
        public MyItemViewModel SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }
    }
}
