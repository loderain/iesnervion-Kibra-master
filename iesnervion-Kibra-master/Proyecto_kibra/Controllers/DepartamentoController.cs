using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaDal_kibra;
using Entidades;

namespace Proyecto_kibra.Controllers
{
    public class DepartamentoController : Controller
    {
        //
        // GET: /Departamento/

        /// <summary>
        /// Action que muestra el listado de departamentos
        /// </summary>
        /// <returns></returns>
        public ActionResult Listado()
        {
            DepartamentoDal helper = new DepartamentoDal();
            List<Departamento> listado = helper.getListaDepartamentos();
            return View(listado);
        }

        /// <summary>
        /// action que solicita la creacion de un departamento
        /// </summary>
        /// <returns></returns>
        public ActionResult Nuevo()
        {
            return View(new Departamento());
        }

        /// <summary>
        /// Action que almacena un departamento
        /// </summary>
        /// <param name="dep"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Nuevo(Departamento dep)
        {
            if (ModelState.IsValid)
            {
                DepartamentoDal helper = new DepartamentoDal();
                helper.guardarDepartamento(dep);
                return RedirectToAction("Listado");
            }
            else
            {

                return View(dep);
            }


        }

        /// <summary>
        /// Action que solicita la edicion de un departamento
        /// </summary>
        /// <returns></returns>
        public ActionResult Editar()
        {
            int id = Convert.ToInt32(Url.RequestContext.RouteData.Values["id"]);

            DepartamentoDal helper = new DepartamentoDal();
            Departamento dep = helper.getDepartamentoPorId(id);
            return View(dep);
        }


        /// <summary>
        /// Action que edita los datos de un departamento
        /// </summary>
        /// <param name="dep"></param>
        /// <returns></returns>

        [HttpPost]
        public ActionResult Editar(Departamento dep)
        {
            if (ModelState.IsValid)
            {

                Debug.WriteLine("modelo valido");
                DepartamentoDal helper = new DepartamentoDal();
                helper.modificarDepartamento(dep);
                return RedirectToAction("Listado");
            }
            else
            {
                Debug.WriteLine("modelo invalido");
                return View(dep);
            }
        }

        /// <summary>
        /// Action que muestra los detalles de un departamento
        /// </summary>
        /// <returns></returns>
        public ActionResult Detalles()
        {
            int id = Convert.ToInt32(Url.RequestContext.RouteData.Values["id"]);

            DepartamentoDal helper = new DepartamentoDal();
            Departamento dep = helper.getDepartamentoPorId(id);
            return View(dep);
        }


        /// <summary>
        /// Action que solicita eliminar un departamento
        /// </summary>
        /// <returns></returns>
        public ActionResult Eliminar()
        {
            int id = Convert.ToInt32(Url.RequestContext.RouteData.Values["id"]);

            DepartamentoDal helper = new DepartamentoDal();
            Departamento dep = helper.getDepartamentoPorId(id);
            return View(dep);

        }


        /// <summary>
        /// Action que confirma la eliminacion de un departamento
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Eliminar")]
        public ActionResult EliminarPost()
        {
            int id = Convert.ToInt32(Url.RequestContext.RouteData.Values["id"]);

            DepartamentoDal helper = new DepartamentoDal();
            Boolean res = helper.eliminarDepartamento(id);
            return RedirectToAction("Listado");

        }
    }
}
