using TaskManager.Services;
TaskService taskService = new TaskService();

string? readResult;
string menuSelect = "";
do
{
    Console.Clear();
    Console.WriteLine("===== Task Manager =====");
    Console.WriteLine("1. Add Task");
    Console.WriteLine("2. View Tasks");
    Console.WriteLine("3. Exit");
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
            break;

        default:
            Console.WriteLine("Invalid option.");
            Console.ReadKey();
            break;
    }
} while (menuSelect != "3");