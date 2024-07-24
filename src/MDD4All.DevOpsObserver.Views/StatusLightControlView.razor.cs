using MDD4All.DevOpsObserver.DataModels;
using MDD4All.DevOpsObserver.StatusLightControl.Contracts;
using MDD4All.DevOpsObserver.ViewModels;
using Microsoft.AspNetCore.Components;

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
            DevOpsStatus status = DataContext.OverallStatus.Status.StatusValue;

            DevOpsStatus controllerStatus = StatusLightController.CurrentStatus;

            await StatusLightController.SetStatusLightAsync(status);

            if (controllerStatus != DevOpsStatus.Unknown &&
                status != DevOpsStatus.Success)
            {
                await StatusLightController.ActivateAlertAsync();
            }
            
        }

        private async Task CheckLightOnOffState()
        {
            DateTime now = DateTime.Now;

            bool onState = false;

            if (now.Hour >= DataContext.OnHour && now.Hour < DataContext.OffHour)
            {
                onState = true;
            }

            if (now.DayOfWeek == DayOfWeek.Sunday || now.DayOfWeek == DayOfWeek.Saturday)
            {
                if (DataContext.TurnOffOnWeekend)
                {
                    onState = false;
                }
            }
            
            if(onState == true && StatusLightController.IsOn == false)
            {
                await StatusLightController.TurnLightOnAsync();
            }
            else if(onState == false && StatusLightController.IsOn == true)
            {
                await StatusLightController.TurnLightOffAsync();
            }
        }

        private async void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            await InvokeAsync(async () =>
            {
                //Debug.WriteLine("PropertyChanged() called." + e.PropertyName);

                if (DataContext.StatusAvailable)
                {
                    await CheckLightOnOffState();
                    await SetLightStateAsync();
                }
            });
        }

    }
}