using MDD4All.DevOpsObserver.ViewModels;
using Microsoft.AspNetCore.Components;

namespace MDD4All.DevOpsObserver.Views.LCARS
{
    public partial class LcarsStatusPanel
    {
        [Parameter]
        public StatusViewModel DataContext { get; set; }

        private string StatusColorCss
        {
            get
            {
                string result = string.Empty;

                if (DataContext.Status.StatusValue == DataModels.DevOpsStatus.Success)
                {
                    result = "bg-success";
                }

                return result;
            }
        }
    }
}