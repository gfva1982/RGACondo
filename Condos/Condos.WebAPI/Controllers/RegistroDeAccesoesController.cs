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
using Condos.Entities;

namespace Condos.WebAPI.Controllers
{
    public class RegistroDeAccesoesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/RegistroDeAccesoes
        public IQueryable<RegistroDeAcceso> GetRegistroDeAccesoes()
        {
            return db.RegistroDeAccesoes;
        }

        // GET: api/RegistroDeAccesoes/5
        [ResponseType(typeof(RegistroDeAcceso))]
        public async Task<IHttpActionResult> GetRegistroDeAcceso(int id)
        {
            RegistroDeAcceso registroDeAcceso = await db.RegistroDeAccesoes.FindAsync(id);
            if (registroDeAcceso == null)
            {
                return NotFound();
            }

            return Ok(registroDeAcceso);
        }

        // PUT: api/RegistroDeAccesoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRegistroDeAcceso(int id, RegistroDeAcceso registroDeAcceso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != registroDeAcceso.RegistroID)
            {
                return BadRequest();
            }

            db.Entry(registroDeAcceso).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistroDeAccesoExists(id))
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

        // POST: api/RegistroDeAccesoes
        [ResponseType(typeof(RegistroDeAcceso))]
        public async Task<IHttpActionResult> PostRegistroDeAcceso(RegistroDeAcceso registroDeAcceso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // crear lógica para extraer nombre del usuario y el condominio asociado.


            db.RegistroDeAccesoes.Add(registroDeAcceso);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = registroDeAcceso.RegistroID }, registroDeAcceso);
        }

        // DELETE: api/RegistroDeAccesoes/5
        [ResponseType(typeof(RegistroDeAcceso))]
        public async Task<IHttpActionResult> DeleteRegistroDeAcceso(int id)
        {
            RegistroDeAcceso registroDeAcceso = await db.RegistroDeAccesoes.FindAsync(id);
            if (registroDeAcceso == null)
            {
                return NotFound();
            }

            db.RegistroDeAccesoes.Remove(registroDeAcceso);
            await db.SaveChangesAsync();

            return Ok(registroDeAcceso);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RegistroDeAccesoExists(int id)
        {
            return db.RegistroDeAccesoes.Count(e => e.RegistroID == id) > 0;
        }
    }
}