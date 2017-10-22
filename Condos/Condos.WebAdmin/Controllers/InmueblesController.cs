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
    public class InmueblesController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        // GET: Inmuebles
        public async Task<ActionResult> Index()
        {
            var inmuebles = db.Inmuebles.Include(i => i.Condominio);
            return View(await inmuebles.ToListAsync());
        }

        // GET: Inmuebles/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inmueble inmueble = await db.Inmuebles.FindAsync(id);
            if (inmueble == null)
            {
                return HttpNotFound();
            }
            return View(inmueble);
        }

        // GET: Inmuebles/Create
        public ActionResult Create()
        {
            ViewBag.CondoID = new SelectList(db.Condominios, "CondoID", "Descripcion");
            return View();
        }

        // POST: Inmuebles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "InmuebleID,CondoID,Descripcion,EsPublico,Estado,Comentario")] Inmueble inmueble)
        {
            if (ModelState.IsValid)
            {
                db.Inmuebles.Add(inmueble);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CondoID = new SelectList(db.Condominios, "CondoID", "Descripcion", inmueble.CondoID);
            return View(inmueble);
        }

        // GET: Inmuebles/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inmueble inmueble = await db.Inmuebles.FindAsync(id);
            if (inmueble == null)
            {
                return HttpNotFound();
            }
            ViewBag.CondoID = new SelectList(db.Condominios, "CondoID", "Descripcion", inmueble.CondoID);
            return View(inmueble);
        }

        // POST: Inmuebles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "InmuebleID,CondoID,Descripcion,EsPublico,Estado,Comentario")] Inmueble inmueble)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inmueble).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CondoID = new SelectList(db.Condominios, "CondoID", "Descripcion", inmueble.CondoID);
            return View(inmueble);
        }

        // GET: Inmuebles/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inmueble inmueble = await db.Inmuebles.FindAsync(id);
            if (inmueble == null)
            {
                return HttpNotFound();
            }
            return View(inmueble);
        }

        // POST: Inmuebles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Inmueble inmueble = await db.Inmuebles.FindAsync(id);
            db.Inmuebles.Remove(inmueble);
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
