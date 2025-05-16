using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using MauiSample.Services;
using MauiSample.ViewModels.Base;

namespace MauiSample.ViewModels
{
    public partial class HomeViewModel : BaseViewModel
    {
        private readonly ITaskService _taskService;

        public ICommand GoToTasksCommand { get; }

        public HomeViewModel(ITaskService taskService)
        {
            _taskService = taskService;

            GoToTasksCommand = new AsyncRelayCommand(
                execute: async () =>
                {
                    await _taskService.FetchTasksAsync();
                    await Shell.Current.GoToAsync("//tasks", true);
                },
                canExecute: () =>
                {
                    return true;
                }
            );
        }
    }
}
