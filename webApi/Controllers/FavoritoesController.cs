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
    public class FavoritoesController : ApiController
    {
        private JogaJuntoDBContext db = new JogaJuntoDBContext();

        // GET: api/Favoritoes
        public IList<FavoritoView> GetFavoritoes()
        {
            IQueryable<Favorito> favoritos = db.Favoritoes;
            IList<FavoritoView> retorno = new List<FavoritoView>();

            foreach (var favorito in favoritos)
            {
                retorno.Add(new FavoritoView(favorito));
            }
            return retorno;
        }

        // GET: api/Favoritoes/5
        [ResponseType(typeof(FavoritoView))]
        public async Task<IHttpActionResult> GetFavorito(int id)
        {
            Favorito favorito = await db.Favoritoes.FindAsync(id);
            if (favorito == null)
            {
                return NotFound();
            }

            return Ok(new FavoritoView(favorito));
        }

        // PUT: api/Favoritoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFavorito(int id, Favorito favorito)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != favorito.Id_Favorito)
            {
                return BadRequest();
            }

            db.Entry(favorito).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoritoExists(id))
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

        // POST: api/Favoritoes
        [ResponseType(typeof(Favorito))]
        public async Task<IHttpActionResult> PostFavorito(Favorito favorito)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Favoritoes.Add(favorito);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = favorito.Id_Favorito }, favorito);
        }

        // DELETE: api/Favoritoes/5
        [ResponseType(typeof(Favorito))]
        public async Task<IHttpActionResult> DeleteFavorito(int id)
        {
            Favorito favorito = await db.Favoritoes.FindAsync(id);
            if (favorito == null)
            {
                return NotFound();
            }

            db.Favoritoes.Remove(favorito);
            await db.SaveChangesAsync();

            return Ok(favorito);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FavoritoExists(int id)
        {
            return db.Favoritoes.Count(e => e.Id_Favorito == id) > 0;
        }
    }
}