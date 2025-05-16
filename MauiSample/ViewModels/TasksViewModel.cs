using MauiSample.Services;
using MauiSample.ViewModels.Base;

namespace MauiSample.ViewModels
{
    public partial class TasksViewModel : BaseViewModel
    {
        private readonly ITaskService _taskService;

        public TasksViewModel(ITaskService taskService)
        {
            _taskService = taskService;
        }
    }
}
