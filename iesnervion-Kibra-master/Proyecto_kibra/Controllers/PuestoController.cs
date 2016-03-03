using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaDal_kibra;
using Entidades;

namespace Proyecto_kibra.Controllers
{
    public class PuestoController : Controller
    {
        //
        // GET: /Puesto/

        public ActionResult Listado()
        {
            PuestoDal helper = new PuestoDal();
            List<Puesto> listado = helper.getListaPuestos();
            return View(listado);
        }


        public ActionResult Nuevo()
        {
            return View(new Puesto());
        }


        [HttpPost]
        public ActionResult Nuevo(Puesto p)
        {
            if (ModelState.IsValid)
            {
                PuestoDal helper = new PuestoDal();
                helper.guardarPuesto(p);
                return RedirectToAction("Listado");
            }
            else
            {
                return View(p);
            }
        }

        public ActionResult Editar()
        {
            int id = Convert.ToInt32(Url.RequestContext.RouteData.Values["id"]);
            PuestoDal helper = new PuestoDal();
            Puesto p=helper.getPuestoPorId(id);
            return View(p);
        }

        [HttpPost]
        public ActionResult Editar(Puesto p)
        {
            if (ModelState.IsValid)
            {
                PuestoDal helper = new PuestoDal();
                helper.modificarPuesto(p);
                return RedirectToAction("Listado");
            }
            else
            {
                return View(p);
            }
        }


        public ActionResult Eliminar()
        {
            int id = Convert.ToInt32(Url.RequestContext.RouteData.Values["id"]);
            PuestoDal helper = new PuestoDal();
            Puesto p = helper.getPuestoPorId(id);
            return View(p);
        }


        [HttpPost]
        [ActionName("Eliminar")]
        public ActionResult EliminarPort(){


            int id = Convert.ToInt32(Url.RequestContext.RouteData.Values["id"]);
            PuestoDal helper = new PuestoDal();
             helper.eliminarPuesto(id);
            return RedirectToAction("Listado");

        }

        public ActionResult Detalles()
        {
            int id = Convert.ToInt32(Url.RequestContext.RouteData.Values["id"]);
            PuestoDal helper = new PuestoDal();
            Puesto p = helper.getPuestoPorId(id);
            return View(p);
        }

    }
}
