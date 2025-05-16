using MauiSample.Services;
using MauiSample.ViewModels.Base;

namespace MauiSample.ViewModels
{
    public partial class NewTaskViewModel : BaseViewModel
    {
        private readonly ITaskService _taskService;

        public NewTaskViewModel(ITaskService taskService)
        {
            _taskService = taskService;
        }
    }
}
