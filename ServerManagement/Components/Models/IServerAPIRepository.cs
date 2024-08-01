
namespace ServerManagement.Components.Models
{
	public interface IServerAPIRepository
	{
		Task AddServerAsync(Server server);
		Task DeleteServerAsync(int ServerId);
		Task<List<Server>> GetServerByCityAsync(string cityName);
		Task<Server> GetServerByIdAsync(int serverId);
		Task<List<Server>> GetServersAsync();
		Task<List<Server>> SearchServerAsync(string serverName);
		Task UpdateServerAsync(int ServerId, Server server);
	}
}