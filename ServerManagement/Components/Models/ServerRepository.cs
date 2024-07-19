namespace ServerManagement.Components.Models;

public static class ServerRepository
{
	private static List<Server> m_servers = new List<Server>()
	{
		new Server {ServerId = 1, ServerName = "Server1", ServerCity = "Toronto" },
		new Server{ ServerId = 2, ServerName = "Server2", ServerCity = "Toronto" },
		new Server{ ServerId = 3, ServerName = "Server3", ServerCity = "Toronto" },
		new Server{ ServerId = 4, ServerName = "Server4", ServerCity = "Montreal" },
		new Server{ ServerId = 5, ServerName = "Server5", ServerCity = "Montreal" },
		new Server{ ServerId = 6, ServerName = "Server6", ServerCity = "Montreal" },
		new Server{ ServerId = 7, ServerName = "Server7", ServerCity = "Halifax" },
		new Server{ ServerId = 8, ServerName = "Server8", ServerCity = "Halifax" },
		new Server{ ServerId = 9, ServerName = "Server9", ServerCity = "Halifax" },
		new Server{ ServerId = 10, ServerName = "Server10", ServerCity = "Calgary" },
		new Server{ ServerId = 11, ServerName = "Server11", ServerCity = "Calgary" },
		new Server{ ServerId = 12, ServerName = "Server12", ServerCity = "Ottawa" },
		new Server{ ServerId = 13, ServerName = "Server13", ServerCity = "Ottawa" },
		new Server{ ServerId = 14, ServerName = "Server14", ServerCity = "Ottawa" }
	};

	public static void AddServer(Server server)
	{
		var maxId = 0;

		if (m_servers.Count > 0)
			maxId = m_servers.Max(s => s.ServerId);

		maxId++;
		server.ServerId = maxId;
		m_servers.Add(server);
	}

	public static List<Server> GetServers() => m_servers;

	public static List<Server> GetServersByCity(string cityName)
	{
		return m_servers.Where(s => s.ServerCity.Equals(cityName, StringComparison.OrdinalIgnoreCase)).ToList();
	}

	public static Server? GetServerById(int id)
	{
		var server = m_servers.FirstOrDefault(s => s.ServerId == id);

		if (server != null)
			return new Server
			{
				ServerId = server.ServerId,
				ServerName = server.ServerName,
				ServerCity = server.ServerCity,
				IsOnline = server.IsOnline 
			};

		return null;
	}

	public static void UpdateServer(int serverId, Server server)
	{
		if (serverId != server.ServerId) return;

		var serverToUpdate = m_servers.FirstOrDefault(s=> s.ServerId == serverId);

		if(serverToUpdate != null)
		{
			serverToUpdate.IsOnline = server.IsOnline;
			serverToUpdate.ServerName = server.ServerName;
			serverToUpdate.ServerCity = server.ServerCity;
		}
	}

	public static void DeleteServer(int serverId)
	{
		var server = m_servers.FirstOrDefault(s => s.ServerId == serverId);
		if (server != null)
		{
			m_servers.Remove(server);
		}
	}

	public static List<Server> SearchServer(string serverFilter)
	{
		var servers = m_servers.Where(s => s.ServerName.Contains(serverFilter, StringComparison.OrdinalIgnoreCase)).ToList();

		return servers;
	}

}
