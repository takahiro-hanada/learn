using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace UwpContentDialogPaging.UsingConnectedAnimation
{
    sealed class MyDialogViewModel : ObservableObject
    {
        public ReadOnlyCollection<MyItemViewModel> Items { get; } = Array.AsReadOnly(new[]
        {
            new MyItemViewModel("Item 1"),
            new MyItemViewModel("Item 2")
        });

        MyItemViewModel _pinnedItem;
        public MyItemViewModel PinnedItem
        {
            get => _pinnedItem;
            set => SetProperty(ref _pinnedItem, value);
        }
    }
}
