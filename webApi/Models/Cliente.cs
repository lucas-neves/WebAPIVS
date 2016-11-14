using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace webApi.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            this.Aluguels = new List<Aluguel>();
            this.Favoritos = new List<Favorito>();
        }
		[Key]
        public int Id_Cliente { get; set; }
        public string Username { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public int Id_Acc { get; set; }
        public int Id_End { get; set; }
        public string Telefone { get; set; }
        public virtual ICollection<Aluguel> Aluguels { get; set; }
        public virtual Conta Conta { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual ICollection<Favorito> Favoritos { get; set; }
    }
}
