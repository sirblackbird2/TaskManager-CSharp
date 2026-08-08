# Task Manager (C#)

A console-based task management application built with C# and .NET. Create, edit, delete, search, and complete tasks through an interactive menu — all changes persist to a local JSON file.

## Screenshot

![Task Manager Menu](https://github.com/sirblackbird2/TaskManager-CSharp/raw/main/taskManagerScreenshot.png)

---

## Features

- Add new tasks (title + description)
- View all tasks
- Edit an existing task's title and description
- Delete a task by ID
- Mark a task as completed
- Search tasks by title or description (case-insensitive)
- Automatically loads saved tasks on startup
- Saves all tasks to a JSON file on exit

---

## Tech Stack

- C#
- .NET 10
- Object-Oriented Programming (OOP)
- `System.Text.Json` for persistence
- Git / GitHub

---

## Prerequisites

- **.NET 10 SDK** or later ([download](https://dotnet.microsoft.com/download))

---

## Project Structure

```
TaskManager-CSharp/
├── Models/
│   └── TaskItem.cs        # Task data model
├── Services/
│   └── TaskService.cs     # Business logic: CRUD, search, JSON load/save
├── Program.cs             # Console menu and application entry point
├── TaskManager.csproj     # Project file (targets net10.0)
└── .gitignore
```

---

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/sirblackbird2/TaskManager-CSharp.git
cd TaskManager-CSharp
```

### 2. Run the application

```bash
dotnet run
```

---

## Usage

On launch, the app loads any previously saved tasks and shows a menu:

```
===== Task Manager =====
1. Add Task
2. View Tasks
3. Delete Task
4. Complete Task
5. Edit Task
6. Search Task
7. Save & Exit
```

Enter the number for the action you want, then follow the prompts. Task IDs (used for delete, complete, and edit) are shown when you view your task list.

---

## Notes

- **Tasks are only written to disk when you choose option 7 (Save & Exit).** There's no autosave after adding, editing, or deleting a task, and no save-on-crash. If you close the console window directly or the app terminates unexpectedly, any changes made since the last save are lost. Always exit via option 7 to keep your changes.
- Entering an invalid ID or a non-numeric value at a prompt will reject the input and ask again rather than crashing.

---

## What I Learned

Through this project, I practiced:

- Designing applications using classes and objects
- Separating business logic from the user interface
- Working with `List<T>` collections
- Implementing CRUD operations
- Reading from and writing to JSON files
- Searching collections with case-insensitive string matching
- File handling in C#
- Version control using Git and GitHub

---

## Author

GitHub: **[sirblackbird2](https://github.com/sirblackbird2)**

## License

This project is for educational and portfolio purposes.
