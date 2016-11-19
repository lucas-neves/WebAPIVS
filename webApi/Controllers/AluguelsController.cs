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
    public class AluguelsController : ApiController
    {
        private JogaJuntoDBContext db = new JogaJuntoDBContext();

        // GET: api/Aluguels
        public IList<AluguelView> GetAluguels()
        {
            IQueryable<Aluguel> aluguels = db.Aluguels;
            IList<AluguelView> retorno = new List<AluguelView>();

            foreach (var aluguel in aluguels)
            {
                retorno.Add(new AluguelView(aluguel));
            }
            return retorno;
        }

        // GET: api/Aluguels/5
        [ResponseType(typeof(AluguelView))]
        public async Task<IHttpActionResult> GetAluguel(int id)
        {
            Aluguel aluguel = await db.Aluguels.FindAsync(id);
            if (aluguel == null)
            {
                return NotFound();
            }

            return Ok(new AluguelView(aluguel));
        }

        // PUT: api/Aluguels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAluguel(int id, Aluguel aluguel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aluguel.Id_Aluguel)
            {
                return BadRequest();
            }

            db.Entry(aluguel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AluguelExists(id))
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

        // POST: api/Aluguels
        [ResponseType(typeof(Aluguel))]
        public async Task<IHttpActionResult> PostAluguel(Aluguel aluguel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Aluguels.Add(aluguel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = aluguel.Id_Aluguel }, aluguel);
        }

        // DELETE: api/Aluguels/5
        [ResponseType(typeof(Aluguel))]
        public async Task<IHttpActionResult> DeleteAluguel(int id)
        {
            Aluguel aluguel = await db.Aluguels.FindAsync(id);
            if (aluguel == null)
            {
                return NotFound();
            }

            db.Aluguels.Remove(aluguel);
            await db.SaveChangesAsync();

            return Ok(aluguel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AluguelExists(int id)
        {
            return db.Aluguels.Count(e => e.Id_Aluguel == id) > 0;
        }
    }
}