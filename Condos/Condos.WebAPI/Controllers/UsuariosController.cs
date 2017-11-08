using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Condos.Entities;
using Condos.WebAPI.Helpers;
using Condos.WebAPI.Models;

namespace Condos.WebAPI.Controllers
{
    public class UsuariosController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Usuarios
        public IQueryable<Usuario> GetUsuarios()
        {
            return db.Usuarios;
        }

        // GET: api/Usuarios/5
        [ResponseType(typeof(Usuario))]
        public async Task<IHttpActionResult> GetUsuario(int id)
        {
            Usuario usuario = await db.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpPost]
        [Route("api/CondoComentarios")]
        public  IHttpActionResult PostComentarios(ComentarioRequest pComentario)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (pComentario.ImageArray != null && pComentario.ImageArray.Length > 0)
                {
                    var stream = new MemoryStream(pComentario.ImageArray);
                    var guid = Guid.NewGuid().ToString();
                    var file = string.Format("{0}.jpg", guid);
                    var folder = "~/Content/Images";
                    var fullPath = string.Format("{0}/{1}", folder, file);

                    var response = FilesHelper.UploadPhoto(stream, folder, file);

                    if (response)
                    {
                        pComentario.FullPath = fullPath;

                        FilesHelper.EnviarComentarios(pComentario);
                    }
                }

                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        // GET: api/InfoUsuario/5
        [HttpGet]
        [ResponseType(typeof(Usuario))]
        [Route("api/InfoUsuario")]
        public async Task<IHttpActionResult> InfoUsuario(string NombreUsuario)
        {
            Usuario usuario = await db.Usuarios.FirstAsync(p=>p.NombreUsuario == NombreUsuario);
            if (usuario == null)
            {
                return NotFound();
            }


            var invitadosFrecuentesInfo = new List<InvitadosFrecuentesInfo>();
            foreach (var invitado in usuario.InvitadosFrecuentes)
            {
                invitadosFrecuentesInfo.Add(new InvitadosFrecuentesInfo {
                    Identificacion = invitado.Identificacion,
                    InvitadoFrecuenteID = invitado.InvitadoFrecuenteID,
                    NombreInvitado = invitado.NombreInvitado,
                    PlacaVehiculo = invitado.PlacaVehiculo,
                    UsuarioID = invitado.UsuarioID,
                    
                    
                });
            }

            var _usuarioInfo = new UsuarioInfo
            {
                Identificacion = usuario.Identificacion,
                DetalleInmueble = usuario.Inmueble.Descripcion,
                InmuebleID = usuario.InmuebleID,
                NombreCompleto = usuario.NombreCompleto,
                NombreUsuario = usuario.NombreUsuario,
                PrimerApellido = usuario.PrimerApellido,
                SegundoApellido = usuario.SegundoApellido,
                TelefonoEmergencia = usuario.TelefonoEmergencia,
                UsuarioID = usuario.UsuarioID,
                IdCondo = usuario.Inmueble.CondoID,
                DescripcionCondo = usuario.Inmueble.Condominio.Descripcion,
                ListaInvitadosFrecuentes = invitadosFrecuentesInfo
                
            };

            return Ok(_usuarioInfo);
        }

        // PUT: api/Usuarios/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuario.UsuarioID)
            {
                return BadRequest();
            }

            db.Entry(usuario).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        // POST: api/Usuarios
        [ResponseType(typeof(Usuario))]
        public async Task<IHttpActionResult> PostUsuario(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Usuarios.Add(usuario);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = usuario.UsuarioID }, usuario);
        }

        // DELETE: api/Usuarios/5
        [ResponseType(typeof(Usuario))]
        public async Task<IHttpActionResult> DeleteUsuario(int id)
        {
            Usuario usuario = await db.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            db.Usuarios.Remove(usuario);
            await db.SaveChangesAsync();

            return Ok(usuario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuarioExists(int id)
        {
            return db.Usuarios.Count(e => e.UsuarioID == id) > 0;
        }
    }
}