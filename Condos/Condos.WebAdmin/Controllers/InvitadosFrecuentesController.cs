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
    public class InvitadosFrecuentesController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        // GET: InvitadosFrecuentes
        public async Task<ActionResult> Index()
        {
            var invitadosFrecuentes = db.InvitadosFrecuentes.Include(i => i.Usuario);
            return View(await invitadosFrecuentes.ToListAsync());
        }

        // GET: InvitadosFrecuentes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvitadosFrecuentes invitadosFrecuentes = await db.InvitadosFrecuentes.FindAsync(id);
            if (invitadosFrecuentes == null)
            {
                return HttpNotFound();
            }
            return View(invitadosFrecuentes);
        }

        // GET: InvitadosFrecuentes/Create
        public ActionResult Create()
        {
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "NombreUsuario");
            return View();
        }

        // POST: InvitadosFrecuentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "InvitadoFrecuenteID,UsuarioID,NombreInvitado,Identificacion,PlacaVehiculo")] InvitadosFrecuentes invitadosFrecuentes)
        {
            if (ModelState.IsValid)
            {
                db.InvitadosFrecuentes.Add(invitadosFrecuentes);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "NombreUsuario", invitadosFrecuentes.UsuarioID);
            return View(invitadosFrecuentes);
        }

        // GET: InvitadosFrecuentes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvitadosFrecuentes invitadosFrecuentes = await db.InvitadosFrecuentes.FindAsync(id);
            if (invitadosFrecuentes == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "NombreUsuario", invitadosFrecuentes.UsuarioID);
            return View(invitadosFrecuentes);
        }

        // POST: InvitadosFrecuentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "InvitadoFrecuenteID,UsuarioID,NombreInvitado,Identificacion,PlacaVehiculo")] InvitadosFrecuentes invitadosFrecuentes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invitadosFrecuentes).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "UsuarioID", "NombreUsuario", invitadosFrecuentes.UsuarioID);
            return View(invitadosFrecuentes);
        }

        // GET: InvitadosFrecuentes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvitadosFrecuentes invitadosFrecuentes = await db.InvitadosFrecuentes.FindAsync(id);
            if (invitadosFrecuentes == null)
            {
                return HttpNotFound();
            }
            return View(invitadosFrecuentes);
        }

        // POST: InvitadosFrecuentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            InvitadosFrecuentes invitadosFrecuentes = await db.InvitadosFrecuentes.FindAsync(id);
            db.InvitadosFrecuentes.Remove(invitadosFrecuentes);
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
