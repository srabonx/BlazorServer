using Newtonsoft.Json;
using System.ComponentModel;
using System.Text;

namespace ServerManagement.Components.Models
{
	public class ServerAPIRepository : IServerAPIRepository
	{
		private const string m_apiName = "ServersApi";
		private readonly IHttpClientFactory m_HttpClientFactory;
		public ServerAPIRepository(IHttpClientFactory httpClientFactory)
		{
			m_HttpClientFactory = httpClientFactory;
		}

		public async Task<List<Server>> GetServersAsync()
		{
			var client = m_HttpClientFactory.CreateClient(m_apiName);

			var response = await client.GetAsync("servers.json");

			response.EnsureSuccessStatusCode();

			var content = await response.Content.ReadAsStringAsync();
			
			if (!string.IsNullOrEmpty(content) && content != "null")
			{
				return JsonConvert.DeserializeObject<List<Server>>(content) ?? new List<Server>();
			}
			else
				return new List<Server>();
		}

		public async Task<Server> GetServerByIdAsync(int serverId)
		{
			var httpClient = m_HttpClientFactory.CreateClient(m_apiName);

			var response = await httpClient.GetAsync($"servers/{serverId}.json");

			response.EnsureSuccessStatusCode();

			var content = await response.Content.ReadAsStringAsync();

			if(content is not null && content != "null") 
			{
				return JsonConvert.DeserializeObject<Server>(content) ?? new Server();
			}
			return new Server();
		}

		public async Task<List<Server>> GetServerByCityAsync(string cityName)
		{
			var servers = await GetServersAsync();

			return servers.Where(s => s != null && s.ServerCity != null && s.ServerCity.Equals(cityName, StringComparison.OrdinalIgnoreCase)).ToList();
		}

		public async Task<List<Server>> SearchServerAsync(string serverName)
		{
			var servers = await GetServersAsync();

			return servers.Where(s => s != null && s.ServerName != null && s.ServerName.Contains(serverName, StringComparison.OrdinalIgnoreCase)).ToList();
		}

		public async Task AddServerAsync(Server server)
		{

			server.ServerId = await GetServerIdAsync();

			var httpClient = m_HttpClientFactory.CreateClient(m_apiName);

			var content = new StringContent(JsonConvert.SerializeObject(server), Encoding.UTF8, "application/json");

			var response = await httpClient.PutAsync($"servers/{server.ServerId}.json", content);
			response.EnsureSuccessStatusCode();	
		}

		public async Task UpdateServerAsync(int ServerId, Server server)
		{
			if (ServerId != 0)
			{
				var httpClient = m_HttpClientFactory.CreateClient(m_apiName);

				var response = await httpClient.GetAsync($"servers/{ServerId}.json");

				response.EnsureSuccessStatusCode();

				var content = await response.Content.ReadAsStringAsync();

				if (!string.IsNullOrEmpty(content))
				{
					var serverFromDb = JsonConvert.DeserializeObject<Server>(content);

					if (serverFromDb is not null)
					{
						serverFromDb.ServerName = server.ServerName;
						serverFromDb.ServerCity = server.ServerCity;
						serverFromDb.IsOnline = server.IsOnline;

						var UpdatedContent = new StringContent(JsonConvert.SerializeObject(serverFromDb), Encoding.UTF8, "application/json");

						await httpClient.PatchAsync($"servers/{ServerId}.json", UpdatedContent);
					}

				}
			}
		}

		public async Task DeleteServerAsync(int ServerId)
		{
			if (ServerId != 0)
			{
				var httpClient = m_HttpClientFactory.CreateClient(m_apiName);
				var response = await httpClient.DeleteAsync($"servers/{ServerId}.json");
				response.EnsureSuccessStatusCode();
			}	
		}

		// Get the ServerId for the next entry in the DB
		private async Task<int> GetServerIdAsync()
		{
			var servers = await GetServersAsync();

			if (servers is not null && servers.Any())
				return servers.Where(x => x is not null).Max(x => x.ServerId) + 1;

			return 1;
		}
	}
}
