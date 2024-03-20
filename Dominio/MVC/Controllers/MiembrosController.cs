using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class MiembrosController : Controller
    {
        Sistema sistema = Sistema.Instancia;

        public IActionResult Listado()
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") == "Administrador")
            {
                return RedirectToAction("Index", "Home");

            }

            if (TempData["Error"] != null) ViewBag.Error = TempData["Error"];
            if (TempData["Exito"] != null) ViewBag.Exito = TempData["Exito"];

            ViewBag.Listado = sistema.ListaUsers;

            return View();
        }

        public IActionResult ProcesarInvitacion(string email)
        {


            int ultimoID = sistema.RetornaUltimoID();

            try
            {
                
                Invitacion inv = new Invitacion(ultimoID, sistema.RetornaMiembroPorMail(HttpContext.Session.GetString("email")), sistema.RetornaMiembroPorMail(email));
                sistema.AltaInvitacion(inv);
                ViewBag.Exito = "Invitación enviada!";
                return View("Listado");

            }
            catch (Exception ex)
            {

                ViewBag.Erro = ex.Message;
                return View("Listado");
            }

        }

        public IActionResult ListadoInvitaciones()
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") == "Administrador")
            {
                return RedirectToAction("Index", "Home");

            }

            List<Invitacion> listaInvitaciones = sistema.RetornaInvitacionesPendientesMiembro(HttpContext.Session.GetString("email"));
            ViewBag.ListadoInv = listaInvitaciones;


            return View();
        }

        public IActionResult ProcesarAceptacion(int id)
        {
           
            try
            {
                Invitacion inv = sistema.RetornaIdInv(id);
                if (inv == null) throw new Exception("Invitación nula!");
                sistema.AceptarInvitacion(inv.IdInv, HttpContext.Session.GetString("email"));
                TempData["Exito"] = "Solicitud enviada con exito!";
                return View("Listado");

            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View("Listado");
            }



        }

        public IActionResult ProcesarRechazo(int id)
        {
            
            try
            {
                Invitacion inv = sistema.RetornaIdInv(id);
                if (inv == null) throw new Exception("Invitación nula!");
                sistema.RechazarInvitacion(inv.IdInv);
                ViewBag.Exito = "Solicitud Rechazada!";
                return View("Listado");

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Listado");
            }



        }


        public IActionResult FormularioPost()
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") == "Administrador")
            {
                return RedirectToAction("Index", "Home");

            }

            return View();
        }

        public IActionResult ProcesarFormularioPost(string tituloPubli, string contenido, IFormFile imagen, string tipoPost)
        {
            

            try
            {
              

                
                Miembro miembro = sistema.RetornaMiembroPorMail(HttpContext.Session.GetString("email"));
                if (!miembro.Status)
                {
                    ViewBag.Error = "Miembro bloqueado por el adm!";
                    return View("FormularioPost");
                }
                else
                {

                    Visibilidad visibilidadEnum;

                    if (tipoPost == "privado")
                    {
                        visibilidadEnum = Visibilidad.Privado;

                    }else if(tipoPost == "publico")
                    {
                        visibilidadEnum = Visibilidad.Publico;
                    }
                    else
                    {
                        throw new Exception("Visibilidad no válida!");
                    }
                    


                    if (imagen == null || imagen.Length == 0) throw new Exception("No se seleccionó archivo");
                    string ruta = "wwwroot/images/";


                    string tipo = imagen.ContentType;

                    string[] arraySplit = imagen.FileName.Split('.');
                    string extension = arraySplit[arraySplit.Length - 1];
                    string nombreSinExtension = String.Join(".", arraySplit.Take(arraySplit.Length - 1));

                    string nuevoNombre = $"{nombreSinExtension}.{extension}";


                   


                    //EN ESTE PUNTO TODAVIA NO SUBO EL ARCHIVO, PREPARO LA RUTA Y AGREGO EL NOMBRE DE LA IMAGEN A MI DISCO PARA QUE LO VALIDE
                    ruta += nuevoNombre;

                    // Creamos el stream que nos permite escribir archivos a la ruta dada (incluido el nombre del archivo)
                    using var stream = System.IO.File.Create(ruta);
                    // Subimos el archivo a la carpeta
                    imagen.CopyTo(stream);

                    Post post = new Post(tituloPubli, miembro, DateTime.Now.Date, contenido, visibilidadEnum, nuevoNombre, false);
                    sistema.AltaPost(post);
                    ViewBag.Exito = "Post creado!";
                    return View("FormularioPost");
                }

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("FormularioPost");
            }


        }
        public IActionResult ProcesarFormularioComentario(string titulo, string contenido, int postId)
        {
            try
            {
                Miembro miembro = sistema.RetornaMiembroPorMail(HttpContext.Session.GetString("email"));

                if (!miembro.Status)
                {
                    TempData["Error"] = "Miembro bloqueado por el adm!";
                    return RedirectToAction("ListadoPost", "Administradores");
                }
                else
                {
                    Comentario c = new Comentario(titulo, miembro, DateTime.Now, contenido, Visibilidad.Publico);
                    sistema.AltaComentario(c, postId);
                    TempData["Exito"] = "Comentario ingresado!";
                    return RedirectToAction("ListadoPost", "Administradores");
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("ListadoPost", "Administradores");
            }
        }



        public IActionResult AgregarLikeAPost(int id)
        {
           
            try
            {

                Miembro miembro = sistema.RetornaMiembroPorMail(HttpContext.Session.GetString("email"));
                Post p = sistema.RetornaPostPorId(id);
                Reaccion r = new Reaccion(ReaccionEnum.like, miembro);

                bool HayLike = sistema.HayLikeMiembro(miembro, p);
                if (!HayLike)
                {
                    p.AgregarReaccionAPost(r);


                }
                else
                {
                    TempData["Error"] = "Post ya tiene like!";
                }

                return RedirectToAction("ListadoPost", "Administradores");

            }
            catch (Exception ex)
            {
               ViewBag.Error = ex.Message;
                return RedirectToAction("ListadoPost", "Administradores");

            }


        }


        public IActionResult AgregarDislikeAPost(int id)
        {
            
            try
            {
                Miembro miembro = sistema.RetornaMiembroPorMail(HttpContext.Session.GetString("email"));
                Post p = sistema.RetornaPostPorId(id);
                Reaccion r = new Reaccion(ReaccionEnum.dislike, miembro);

                bool HayDislike = sistema.HayDislikeMiembro(miembro, p);

                if (!HayDislike)
                {
                    p.AgregarReaccionAPost(r);

                }
                else
                {
                    TempData["Error"] = "Post ya tiene dislike!";
                }

                return RedirectToAction("ListadoPost", "Administradores");

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return RedirectToAction("ListadoPost", "Administradores");

            }


        }


        public IActionResult AgregarLikeAComentario(int id)
        {
            
            try
            {
                Miembro miembro = sistema.RetornaMiembroPorMail(HttpContext.Session.GetString("email"));

                Comentario c = sistema.RetornaComentariosPorId(id);
                Reaccion r = new Reaccion(ReaccionEnum.like, miembro);
                bool HayLike = sistema.HayLikeMiembro(miembro, c);

                if (!HayLike)
                {
                    c.AgregarReaccionAComent(r);
                }
                else
                {
                    TempData["Error"] = "Comentario ya tiene like!";
                }   
                    
                return RedirectToAction("ListadoPost", "Administradores");

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return RedirectToAction("ListadoPost", "Administradores");

            }


        }

        public IActionResult AgregarDislikeAComentario(int id)
        {
            
            try
            {
                Miembro miembro = sistema.RetornaMiembroPorMail(HttpContext.Session.GetString("email"));

                Comentario c = sistema.RetornaComentariosPorId(id);
                Reaccion r = new Reaccion(ReaccionEnum.dislike, miembro);
                bool HayDislike = sistema.HayDislikeMiembro(miembro, c);

                if (!HayDislike)
                {
                    c.AgregarReaccionAComent(r);
                }
                else
                {
                    TempData["Error"] = "Comentario ya tiene dislike!";
                }

                return RedirectToAction("ListadoPost", "Administradores");

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return RedirectToAction("ListadoPost", "Administradores");

            }


        }

        public IActionResult FormularioBusquedaTexto()
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") == "Administrador")
            {
                return RedirectToAction("Index", "Home");

            }

            return View();
        }

        public IActionResult ProcesarFormularioBusquedaTexto(string texto, int numero)
        {
           

            ViewBag.Publicaciones = sistema.retornaPostsConTexto(texto, numero);
            
            return View("FormularioBusquedaTexto");
        }
    }
}