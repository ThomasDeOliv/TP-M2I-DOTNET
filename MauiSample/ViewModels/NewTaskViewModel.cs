using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using MauiSample.Models;
using MauiSample.Services;
using MauiSample.ViewModels.Base;

namespace MauiSample.ViewModels
{
    public partial class NewTaskViewModel : BaseViewModel
    {
        private readonly ITaskService _taskService;

        public ICommand CleanCommand { get; }
        public ICommand GoBackCommand { get; }
        public ICommand CreateTaskCommand { get; }

        private string _title = string.Empty;
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
                (CreateTaskCommand as AsyncRelayCommand)?.NotifyCanExecuteChanged();
            }
        }


        private string _description = string.Empty;
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
                (CreateTaskCommand as AsyncRelayCommand)?.NotifyCanExecuteChanged();
            }
        }


        private string _priority = string.Empty;
        public string Priority
        {
            get => _priority;
            set
            {
                _priority = value;
                OnPropertyChanged(nameof(Priority));
                (CreateTaskCommand as AsyncRelayCommand)?.NotifyCanExecuteChanged();
            }
        }


        private DateTimeOffset _dueDate = DateTimeOffset.UtcNow;
        public DateTimeOffset DueDate
        {
            get => _dueDate;
            set
            {
                _dueDate = value;
                OnPropertyChanged(nameof(DueDate));
                (CreateTaskCommand as AsyncRelayCommand)?.NotifyCanExecuteChanged();
            }
        }

        public NewTaskViewModel(ITaskService taskService)
        {
            _taskService = taskService;
            CleanCommand = new RelayCommand(
                execute: () =>
                {

                },
                canExecute: () =>
                {
                    return true;
                }
            );
            GoBackCommand = new AsyncRelayCommand(
                execute: async () =>
                {
                    await Shell.Current.GoToAsync("//tasks");
                },
                canExecute: () => true
            );
            CreateTaskCommand = new AsyncRelayCommand(
                execute: async () =>
                {
                    await _taskService.AddNewTaskAsync(new TaskModel()
                    {
                        Title = Title,
                        Description = Description,
                        Priority = Priority,
                        DueDate = DueDate,
                    });
                    await Shell.Current.GoToAsync("//tasks");
                },
                canExecute: () =>
                {
                    return !string.IsNullOrWhiteSpace(Title)
                        && !string.IsNullOrWhiteSpace(Description)
                        && !string.IsNullOrWhiteSpace(Priority);
                }
            );
        }
    }
}
