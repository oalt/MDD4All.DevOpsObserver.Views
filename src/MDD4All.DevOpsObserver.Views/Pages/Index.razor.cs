using MDD4All.DevOpsObserver.DataModels;
using MDD4All.DevOpsObserver.StatusLightControl.Contracts;
using MDD4All.DevOpsObserver.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace MDD4All.DevOpsObserver.Views.Pages
{
    public partial class Index
    {

        [Inject]
        IConfiguration Configuration { get; set; }

        [Inject]
        HttpClient HttpClient { get; set; }

        [Inject]
        DevOpsConfiguration DevOpsConfiguration { get; set; }

        [Inject]
        IStatusLightController StatusLightController { get; set; }

        [Inject]
        public MainViewModel DataContext { get; set; }

        protected override void OnInitialized()
        {

        }

    }
}