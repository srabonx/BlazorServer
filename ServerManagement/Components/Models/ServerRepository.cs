namespace ServerManagement.Components.Models;

public static class ServerRepository
{
	private static List<Server> m_servers = new List<Server>()
	{
		new Server(id:1, name :"Server1",city: "Toronto"),
		new Server(id:2, name :"Server2", city: "Toronto"),
		new Server(id:3, name:"Server3", city:"Toronto"),
		new Server(id:4, name:"Server4", city: "New York"),
		new Server(id:5, name:"Server5", city: "London"),
		new Server(id:6, name:"Server6", city:"Dubai"),
		new Server(id:7, name:"Server7", city:"Dubai"),
		new Server(id:8, name:"Server8", city:"Dhaka"),
		new Server(id:9, name:"Server9", city:"Dhaka"),
		new Server(id:10, name:"Server10", city:"Noakhali"),
		new Server(id:11, name:"Server11", city:"Borishal"),
		new Server(id:12, name:"Server12", city:"Borishal"),
		new Server(id:13, name:"Server13", city:"Vegas"),
		new Server(id:14, name:"Server14", city:"California")
	};

	public static void AddServer(Server server)
	{
		var maxId = m_servers.Max(s => s.ServerId);
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
			return new Server(server);

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
