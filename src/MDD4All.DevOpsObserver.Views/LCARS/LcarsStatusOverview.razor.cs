using MDD4All.DevOpsObserver.ViewModels;
using Microsoft.AspNetCore.Components;

namespace MDD4All.DevOpsObserver.Views.LCARS
{
    public partial class LcarsStatusOverview
    {
        [Parameter]
        public MainViewModel DataContext { get; set; }

        protected override void OnInitialized()
        {
            if (DataContext != null)
            {
                DataContext.PropertyChanged += OnPropertyChanged;
            }
        }

        private void OnPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            InvokeAsync(() =>
            {
                StateHasChanged();
            });

        }
    }
}