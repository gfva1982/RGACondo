using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Condos.Entities;

namespace Condos.WebAPI.Controllers
{
    public class CalendarioZonasPublicasController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/CalendarioZonasPublicas
        public IQueryable<CalendarioZonasPublicas> GetCalendarioZonasPublicas()
        {
            return db.CalendarioZonasPublicas;
        }

        // GET: api/CalendarioZonasPublicas/5
        [ResponseType(typeof(CalendarioZonasPublicas))]
        public async Task<IHttpActionResult> GetCalendarioZonasPublicas(long id)
        {
            CalendarioZonasPublicas calendarioZonasPublicas = await db.CalendarioZonasPublicas.FindAsync(id);
            if (calendarioZonasPublicas == null)
            {
                return NotFound();
            }

            return Ok(calendarioZonasPublicas);
        }

        // PUT: api/CalendarioZonasPublicas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCalendarioZonasPublicas(long id, CalendarioZonasPublicas calendarioZonasPublicas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != calendarioZonasPublicas.ZonaPublicaID)
            {
                return BadRequest();
            }

            db.Entry(calendarioZonasPublicas).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalendarioZonasPublicasExists(id))
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

        // POST: api/CalendarioZonasPublicas
        [ResponseType(typeof(CalendarioZonasPublicas))]
        public async Task<IHttpActionResult> PostCalendarioZonasPublicas(CalendarioZonasPublicas calendarioZonasPublicas)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                db.CalendarioZonasPublicas.Add(calendarioZonasPublicas);
                await db.SaveChangesAsync();

                return  CreatedAtRoute("DefaultApi", new { id = calendarioZonasPublicas.ZonaPublicaID }, calendarioZonasPublicas);
            }
            catch (System.Exception _ex)
            {

               return BadRequest(_ex.Message);
            }
        }

        // DELETE: api/CalendarioZonasPublicas/5
        [ResponseType(typeof(CalendarioZonasPublicas))]
        public async Task<IHttpActionResult> DeleteCalendarioZonasPublicas(long id)
        {
            CalendarioZonasPublicas calendarioZonasPublicas = await db.CalendarioZonasPublicas.FindAsync(id);
            if (calendarioZonasPublicas == null)
            {
                return NotFound();
            }

            db.CalendarioZonasPublicas.Remove(calendarioZonasPublicas);
            await db.SaveChangesAsync();

            return Ok(calendarioZonasPublicas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CalendarioZonasPublicasExists(long id)
        {
            return db.CalendarioZonasPublicas.Count(e => e.ZonaPublicaID == id) > 0;
        }
    }
}