using MDD4All.DevOpsObserver.ViewModels;
using Microsoft.AspNetCore.Components;

namespace MDD4All.DevOpsObserver.Views
{
    public partial class StatusOverview
    {
        [Parameter]
        public MainViewModel DataContext { get; set; }

        protected override void OnInitialized()
        {
            if(DataContext != null)
            {
                DataContext.PropertyChanged += OnPropertyChanged;
            }
        }

        private void OnPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            StateHasChanged();
        }
    }
}