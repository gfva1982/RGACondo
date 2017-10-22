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
    public class InmueblesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Inmuebles
        public IQueryable<Inmueble> GetInmuebles()
        {
            return db.Inmuebles;
        }

        // GET: api/Inmuebles/5
        [ResponseType(typeof(Inmueble))]
        public async Task<IHttpActionResult> GetInmueble(int id)
        {
            Inmueble inmueble = await db.Inmuebles.FindAsync(id);
            if (inmueble == null)
            {
                return NotFound();
            }

            return Ok(inmueble);
        }

        // PUT: api/Inmuebles/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutInmueble(int id, Inmueble inmueble)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inmueble.InmuebleID)
            {
                return BadRequest();
            }

            db.Entry(inmueble).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InmuebleExists(id))
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

        // POST: api/Inmuebles
        [ResponseType(typeof(Inmueble))]
        public async Task<IHttpActionResult> PostInmueble(Inmueble inmueble)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Inmuebles.Add(inmueble);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = inmueble.InmuebleID }, inmueble);
        }

        // DELETE: api/Inmuebles/5
        [ResponseType(typeof(Inmueble))]
        public async Task<IHttpActionResult> DeleteInmueble(int id)
        {
            Inmueble inmueble = await db.Inmuebles.FindAsync(id);
            if (inmueble == null)
            {
                return NotFound();
            }

            db.Inmuebles.Remove(inmueble);
            await db.SaveChangesAsync();

            return Ok(inmueble);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InmuebleExists(int id)
        {
            return db.Inmuebles.Count(e => e.InmuebleID == id) > 0;
        }
    }
}