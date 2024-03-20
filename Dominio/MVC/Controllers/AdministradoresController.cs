using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class AdministradoresController : Controller
    {
        Sistema sistema = Sistema.Instancia;

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult ListarMiembros()
        {
            return RedirectToAction("Listado");
        }

        public IActionResult Listado()
        {
            
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") == "Miembro")
            {
                return RedirectToAction("Index", "Home");

            }

            List<Miembro> miembros = sistema.RetornaSoloMiembros(); // Retorna solo los users de tipo miembro
            {

                miembros.Sort(); // Ordenamos antes de pasar a la ViewBag

                ViewBag.Listado = miembros;


                return View();
            }
        }

        public IActionResult ProcesarBloqueo(string email)
        {
            try
            {

                if (string.IsNullOrEmpty(email)) throw new Exception("El mail no puede estar vacio!");
                Miembro m = sistema.RetornaMiembroPorMail(email);
               string mailUserLogueado = HttpContext.Session.GetString("email");

                Administrador adm = sistema.RetornaAdmPorMail(mailUserLogueado);
                adm.BloquearMiembro(m);

                return RedirectToAction("Listado");

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return RedirectToAction("Listado");
            }


        }



        public IActionResult ProcesarDesBloqueo(string email)
        {
            try
            {

                if (string.IsNullOrEmpty(email)) throw new Exception("El mail no puede estar vacio!");
                Miembro m = sistema.RetornaMiembroPorMail(email);
                string mailUserLogueado = HttpContext.Session.GetString("email"); // Guardando en la variable el mail del user logueado en la app

                Administrador adm = sistema.RetornaAdmPorMail(mailUserLogueado); // Buscando en sistema el user ADM
                adm.desBloquearMiembro(m);

                return RedirectToAction("Listado");

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return RedirectToAction("Listado");
            }

        }

        public IActionResult ListadoPost()
        {
            if (HttpContext.Session.GetString("rol") == null)
            {
                return RedirectToAction("Index", "Home");

            }

            if (TempData["Error"] != null) ViewBag.Error = TempData["Error"];
            ViewBag.Posts = sistema.ListaPost;

            return View();
        }

        public IActionResult ListarPosts()
        {
            return RedirectToAction("ListadoPost");
        }

        public IActionResult ProcesarBanear(int id)
        {
            try
            {

                Post p = sistema.RetornaPostPorId(id);
                if (p == null) throw new Exception("Post no encontrado!");
                string mailUserLogueado = HttpContext.Session.GetString("email"); // Guardando en la variable el mail del user logueado en la app
                Administrador adm = sistema.RetornaAdmPorMail(mailUserLogueado); // Buscando en sistema el user ADM
                adm.CensuraPost(p);
                return RedirectToAction("ListadoPost");

            }

            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return RedirectToAction("ListadoPost");
            }

           
        }


        public IActionResult ProcesarDesbloqueoBanear(int id)
        {
            try
            {

                Post p = sistema.RetornaPostPorId(id);
                if (p == null) throw new Exception("Post no encontrado!");
                string mailUserLogueado = HttpContext.Session.GetString("email"); // Guardando en la variable el mail del user logueado en la app
                Administrador adm = sistema.RetornaAdmPorMail(mailUserLogueado); // Buscando en sistema el user ADM
                adm.DesbloquearPost(p);
                return RedirectToAction("ListadoPost");

            }

            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return RedirectToAction("ListadoPost");
            }

            
        }


        public IActionResult BusquedaUsuario()
        {
            if (HttpContext.Session.GetString("rol") == null || HttpContext.Session.GetString("rol") == "Miembro")
            {
                return RedirectToAction("Index", "Home");

            }

            return View();
        }

        public IActionResult ProcesarBusquedaUsuario(string texto)
        {
            ViewBag.Usuarios = sistema.retornaUsuarioConTexto(texto);
            return View("BusquedaUsuario");

        }


    }
}