using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
		[ResponseType(typeof(void))]
		public async Task<IHttpActionResult> CadastroPost(Cliente cliente)
		{

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

            const string queryTransaction = "INSERT INTO Cliente (Username, Senha, Email) VALUES (@Username, @Senha, @Email)";
            var constr = System.Configuration.ConfigurationManager.ConnectionStrings["JogaJuntoDBContext"].ConnectionString;

            using (var con = new SqlConnection(constr))
            {
                con.Open();
                using (var cmd = new SqlCommand(queryTransaction, con))
                {
                    cmd.Parameters.AddWithValue("@Username", cliente.Username);
                    cmd.Parameters.AddWithValue("@Senha", cliente.Senha);
                    cmd.Parameters.AddWithValue("@Email", cliente.Email);

                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

	}
}
