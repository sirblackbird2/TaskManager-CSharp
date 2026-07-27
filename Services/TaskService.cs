using TaskManager.Models;
namespace TaskManager.Services
{
    public class TaskService
    {
        private List<TaskItem> tasks = new List<TaskItem>();
        private int nextId = 1;
        public void AddTask(string title, string description)
        {
            TaskItem task = new TaskItem();
            task.Id = nextId;
            nextId++;
            task.Title = title;
            task.Description = description;
            task.IsCompleted = false;
            tasks.Add(task);
        }

        public void DisplayTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks found");
                return;
            }

            foreach (var task in tasks)
            {
                Console.WriteLine($"ID: {task.Id}");
                Console.WriteLine($"Title: {task.Title}");
                Console.WriteLine($"Description: {task.Description}");
                Console.WriteLine($"Completed: {(task.IsCompleted ? "Yes" : "No")}");
                Console.WriteLine("----------------------------");
                Console.WriteLine();
            }
        }

        public void DeleteTask(int id)
        {
            TaskItem? taskToDelete = null;
            foreach (var task in tasks)
            {
                if (task.Id == id)
                {
                    taskToDelete = task;
                    break;
                }
            }

            if (taskToDelete != null)
            {
                tasks.Remove(taskToDelete);
                Console.WriteLine("Task deleted successfully.");
            }

            else
            {
                Console.WriteLine("Task not found");
            }
        }
        public void CompleteTask(int id)
        {
            TaskItem? taskToComplete = null;
            foreach (var task in tasks)
            {
                if (task.Id == id)
                {
                    taskToComplete = task;
                    break;
                }
            }

            if (taskToComplete != null)
            {
                taskToComplete.IsCompleted = true;
                Console.WriteLine("Task marked as completed.");
            }

            else
            {
                Console.WriteLine("Task not found");
            }
        }
    }
}