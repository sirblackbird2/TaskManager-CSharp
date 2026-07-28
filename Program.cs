using TaskManager.Models;
using TaskManager.Services;
TaskService taskService = new TaskService();
taskService.LoadTasks();

string? readResult;
string menuSelect = "";
bool validExit = false;
int id = 0;

do
{
    Console.Clear();
    Console.WriteLine("===== Task Manager =====");
    Console.WriteLine("1. Add Task");
    Console.WriteLine("2. View Tasks");
    Console.WriteLine("3. Delete Task");
    Console.WriteLine("4. Complete Task");
    Console.WriteLine("5. Edit Task");
    Console.WriteLine("6. Search Task");
    Console.WriteLine("7. Save & Exit");
    Console.WriteLine($"\nEnter an option: ");

    readResult = Console.ReadLine();
    Console.WriteLine();

    if (readResult != null)
    {
        menuSelect = readResult.ToLower();
    }

    switch (menuSelect)
    {
        case "1":
            Console.WriteLine("Enter task title: ");
            string title = Console.ReadLine() ?? "";

            Console.WriteLine("\nEnter task description: ");
            string description = Console.ReadLine() ?? "";

            taskService.AddTask(title, description);

            Console.WriteLine("\nTask added successfully!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            break;

        case "2":
            taskService.DisplayTasks();
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            break;

        case "3":
            validExit = false;

            do
            {
                Console.WriteLine("Enter a task ID to delete: ");
                readResult = Console.ReadLine();
                if (readResult != null)
                {

                    if (int.TryParse(readResult, out id))
                    {
                        taskService.DeleteTask(id);
                        validExit = true;
                    }

                    else
                    {
                        Console.WriteLine("Please enter a valid Id.");
                    }
                }
            } while (validExit == false);
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            break;

        case "4":
            validExit = false;
            do
            {
                Console.WriteLine("Enter a task ID to complete: ");
                readResult = Console.ReadLine();
                if (readResult != null)
                {

                    if (int.TryParse(readResult, out id))
                    {
                        taskService.CompleteTask(id);
                        validExit = true;
                    }

                    else
                    {
                        Console.WriteLine("Please enter a valid Id.");
                    }
                }
            } while (validExit == false);
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            break;

        case "5":
            validExit = false;
            do
            {
                Console.WriteLine("Enter a task ID to edit: ");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    if (int.TryParse(readResult, out id))
                    {
                        TaskItem? task = taskService.FindTaskById(id);

                        if (task != null)
                        {
                            Console.WriteLine($"Current task title: {task.Title}");
                            Console.WriteLine($"Current task description: {task.Description}");

                            Console.WriteLine($"\nEnter a new title: ");
                            string? newTitle = Console.ReadLine();

                            Console.WriteLine($"\nEnter a new description: ");
                            string? newDescription = Console.ReadLine();

                            if (newTitle != null && newDescription != null)
                            {
                                taskService.EditTask(id: id, newTitle: newTitle, newDescription: newDescription);
                                validExit = true;
                            }

                            else
                            {
                                Console.WriteLine("Please enter a valid title and description.");
                            }
                        }

                        else
                        {
                            Console.WriteLine("Task not found.");
                        }

                    }

                    else
                    {
                        Console.WriteLine("Please enter a valid Id.");
                    }
                }
            } while (validExit == false);
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            break;

        case "6":
            Console.WriteLine("Search a keyword: ");
            string? keyword = Console.ReadLine();
            Console.WriteLine("");
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                taskService.SearchTasks(keyword);
            }

            else
            {
                Console.WriteLine("Enter a valid keyword.");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            break;

        case "7":
            taskService.SaveTasks();
            Console.WriteLine("Tasks saved successfully.");
            break;

        default:
            Console.WriteLine("Invalid option.");
            Console.ReadKey();
            break;
    }
} while (menuSelect != "7");