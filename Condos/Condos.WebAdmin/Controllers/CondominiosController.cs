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
    public class CondominiosController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        // GET: Condominios
        public async Task<ActionResult> Index()
        {
            return View(await db.Condominios.Where(x => x.Estado == true).ToListAsync());
        }

        // GET: Condominios/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condominio condominio = await db.Condominios.FindAsync(id);
            if (condominio == null)
            {
                return HttpNotFound();
            }
            return View(condominio);
        }

        // GET: Condominios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Condominios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CondoID,Descripcion,Estado,Ubicacion")] Condominio condominio)
        {
            if (ModelState.IsValid)
            {
                db.Condominios.Add(condominio);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(condominio);
        }

        // GET: Condominios/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condominio condominio = await db.Condominios.FindAsync(id);
            if (condominio == null)
            {
                return HttpNotFound();
            }
            return View(condominio);
        }

        // POST: Condominios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CondoID,Descripcion,Estado,Ubicacion")] Condominio condominio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(condominio).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(condominio);
        }

        // GET: Condominios/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condominio condominio = await db.Condominios.FindAsync(id);
            if (condominio == null)
            {
                return HttpNotFound();
            }
            return View(condominio);
        }

        // POST: Condominios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Condominio condominio = await db.Condominios.FindAsync(id);
            db.Condominios.Remove(condominio);
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
