using MDD4All.DevOpsObserver.DataModels;
using MDD4All.DevOpsObserver.StatusLightControl.Contracts;
using MDD4All.DevOpsObserver.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Diagnostics;
using System.Timers;

namespace MDD4All.DevOpsObserver.Views
{
    public partial class StatusLightControlView
    {
        [Inject]
        public IStatusLightController StatusLightController { get; set; }

        [Parameter]
        public MainViewModel DataContext { get; set; }

        private System.Timers.Timer _timer;

        protected override void OnInitialized()
        {
            DataContext.PropertyChanged += OnPropertyChanged;

            Task.Run(()=> StatusLightController.TurnLightOnAsync()).Wait();
        }

        

        private async Task SetLightStateAsync()
        {
            DevOpsStatus status = DataContext.OverallStatus.Status.Status;
            
            if (StatusLightController.CurrentStatus != status)
            {
                await StatusLightController.SetStatusLightAsync(status);

                if (status != DevOpsStatus.Success)
                {
                    await StatusLightController.ActivateAlertAsync();
                }
            }
            
            
        }

        private async void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            //Debug.WriteLine("PropertyChanged() called." + e.PropertyName);

            if (DataContext.StatusAvailable)
            {
                await SetLightStateAsync();
            }
            
        }
    }
}