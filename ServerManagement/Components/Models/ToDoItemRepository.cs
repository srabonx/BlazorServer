namespace ServerManagement.Components.Models;

public static class ToDoItemRepository
{
	private static List<ToDoItem> m_items = new List<ToDoItem>()
	{
		new ToDoItem{Id = 1,Description = "Item 1",IsCompleted = false},
		new ToDoItem{Id = 2,Description = "Item 2",IsCompleted = false},
		new ToDoItem{Id = 3,Description = "Item 3",IsCompleted = false},
		new ToDoItem{Id = 4,Description = "Item 4",IsCompleted = false},
	};

	public static void AddItem(ToDoItem item)
	{
		var maxId = 0;

		if (m_items.Count > 0)
			maxId = m_items.Max(s => s.Id);

		maxId++;
		item.Id = maxId;
		m_items.Add(item);
	}

	public static List<ToDoItem> GetItems()
	{
		var sortedItem = m_items.OrderBy(item => item.IsCompleted).
							ThenByDescending(item => item.Id).ToList();

		return sortedItem;
	}

	public static List<ToDoItem> GetItemsByDescription(string desc)
	{
		return m_items.Where(s => s.Description.Equals(desc, StringComparison.OrdinalIgnoreCase)).ToList();
	}

	public static ToDoItem? GetItemById(int id)
	{
		var item = m_items.FirstOrDefault(s => s.Id == id);

		if (item != null)
			return new ToDoItem
			{
				Id = item.Id,
				Description = item.Description,
				IsCompleted = item.IsCompleted,
				CompletedTime = item.CompletedTime
			};

		return null;
	}

	public static void UpdateItem(int id, ToDoItem item)
	{
		if (id != item.Id) return;

		var itemToUpdate = m_items.FirstOrDefault(s => s.Id == id);

		if (itemToUpdate != null)
		{
			itemToUpdate.Description = item.Description;
			itemToUpdate.IsCompleted = item.IsCompleted;
			itemToUpdate.CompletedTime = item.CompletedTime;
		}
	}

	public static void DeleteItem(int id)
	{
		var item = m_items.FirstOrDefault(s => s.Id == id);
		if (item != null)
		{
			m_items.Remove(item);
		}
	}

	public static List<ToDoItem> SearchItem(string desc)
	{
		var items = m_items.Where(s => s.Description.Contains(desc, StringComparison.OrdinalIgnoreCase)).ToList();

		return items;
	}

}
