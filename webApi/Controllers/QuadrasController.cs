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
	[RoutePrefix("api/Quadras")]
	public class QuadrasController : ApiController
    {
        private JogaJuntoDBContext db = new JogaJuntoDBContext();

        //https://www.asp.net/web-api/overview/data/using-web-api-with-entity-framework/part-4

        // GET: api/Quadras
        public IList<QuadraView> GetQuadras()
        {
			IQueryable<Quadra> quadras = db.Quadras;
			IList<QuadraView> retorno = new List<QuadraView>();

			foreach (var quadra in quadras)
			{
				retorno.Add(new QuadraView(quadra));
			}
            return retorno;
        }		


		// GET: api/Quadras/5
		[ResponseType(typeof(QuadraView))]
        public async Task<IHttpActionResult> GetQuadra(int id)
        {
            Quadra quadra = await db.Quadras.FindAsync(id);
            
            if (quadra == null)
            {
                return NotFound();
            }

            return Ok(new QuadraView(quadra));
        }

        // PUT: api/Quadras/5
		[HttpGet]
        [ResponseType(typeof(void))]
		[Route("api/Quadras/{Id_Quadra}")]
		public async Task<IHttpActionResult> PutQuadra(int id, Quadra quadra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != quadra.Id_Quadra)
            {
                return BadRequest();
            }

            db.Entry(quadra).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuadraExists(id))
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

        // POST: api/Quadras
        [ResponseType(typeof(Quadra))]
        public async Task<IHttpActionResult> PostQuadra(Quadra quadra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Quadras.Add(quadra);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = quadra.Id_Quadra }, quadra);
        }
        
        // DELETE: api/Quadras/5
        [ResponseType(typeof(Quadra))]
        public async Task<IHttpActionResult> DeleteQuadra(int id)
        {
            Quadra quadra = await db.Quadras.FindAsync(id);
            if (quadra == null)
            {
                return NotFound();
            }

            db.Quadras.Remove(quadra);
            await db.SaveChangesAsync();

            return Ok(quadra);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuadraExists(int id)
        {
            return db.Quadras.Count(e => e.Id_Quadra == id) > 0;
        }
    }
}