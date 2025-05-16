using MauiSample.Services;
using MauiSample.ViewModels.Base;

namespace MauiSample.ViewModels
{
    public partial class TaskDetailsViewModel : BaseViewModel
    {
        private readonly ITaskService _taskService;

        public TaskDetailsViewModel(ITaskService taskService)
        {
            _taskService = taskService;
        }
    }
}
