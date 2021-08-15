using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Proyecto_Progra.Models;
using Proyecto_Progra.Clase;

namespace Proyecto_Progra.Controllers
{
    public class IngresarController : Controller
    {
        // GET: Ingresar
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Usuario usuario, string url)
        {
            if (IsValid(usuario))
            {
                FormsAuthentication.SetAuthCookie(usuario.EMAIL, false);
                if (url != null)
                {
                    return Redirect(url);
                }
                return RedirectToAction("Index", "Home");
            }
            TempData["Mensaje"] = "Credenciales Incorrectas.";
            return View(usuario);
        }

        public bool IsValid(Usuario usuario)
        {
            return usuario.Autententicar();
        }
        public ActionResult LogOut(USUARIO usuario, string url)
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }

}
