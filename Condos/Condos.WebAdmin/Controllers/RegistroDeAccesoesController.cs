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
    public class RegistroDeAccesoesController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        // GET: RegistroDeAccesoes
        public async Task<ActionResult> Index()
        {
            var registroDeAccesoes = db.RegistroDeAccesoes.Include(r => r.Condominio);
            return View(await registroDeAccesoes.ToListAsync());
        }

        // GET: RegistroDeAccesoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroDeAcceso registroDeAcceso = await db.RegistroDeAccesoes.FindAsync(id);
            if (registroDeAcceso == null)
            {
                return HttpNotFound();
            }
            return View(registroDeAcceso);
        }

        // GET: RegistroDeAccesoes/Create
        public ActionResult Create()
        {
            ViewBag.CondoID = new SelectList(db.Condominios, "CondoID", "Descripcion");
            return View();
        }

        // POST: RegistroDeAccesoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "RegistroID,CondoID,NombreInvitado,Identificacion,PlacaVehiculo,FechaAcceso,DescripcionInmueble,FechaIngreso,NombreAutoriza,UsuarioValidaAcceso,Comentarios,FechaSalida")] RegistroDeAcceso registroDeAcceso)
        {
            if (ModelState.IsValid)
            {
                db.RegistroDeAccesoes.Add(registroDeAcceso);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CondoID = new SelectList(db.Condominios, "CondoID", "Descripcion", registroDeAcceso.CondoID);
            return View(registroDeAcceso);
        }

        // GET: RegistroDeAccesoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroDeAcceso registroDeAcceso = await db.RegistroDeAccesoes.FindAsync(id);
            if (registroDeAcceso == null)
            {
                return HttpNotFound();
            }
            ViewBag.CondoID = new SelectList(db.Condominios, "CondoID", "Descripcion", registroDeAcceso.CondoID);
            return View(registroDeAcceso);
        }

        // POST: RegistroDeAccesoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "RegistroID,CondoID,NombreInvitado,Identificacion,PlacaVehiculo,FechaAcceso,DescripcionInmueble,FechaIngreso,NombreAutoriza,UsuarioValidaAcceso,Comentarios,FechaSalida")] RegistroDeAcceso registroDeAcceso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registroDeAcceso).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CondoID = new SelectList(db.Condominios, "CondoID", "Descripcion", registroDeAcceso.CondoID);
            return View(registroDeAcceso);
        }

        // GET: RegistroDeAccesoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroDeAcceso registroDeAcceso = await db.RegistroDeAccesoes.FindAsync(id);
            if (registroDeAcceso == null)
            {
                return HttpNotFound();
            }
            return View(registroDeAcceso);
        }

        // POST: RegistroDeAccesoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RegistroDeAcceso registroDeAcceso = await db.RegistroDeAccesoes.FindAsync(id);
            db.RegistroDeAccesoes.Remove(registroDeAcceso);
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
