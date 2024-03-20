using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class UsuariosController : Controller
    {
        Sistema sistema = Sistema.Instancia;

       

        public IActionResult FormularioIngreso()
        {
            if (HttpContext.Session.GetString("rol") != null)
            {
                return RedirectToAction("Index", "Home");

            }
            return View();

        }

        public IActionResult ProcesarFormularioIngreso(string Email, string Contrasena, string Nombre, string Apellido, DateTime fecha)
        {
            if(HttpContext.Session.GetString("rol") != null)
            {
                return RedirectToAction("Index", "Home");

            }

            try
            {
                if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Contrasena) || string.IsNullOrEmpty(Nombre) || string.IsNullOrEmpty(Apellido))
                    throw new Exception("El campo no puede ser vacío!");

                if (!Email.Contains("@") || !Email.Any(char.IsLetter))
                    throw new Exception("El e-mail es inválido o vacío.");

                if (!Nombre.Any(char.IsLetter))
                    throw new Exception("El nombre no puede ser vacío o contener solo números.");

                if (!Apellido.Any(char.IsLetter))
                    throw new Exception("El apellido no puede ser vacío o contener solo números.");

                Miembro m = new Miembro(Email, Contrasena, Nombre, Apellido, fecha, true);
                sistema.AltaMiembro(m);

                ViewBag.Exito = "Miembro dado de alta!";
                return View("Login");

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("FormularioIngreso");
            }

        }

        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("rol") != null)
            {
                return RedirectToAction("Index", "Home");

            }
            return View();
        }


        public IActionResult ProcesarLogin(string email, string pass)
        {
            if (HttpContext.Session.GetString("rol") != null)
            {
                return RedirectToAction("Index", "Home");

            }

            try
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pass)) throw new Exception("Email o Contraseña inválida!");
                User u = sistema.Login(email, pass);
                if (u == null) throw new Exception("Email o contraseña incorrecta!");
                ViewBag.Exito = "Bienvenido!";

                // Variables de sesión
                HttpContext.Session.SetString("email", u.Email);
                HttpContext.Session.SetString("rol", u.Tipo());
                if (u.Tipo() == "Administrador")
                {
                    return RedirectToAction("Home", "Administradores");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
                
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Login");
            }
           
           
        }

        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("rol") == null)
            {
                return RedirectToAction("Login", "Usuarios");

            }

            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }


    }


}