using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Task_Tracker;

public class TaskManager
{
    private const string FilePath = "tasks.json";

    public List<Task> LoadTasks()
    {
        if (!File.Exists(FilePath))
            return new List<Task>();

        var json = File.ReadAllText(FilePath);
        return JsonConvert.DeserializeObject<List<Task>>(json)
               ?? new List<Task>();
    }

    public void SaveTasks(List<Task> tasks)
    {
        var json = JsonConvert.SerializeObject(tasks, Formatting.Indented);
        File.WriteAllText(FilePath, json);
    }

    public void AddTask(string description)
    {
        var tasks = LoadTasks();
        var newTask = new Task
        {
            Id = tasks.Count > 0 ? tasks.Max(t => t.Id) + 1 : 1,
            Description = description
        };
        tasks.Add(newTask);
        newTask.CreatedAt = DateTime.Now;
        SaveTasks(tasks);
        Console.WriteLine($"Task added successfully (ID: {newTask.Id})");
    }

    public void UpdateTask(int id, string description)
    {
        var tasks = LoadTasks();
        var task = tasks.FirstOrDefault(t => t.Id == id);
        if (tasks == null)
        {
            Console.WriteLine("Task not found.");
            return;
        }
        task.Description = description;
        task.UpdatedAt = DateTime.Now;
        SaveTasks(tasks);
        Console.WriteLine("Task updated successfully");
    }

    public void DeleteTask(int id)
    {
        var tasks = LoadTasks();
        var task = tasks.FirstOrDefault(t => t.Id == id);
        if (tasks == null)
        {
            Console.WriteLine("Task not found.");
            return;
        }

        tasks.Remove(task);
        SaveTasks(tasks);
        Console.WriteLine("Task deleted successfully.");

    }

    public void MarkTask(int id, string status)
    {
        var tasks = LoadTasks();
        var task = tasks.FirstOrDefault(t => t.Id == id);
        if (tasks == null)
        {
            Console.WriteLine("Task not found.");
            return;
        }

        task.Status = status;
        task.UpdatedAt = DateTime.Now;
        SaveTasks(tasks);
        Console.WriteLine($"Task marked as {status}.");
    }

    public void ListTasks(string filter = null)
    {
        var tasks = LoadTasks();
        var filteredTasks = string.IsNullOrEmpty(filter)
            ? tasks
            : tasks.Where(t => t.Status.Equals(filter, StringComparison.OrdinalIgnoreCase)).ToList();

        if (!filteredTasks.Any())
        {
            Console.WriteLine("No tasks found.");
            return;
        }

        foreach (var task in filteredTasks)
        {
            Console.WriteLine($"ID: {task.Id}, Description: {task.Description}, Status: {task.Status}, CreatedAt: {task.CreatedAt}, UpdatedAt: {task.UpdatedAt}");
            
        }
    }

}