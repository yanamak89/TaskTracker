# Task Tracker

Task Tracker is a console application for managing tasks. With it, you can add, update, delete tasks, and view the list of tasks by status.

## 💡 Features
- **Add tasks**: Add new tasks to the list.
- **Update tasks**: Modify the description of existing tasks.
- **Delete tasks**: Remove tasks by their ID.
- **Change status**: Mark tasks as "todo", "in-progress", or "done".
- **View tasks**: Display all tasks or filter them by status.

## 🔧 Requirements
- **.NET 6.0** or later.
- Installed [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json) library.

## ⚙️ Installation
1. Clone the repository or download the source code.
2. Install the required dependency via NuGet:
   ```bash
   dotnet add package Newtonsoft.Json
   ```
3. Build the project:
   ```bash
   dotnet build
   ```

## ⚡️ Usage
The application requires commands to be passed via the command line.

### Command format:
```bash
<command> [parameters]
```

### Command examples:

#### **1. Add a task**
```bash
dotnet Task\ Tracker.dll add "Buy groceries"
```
Result:
```
Task added successfully (ID: 1)
```

#### **2. Update a task**
```bash
dotnet Task\ Tracker.dll update 1 "Buy groceries and cook dinner"
```
Result:
```
Task updated successfully.
```

#### **3. Mark a task as "in-progress"**
```bash
dotnet Task\ Tracker.dll mark-in-progress 1
```
Result:
```
Task marked as in-progress.
```

#### **4. Mark a task as "done"**
```bash
dotnet Task\ Tracker.dll mark-done 1
```
Result:
```
Task marked as done.
```

#### **5. Delete a task**
```bash
dotnet Task\ Tracker.dll delete 1
```
Result:
```
Task deleted successfully.
```

#### **6. List all tasks**
```bash
dotnet Task\ Tracker.dll list
```
Result (example):
```
ID: 1, Description: Buy groceries, Status: todo, CreatedAt: 2025-01-28, UpdatedAt: 2025-01-28
```

#### **7. List tasks by status**
- Tasks with status "done":
  ```bash
  dotnet Task\ Tracker.dll list done
  ```
- Tasks with status "in-progress":
  ```bash
  dotnet Task\ Tracker.dll list in-progress
  ```

## 🔍 JSON File Structure
All tasks are stored in the `tasks.json` file in the following format:
```json
[
  {
    "Id": 1,
    "Description": "Buy groceries",
    "Status": "todo",
    "CreatedAt": "2025-01-28T10:00:00",
    "UpdatedAt": "2025-01-28T10:00:00"
  }
]
```

## 🌟 Future Improvements
- Add the ability to sort tasks by date.
- Add a feature to search tasks by keywords.
- Add color formatting for statuses in console output.

## ✌️ License
This project is open-source and distributed under the MIT License.

## ❓ Questions
If you have any questions or suggestions, contact us at: **yana.makogon@gmail.com**.

