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
    public class InvitadosFrecuentesCustomController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/InvitadosFrecuentesCustom
        public IQueryable<InvitadosFrecuentes> GetInvitadosFrecuentes()
        {
            return db.InvitadosFrecuentes;
        }

        // GET: api/InvitadosFrecuentesCustom/5
        [ResponseType(typeof(InvitadosFrecuentes))]
        public async Task<IHttpActionResult> GetInvitadosFrecuentes(int id)
        {
            InvitadosFrecuentes invitadosFrecuentes = await db.InvitadosFrecuentes.FindAsync(id);
            if (invitadosFrecuentes == null)
            {
                return NotFound();
            }

            return Ok(invitadosFrecuentes);
        }

        // PUT: api/InvitadosFrecuentesCustom/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutInvitadosFrecuentes(int id, InvitadosFrecuentes invitadosFrecuentes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != invitadosFrecuentes.InvitadoFrecuenteID)
            {
                return BadRequest();
            }

            db.Entry(invitadosFrecuentes).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvitadosFrecuentesExists(id))
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

        // POST: api/InvitadosFrecuentesCustom
        [ResponseType(typeof(InvitadosFrecuentes))]
        public async Task<IHttpActionResult> PostInvitadosFrecuentes(InvitadosFrecuentes invitadosFrecuentes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.InvitadosFrecuentes.Add(invitadosFrecuentes);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = invitadosFrecuentes.InvitadoFrecuenteID }, invitadosFrecuentes);
        }

        // DELETE: api/InvitadosFrecuentesCustom/5
        [ResponseType(typeof(InvitadosFrecuentes))]
        public async Task<IHttpActionResult> DeleteInvitadosFrecuentes(int id)
        {
            InvitadosFrecuentes invitadosFrecuentes = await db.InvitadosFrecuentes.FindAsync(id);
            if (invitadosFrecuentes == null)
            {
                return NotFound();
            }

            db.InvitadosFrecuentes.Remove(invitadosFrecuentes);
            await db.SaveChangesAsync();

            return Ok(invitadosFrecuentes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InvitadosFrecuentesExists(int id)
        {
            return db.InvitadosFrecuentes.Count(e => e.InvitadoFrecuenteID == id) > 0;
        }
    }
}