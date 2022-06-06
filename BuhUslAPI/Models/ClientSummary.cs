using BuhUsl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuhUsl.Models
{
	public class ClientSummaryViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }


		public static ClientSummaryViewModel FromClient(Client client)
		{
			return new ClientSummaryViewModel
			{
				Id = client.ClientId,
				Name = client.Name,
				Email = client.Email,
			};
		}
	}
}
