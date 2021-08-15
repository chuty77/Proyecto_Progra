using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_Progra.Clase;
using Proyecto_Progra.Models;

namespace Proyecto_Progra.Controllers
{
    public class UsuarioController : Controller
    {
        Usuario us = new Usuario();
        // GET: Registrarse
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Mostrar()
        {
            IEnumerable<USUARIO> lst = us.Consultar();
            return View(lst);
        }

        public ActionResult Guardar()
        {
            ViewBag.Mensaje = "";
            return View();
        }

        public ActionResult Nuevo(USUARIO modelo)
        {
            us.Guardar(modelo);
            ViewBag.Mensaje = "El usuario se guardo correctamente";
            return View("Guardar",modelo);
        }

        public ActionResult Detalle(int id)
        {
            USUARIO modelo = us.Consultar(id);
            return View(modelo);
        }
        public ActionResult Modificar(int id)
        {
            USUARIO modelo = us.Consultar(id);
            return View(modelo);
        }

        public ActionResult Cambiar(USUARIO modelo)
        {

            us.Modificar(modelo);
            ViewBag.Mensaje = "El empleado fue modificado correctamente";
            return View("Modificar", modelo);
        }

        public ActionResult Eliminar(int id)
        {

            USUARIO modelo = new USUARIO()
            {
                ID_USUARIO = id
            };
            us.Eliminar(modelo);
            IEnumerable<USUARIO> lst = us.Consultar();
            return View("Mostrar", lst);
        }
    }
}


