using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Condos.Entities;
using Condos.WebAdmin.Models;
using System.Linq;
using Condos.WebAdmin.Helpers;
using System;

namespace Condos.WebAdmin.Controllers
{
    
    public class InmueblesController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        // GET: Inmuebles
        public async Task<ActionResult> Index()
        {
            var inmuebles = db.Inmuebles.Include(i => i.Condominio);
            return View(await inmuebles.Where(x => x.Estado == true).ToListAsync());
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
            ViewBag.CondoID = new SelectList(db.Condominios.Where(px=>px.Estado == true), "CondoID", "Descripcion");
            return View();
        }

        // POST: Inmuebles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create( InmuebleView view)
        {
            if (ModelState.IsValid)
            {
                var pic = string.Empty;
                var folder = "~/Content/Images";

                if (view.ImagenFile != null)
                {
                    pic = FilesHelper.UploadPhoto(view.ImagenFile, folder);
                    pic = string.Format("{0}/{1}", folder, pic);
                }

                var inmueble = ToInmueble(view);

                inmueble.Image = pic;
                db.Inmuebles.Add(inmueble);

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CondoID = new SelectList(db.Condominios, "CondoID", "Descripcion", view.CondoID);
            return View(view);
        }

        private Inmueble ToInmueble(InmuebleView view)
        {
            return new Inmueble
            {
                Comentario = view.Comentario,
                CondoID = view.CondoID,
                Condominio = view.Condominio,
                Descripcion = view.Descripcion,
                EsPublico = view.EsPublico,
                Estado = view.Estado,
                Image = view.Image,
                InmuebleID = view.InmuebleID
            };
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

            var view = ToView(inmueble);

            

            ViewBag.CondoID = new SelectList(db.Condominios, "CondoID", "Descripcion", inmueble.CondoID);
            return View(view);
        }

        // POST: Inmuebles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit( InmuebleView view)
        {
            if (ModelState.IsValid)
            {
                
                var pic = view.Image;
                var folder = "~/Content/Images";

                if (view.ImagenFile != null)
                {
                    pic = FilesHelper.UploadPhoto(view.ImagenFile, folder);
                    pic = string.Format("{0}/{1}", folder, pic);
                }

                var inmuble = ToInmueble(view);

                inmuble.Image = pic;

                db.Entry(inmuble).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CondoID = new SelectList(db.Condominios, "CondoID", "Descripcion", view.CondoID);
            return View(view);
        }

      
        private InmuebleView ToView(Inmueble inmueble)
        {
            return new InmuebleView
            {
                Comentario = inmueble.Comentario,
                CondoID = inmueble.CondoID,
                Condominio = inmueble.Condominio,
                Descripcion = inmueble.Descripcion,
                EsPublico = inmueble.EsPublico,
                Estado = inmueble.Estado,
                Image = inmueble.Image,
                InmuebleID = inmueble.InmuebleID,
                
            };
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
