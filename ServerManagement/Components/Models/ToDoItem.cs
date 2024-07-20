namespace ServerManagement.Components.Models;

public class ToDoItem
{ 
	public int Id { get; set; }
	public string Description { get; set; } = string.Empty;
	public bool IsCompleted { get; set; }
	public DateTime CompletedTime { get; set; }
}

