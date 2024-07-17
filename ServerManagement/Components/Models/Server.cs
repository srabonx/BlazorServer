using System.ComponentModel.DataAnnotations;

namespace ServerManagement.Components.Models;

public class Server
{

	public Server()
	{ 
	
	}

	public int ServerId { get; set; }

	[Required]
	public string? ServerName { get; set; }

	[Required]
	public string? ServerCity {  get; set; }	

	public bool IsOnline { get; set; }
}
