using Microsoft.EntityFrameworkCore;
using ServerManagement.Components.Models;

namespace ServerManagement.Components.Database
{
    public class ServerManagementContext : DbContext
    {
        public DbSet<Server> Servers { get; set; }
        public ServerManagementContext(DbContextOptions<ServerManagementContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Server>().HasData(new List<Server>()
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
        
            });
        
        }

    }
}
