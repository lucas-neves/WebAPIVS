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
    [RoutePrefix("api/Donoes")]
    public class DonoesController : ApiController
    {
        private JogaJuntoDBContext db = new JogaJuntoDBContext();

        // GET: api/Donoes
        public IQueryable<Dono> GetDonoes()
        {
            return db.Donoes;
        }

        // GET: api/Donoes/5
        [ResponseType(typeof(DonoView))]
        public async Task<IHttpActionResult> GetDono(int id)
        {
            Dono dono = await db.Donoes.FindAsync(id);
            if (dono == null)
            {
                return NotFound();
            }

            return Ok(new DonoView(dono));
        }

        // PUT: api/Donoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDono(int id, Dono dono)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dono.Id_Dono)
            {
                return BadRequest();
            }

            db.Entry(dono).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonoExists(id))
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

        // POST: api/Donoes
        [ResponseType(typeof(Dono))]
        public async Task<IHttpActionResult> PostDono(Dono dono)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Donoes.Add(dono);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = dono.Id_Dono }, dono);
        }

        // DELETE: api/Donoes/5
        [ResponseType(typeof(Dono))]
        public async Task<IHttpActionResult> DeleteDono(int id)
        {
            Dono dono = await db.Donoes.FindAsync(id);
            if (dono == null)
            {
                return NotFound();
            }

            db.Donoes.Remove(dono);
            await db.SaveChangesAsync();

            return Ok(dono);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DonoExists(int id)
        {
            return db.Donoes.Count(e => e.Id_Dono == id) > 0;
        }
    }
}