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
            TaskItem? taskToDelete = FindTaskById(id);

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
            TaskItem? taskToComplete = FindTaskById(id);

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

        public void EditTask(int id, string newTitle, string newDescription)
        {
            TaskItem? taskToEdit = FindTaskById(id);

            if (taskToEdit != null)
            {
                taskToEdit.Title = newTitle;
                taskToEdit.Description = newDescription;

                Console.WriteLine("Task edited successfully.");
            }

            else
            {
                Console.WriteLine("Task not found.");
            }
        }

        public void SearchTasks(string keyword)
        {
            int counter = 0;
            foreach (var task in tasks)
            {
                if (task.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) || task.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                {
                    counter++;

                    Console.WriteLine($"Task {counter}");
                    Console.WriteLine($"ID: {task.Id}");
                    Console.WriteLine($"Title: {task.Title}");
                    Console.WriteLine($"Description: {task.Description}");
                    Console.WriteLine($"Completed: {(task.IsCompleted ? "Yes" : "No")}");
                    Console.WriteLine($"----------------------------\n");
                }
            }

            if (counter == 0)
            {
                Console.WriteLine($"Found 0 tasks containing the keyword \"{keyword}\"");
            }
        }

        public TaskItem? FindTaskById(int id)
        {
            foreach (var task in tasks)
            {
                if (task.Id == id)
                {
                    return task;
                }
            }
            return null;
        }
    }
}