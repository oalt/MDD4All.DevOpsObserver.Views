using MDD4All.DevOpsObserver.ViewModels;
using Microsoft.AspNetCore.Components;

namespace MDD4All.DevOpsObserver.Views.LCARS
{
    public partial class LcarsStatusCard
    {
        [Parameter]
        public StatusViewModel DataContext { get; set; }
    }
}