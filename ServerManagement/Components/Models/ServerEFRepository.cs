using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ServerManagement.Components.Database;

namespace ServerManagement.Components.Models
{
    public class ServerEFRepository : IServerEFRepository
    {
        private readonly IDbContextFactory<ServerManagementContext> ContextFactory;

        public ServerEFRepository(IDbContextFactory<ServerManagementContext> contextFactory)
        {
            ContextFactory = contextFactory;
        }

        public void AddServer(Server server)
        {
            var db = ContextFactory.CreateDbContext();
            db.Servers.Add(server);
            db.SaveChanges();
        }

        public List<Server> GetServers()
        {
            var db = ContextFactory.CreateDbContext();
            return db.Servers.ToList();
        }

        public Server GetServerById(int id)
        {
            var db = ContextFactory.CreateDbContext();
            var server = db.Servers.Find(id);

            if (server is not null)
                return server;

            return new Server();
        }

        public List<Server> GetServersByCity(string cityName)
        {
            var db = ContextFactory.CreateDbContext();
            var servers = db.Servers.Where(s => s.ServerCity != null && s.ServerCity.ToLower().IndexOf(cityName.ToLower()) >= 0);

            return servers.ToList();
        }

        public void UpdateServer(int serverId, Server server)
        {
            var db = ContextFactory.CreateDbContext();

            var serverFromDb = db.Servers.Find(serverId);

            if (serverFromDb == null) return;

            serverFromDb.ServerName = server.ServerName;
            serverFromDb.ServerCity = server.ServerCity;
            serverFromDb.IsOnline = server.IsOnline;

            db.SaveChanges();
        }

        public void DeleteServer(int serverId)
        {
            var db = ContextFactory.CreateDbContext();
            var server = db.Servers.Find(serverId);

            if (server == null) return;

            db.Servers.Remove(server);
            db.SaveChanges();
        }

        public List<Server> SearchServer(string serverFilter)
        {
            var db = ContextFactory.CreateDbContext();
            var servers = db.Servers.Where(s => s.ServerName != null && s.ServerName.ToLower().IndexOf(serverFilter.ToLower()) >= 0);

            return servers.ToList();
        }

    }
}
