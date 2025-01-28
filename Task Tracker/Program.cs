using Task_Tracker;

class Program
{
    public static void Main(string[] args)
    {
        var manager = new TaskManager();
        if (args.Length == 0)
        {
            Console.WriteLine("Usage: task-cli <command> [options]");
            return;
        }

        var command = args[0].ToLower();

        try
        {
            switch (command)
            {
                case "add":
                    manager.AddTask(args[1]);
                    break;
                case "update":
                    manager.UpdateTask(int.Parse(args[1]), args[2]);
                    break;
                case "delete":
                    manager.DeleteTask(int.Parse(args[1]));
                    break;
                case "mark-in-progress":
                    manager.MarkTask(int.Parse(args[1]), "in-progress");
                    break;
                case "mark-done":
                    manager.MarkTask(int.Parse(args[1]), "done");
                    break;
                case "list":
                    manager.ListTasks(args.Length > 1 ? args[1] : null);
                    break;
                default:
                    Console.WriteLine("Unknown command.");
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
           
        }
    }
}