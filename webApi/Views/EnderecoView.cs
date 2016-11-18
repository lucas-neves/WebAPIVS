using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace webApi.Models
{
    public partial class EnderecoView
    {
        public EnderecoView(Endereco endereco)
        {
            Id_End = endereco.Id_End;
            Logradouro = endereco.Logradouro;
            Complemento = endereco.Complemento;
            CEP = endereco.CEP;
            Bairro = endereco.Bairro;
            Cidade = endereco.Cidade;
        }

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
