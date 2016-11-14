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
    public class database_firewall_rulesController : ApiController
    {
        private JogaJuntoDBContext db = new JogaJuntoDBContext();

        // GET: api/database_firewall_rules
        public IQueryable<database_firewall_rules> Getdatabase_firewall_rules()
        {
            return db.database_firewall_rules;
        }

        // GET: api/database_firewall_rules/5
        [ResponseType(typeof(database_firewall_rules))]
        public async Task<IHttpActionResult> Getdatabase_firewall_rules(int id)
        {
            database_firewall_rules database_firewall_rules = await db.database_firewall_rules.FindAsync(id);
            if (database_firewall_rules == null)
            {
                return NotFound();
            }

            return Ok(database_firewall_rules);
        }

        // PUT: api/database_firewall_rules/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putdatabase_firewall_rules(int id, database_firewall_rules database_firewall_rules)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != database_firewall_rules.id)
            {
                return BadRequest();
            }

            db.Entry(database_firewall_rules).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!database_firewall_rulesExists(id))
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

        // POST: api/database_firewall_rules
        [ResponseType(typeof(database_firewall_rules))]
        public async Task<IHttpActionResult> Postdatabase_firewall_rules(database_firewall_rules database_firewall_rules)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.database_firewall_rules.Add(database_firewall_rules);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = database_firewall_rules.id }, database_firewall_rules);
        }

        // DELETE: api/database_firewall_rules/5
        [ResponseType(typeof(database_firewall_rules))]
        public async Task<IHttpActionResult> Deletedatabase_firewall_rules(int id)
        {
            database_firewall_rules database_firewall_rules = await db.database_firewall_rules.FindAsync(id);
            if (database_firewall_rules == null)
            {
                return NotFound();
            }

            db.database_firewall_rules.Remove(database_firewall_rules);
            await db.SaveChangesAsync();

            return Ok(database_firewall_rules);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool database_firewall_rulesExists(int id)
        {
            return db.database_firewall_rules.Count(e => e.id == id) > 0;
        }
    }
}