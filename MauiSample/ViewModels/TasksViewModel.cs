using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using MauiSample.Models;
using MauiSample.Services;
using MauiSample.ViewModels.Base;

namespace MauiSample.ViewModels
{
    public partial class TasksViewModel : BaseViewModel
    {
        private readonly ITaskService _taskService;

        public ICommand GetTaskDetailsCommand { get; }
        public ICommand AddNewTaskCommand { get; }
        public ICommand LoadTasksCommand { get; }
        public ICommand UnLoadTasksCommand { get; }

        public ObservableCollection<TaskModel> Tasks { get; }

        public TasksViewModel(ITaskService taskService)
        {
            _taskService = taskService;
            Tasks = new ObservableCollection<TaskModel>();
            GetTaskDetailsCommand = new AsyncRelayCommand<int>(
                execute: async (index) =>
                {
                    _taskService.SelectTask(index);
                    await Shell.Current.GoToAsync("//task_details");
                },
                canExecute: (index) =>
                {
                    return _taskService.SelectedTask is null && index >= 0;
                }
            );
            AddNewTaskCommand = new AsyncRelayCommand(
                execute: async () =>
                {
                    await Shell.Current.GoToAsync("//new_task");
                },
                canExecute: () =>
                {
                    return _taskService.SelectedTask is null;
                }
            );
            LoadTasksCommand = new RelayCommand(
                execute: () =>
                {
                    foreach (TaskModel task in _taskService.Tasks)
                    {
                        Tasks.Add(task);
                    }
                },
                canExecute: () =>
                {
                    return Tasks.Count == 0;
                }
            );
            UnLoadTasksCommand = new RelayCommand(
                execute: () =>
                {
                    Tasks.Clear();
                },
                canExecute: () =>
                {
                    return Tasks.Count != 0;
                }
            );
        }
    }
}
