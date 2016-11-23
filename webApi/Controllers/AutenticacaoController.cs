using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using webApi.Models;

namespace webApi.Controllers
{
	[RoutePrefix("api/Autenticar")]
	public class AutenticacaoController : ApiController
    {
		private JogaJuntoDBContext db = new JogaJuntoDBContext();

		[Route("login")]
		[HttpPost]
		[ResponseType(typeof(ClienteView))]
		public async Task<IHttpActionResult> Post([FromBody] Newtonsoft.Json.Linq.JObject data)
		{

			string email = data.GetValue("email").ToString();
			string senha = data.GetValue("senha").ToString();

			Cliente cliente = db.Clientes.First(x => x.Email == email && x.Senha == senha); // código de consulta por login e senha

			if (cliente == null)
			{
				return NotFound();
			}

			return Ok(new ClienteView(cliente));
		}

        [Route("user")]
        [HttpPost]
        [ResponseType(typeof(int))]
        public async Task<IHttpActionResult> UserPost([FromBody] Newtonsoft.Json.Linq.JObject data)
        {

            string email = data.GetValue("email").ToString();

            Cliente cliente = db.Clientes.First(x => x.Email == email);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente.Id_Cliente);
        }

		[Route("cadastro")]
		[HttpPost]
		[ResponseType(typeof(int))]
		public async Task<IHttpActionResult> CadastroPost(Cliente cliente)
		{

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			Cliente cl = db.Clientes.First(x => x.Email == cliente.Email);

			if (cl.Id_Cliente != null)
			{
				return BadRequest("Email já existe.");
			}

			db.Clientes.Add(cliente);
			await db.SaveChangesAsync();

			return CreatedAtRoute("DefaultApi", new { id = cliente.Id_Cliente }, cliente);
		}

	}
}
