namespace ServerManagement.Components.Models;

public class Server
{

	public Server(int? id, string? name, string? city, bool isOnline = true)
	{
		ServerId = id;
		ServerName = name;
		ServerCity = city;
		IsOnline = isOnline;
	}

	public Server(Server server)
	{
		ServerId = server.ServerId;
		ServerName = server.ServerName;
		ServerCity = server.ServerCity;
		IsOnline = server.IsOnline;
	}
	public int? ServerId { get; set; }
	public string? ServerName { get; set; }
	public string? ServerCity {  get; set; }	
	public bool IsOnline { get; set; }
}
