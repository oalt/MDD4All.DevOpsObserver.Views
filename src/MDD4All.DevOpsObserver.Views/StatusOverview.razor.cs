using MDD4All.DevOpsObserver.ViewModels;
using Microsoft.AspNetCore.Components;

namespace MDD4All.DevOpsObserver.Views
{
    public partial class StatusOverview
    {
        [Parameter]
        public MainViewModel DataContext { get; set; }
    }
}