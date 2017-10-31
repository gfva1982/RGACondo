using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Condos.Entities;
using Condos.WebAdmin.Models;

namespace Condos.WebAdmin.Controllers
{
    public class CalendarioZonasPublicasController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        // GET: CalendarioZonasPublicas
        public async Task<ActionResult> Index()
        {
            var calendarioZonasPublicas = db.CalendarioZonasPublicas.Include(c => c.Inmueble);
            return View(await calendarioZonasPublicas.ToListAsync());
        }

        // GET: CalendarioZonasPublicas/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalendarioZonasPublicas calendarioZonasPublicas = await db.CalendarioZonasPublicas.FindAsync(id);
            if (calendarioZonasPublicas == null)
            {
                return HttpNotFound();
            }
            return View(calendarioZonasPublicas);
        }

        // GET: CalendarioZonasPublicas/Create
        public ActionResult Create()
        {
            ViewBag.InmuebleID = new SelectList(db.Inmuebles, "InmuebleID", "Descripcion");
            return View();
        }

        // POST: CalendarioZonasPublicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ZonaPublicaID,InmuebleID,Fecha,HoraInicio,HoraFinal,Comentarios,Estado,UsuarioID")] CalendarioZonasPublicas calendarioZonasPublicas)
        {
            if (ModelState.IsValid)
            {
                db.CalendarioZonasPublicas.Add(calendarioZonasPublicas);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.InmuebleID = new SelectList(db.Inmuebles, "InmuebleID", "Descripcion", calendarioZonasPublicas.InmuebleID);
            return View(calendarioZonasPublicas);
        }

        // GET: CalendarioZonasPublicas/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalendarioZonasPublicas calendarioZonasPublicas = await db.CalendarioZonasPublicas.FindAsync(id);
            if (calendarioZonasPublicas == null)
            {
                return HttpNotFound();
            }
            ViewBag.InmuebleID = new SelectList(db.Inmuebles, "InmuebleID", "Descripcion", calendarioZonasPublicas.InmuebleID);
            return View(calendarioZonasPublicas);
        }

        // POST: CalendarioZonasPublicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ZonaPublicaID,InmuebleID,Fecha,HoraInicio,HoraFinal,Comentarios,Estado,UsuarioID")] CalendarioZonasPublicas calendarioZonasPublicas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calendarioZonasPublicas).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.InmuebleID = new SelectList(db.Inmuebles, "InmuebleID", "Descripcion", calendarioZonasPublicas.InmuebleID);
            return View(calendarioZonasPublicas);
        }

        // GET: CalendarioZonasPublicas/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalendarioZonasPublicas calendarioZonasPublicas = await db.CalendarioZonasPublicas.FindAsync(id);
            if (calendarioZonasPublicas == null)
            {
                return HttpNotFound();
            }
            return View(calendarioZonasPublicas);
        }

        // POST: CalendarioZonasPublicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            CalendarioZonasPublicas calendarioZonasPublicas = await db.CalendarioZonasPublicas.FindAsync(id);
            db.CalendarioZonasPublicas.Remove(calendarioZonasPublicas);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
