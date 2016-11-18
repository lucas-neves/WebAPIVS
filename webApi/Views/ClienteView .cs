using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webApi.Models
{
	public class ClienteView
	{
		public ClienteView(Cliente cliente)
		{
            Id_Cliente = cliente.Id_Cliente;
            Username = cliente.Username;
			Senha = cliente.Senha;
            Email = cliente.Email;
            Id_Acc = cliente.Id_Acc;
            Id_End = cliente.Id_End;
            Telefone = cliente.Telefone;            
		}
		public int Id_Cliente { get; set; }
		public string Username { get; set; }
		public string Senha { get; set; }
		public string Email { get; set; }
		public int Id_Acc { get; set; }
		public int Id_End { get; set; }
		public string Telefone { get; set; }
	}
}
