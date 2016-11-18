using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using webApi.Models;

namespace webApi.Controllers
{
    public class ContasController : ApiController
    {
        private JogaJuntoDBContext db = new JogaJuntoDBContext();

        // GET: api/Contas
        [HttpGet]
        public IQueryable<Conta> GetContas()
        {
            return db.Contas;
        }

        // GET: api/Contas/
        [HttpGet]
        [ResponseType(typeof(ContaView))]
        public async Task<IHttpActionResult> GetConta(int id)
        {
            Conta conta = await db.Contas.FindAsync(id);
            if (conta == null)
            {
                return NotFound();
            }

            return Ok(new ContaView(conta));
        }

        // PUT: api/Contas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutConta(int id, Conta conta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != conta.Id_Acc)
            {
                return BadRequest();
            }

            db.Entry(conta).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Contas
        [ResponseType(typeof(Conta))]
        public async Task<IHttpActionResult> PostConta(Conta conta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Contas.Add(conta);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = conta.Id_Acc }, conta);
        }

        // DELETE: api/Contas/5
        [ResponseType(typeof(Conta))]
        public async Task<IHttpActionResult> DeleteConta(int id)
        {
            Conta conta = await db.Contas.FindAsync(id);
            if (conta == null)
            {
                return NotFound();
            }

            db.Contas.Remove(conta);
            await db.SaveChangesAsync();

            return Ok(conta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContaExists(int id)
        {
            return db.Contas.Count(e => e.Id_Acc == id) > 0;
        }
    }
}