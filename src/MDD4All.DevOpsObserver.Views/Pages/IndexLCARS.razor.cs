using MDD4All.DevOpsObserver.DataModels;
using MDD4All.DevOpsObserver.StatusLightControl.Contracts;
using MDD4All.DevOpsObserver.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using System.ComponentModel;

namespace MDD4All.DevOpsObserver.Views.Pages
{
    public partial class IndexLCARS
    {
        [Inject]
        IConfiguration Configuration { get; set; }

        [Inject]
        HttpClient HttpClient { get; set; }

        [Inject]
        DevOpsConfiguration DevOpsConfiguration { get; set; }

        [Inject]
        IStatusLightController StatusLightController { get; set; }

        private static MainViewModel? DataContext { get; set; }

        protected override void OnInitialized()
        {
          
            DataContext = new MainViewModel(Configuration, HttpClient, DevOpsConfiguration);

            
            DataContext.PropertyChanged += OnPropertyChanged;
            

        }

        private void OnPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            InvokeAsync(() =>
            {
                StateHasChanged();
            });
        }
    }
}