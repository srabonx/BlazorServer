
namespace ServerManagement.Components.Models
{
    public interface IServerEFRepository
    {
        void AddServer(Server server);
        void DeleteServer(int serverId);
        Server GetServerById(int id);
        List<Server> GetServers();
        List<Server> GetServersByCity(string cityName);
        List<Server> SearchServer(string serverFilter);
        void UpdateServer(int serverId, Server server);
    }
}