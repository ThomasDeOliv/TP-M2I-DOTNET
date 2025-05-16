using MauiSample.Models;

namespace MauiSample.Services
{
    public interface ITaskService
    {
        bool Loaded { get; }
        List<TaskModel> Tasks { get; }
        Task FetchTasksAsync();
        Task AddNewTaskAsync(TaskModel providedNewTask);
        Task UpdateTaskAsync(int taskId, string newStatus);
    }
}
