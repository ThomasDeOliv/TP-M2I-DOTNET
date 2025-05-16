using MauiSample.Models;

namespace MauiSample.Services
{
    internal class FakeTaskService : ITaskService
    {
        public List<TaskModel> Tasks { get; private set; }
        public TaskModel? SelectedTask { get; private set; }

        public FakeTaskService()
        {
            Tasks = new List<TaskModel>();
        }

        public async Task FetchTasksAsync()
        {
            await Task.Run(() =>
            {
                if (Tasks.Count == 0)
                {
                    List<TaskModel> fakeTasks = [
                           new TaskModel()
                       {
                            Id = 42,
                            Title = "Implémenter le module d'authentification",
                            Description = "Créer les API endpoints pour l'authentification des utilisateurs avec JWT",
                            Priority = "high",
                            Status = "in_progress",
                            CreatedAt = DateTimeOffset.FromUnixTimeSeconds(1746860400L),
                            UpdatedAt = DateTimeOffset.FromUnixTimeSeconds(1747053000L),
                            DueDate = DateTimeOffset.FromUnixTimeSeconds(1749988800L),
                       },
                   ];
                    Tasks.AddRange(fakeTasks);
                }
            });
        }

        public void SelectTask(int? selectedTaskIndex)
        {
            if (selectedTaskIndex.HasValue)
            {
                SelectedTask = Tasks[selectedTaskIndex.Value];
                return;
            }

            SelectedTask = null;
        }

        public async Task AddNewTaskAsync(TaskModel providedNewTask)
        {
            await Task.Run(() =>
            {
                TaskModel? lastTask = Tasks.LastOrDefault();

                TaskModel newTask = new TaskModel()
                {
                    Id = lastTask is not null ? (lastTask.Id + 1) : 1,
                    Title = providedNewTask.Title,
                    Description = providedNewTask.Description,
                    Priority = providedNewTask.Priority,
                    Status = providedNewTask.Status,
                    CreatedAt = DateTimeOffset.UtcNow,
                    UpdatedAt = DateTimeOffset.UtcNow,
                    DueDate = providedNewTask.DueDate
                };

                Tasks.Add(providedNewTask);
            });
        }

        public async Task UpdateTaskAsync(int taskId, string newStatus)
        {
            await Task.Run(() =>
            {
                TaskModel? currentTask = Tasks.FirstOrDefault((t) => t.Id.Equals(taskId));

                if (currentTask is null)
                {
                    return;
                }

                currentTask.Status = newStatus;
                currentTask.UpdatedAt = DateTimeOffset.UtcNow;
            });
        }
    }
}
