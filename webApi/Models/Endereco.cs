using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace webApi.Models
{
    public partial class Endereco
    {
        public Endereco()
        {
            this.Clientes = new List<Cliente>();
            this.Quadras = new List<Quadra>();
        }

		[Key]
        public int Id_End { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Quadra> Quadras { get; set; }
    }
}
