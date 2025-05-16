using MauiSample.Models;

namespace MauiSample.Services
{
    public interface ITaskService
    {
        bool Loaded { get; }
        List<TaskModel> Tasks { get; }
        TaskModel? SelectedTask { get; }
        Task FetchTasksAsync();
        void SelectTask(int? selectedTaskIndex);
        Task AddNewTaskAsync(TaskModel providedNewTask);
        Task UpdateTaskAsync(int taskId, string newStatus);
    }
}
