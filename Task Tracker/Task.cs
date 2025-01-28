namespace Task_Tracker;

public class Task
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string Status { get; set; } = "todo";
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}