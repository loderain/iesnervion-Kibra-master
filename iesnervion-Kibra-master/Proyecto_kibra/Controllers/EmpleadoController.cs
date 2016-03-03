﻿using System;
﻿using Proyecto_kibra.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using CapaDal_kibra;
using System.Diagnostics;

namespace Proyecto_kibra.Controllers
{
    public class EmpleadoController : Controller
    {
        //
        // GET: /Empleado/

        public ActionResult Detalles(int id)
        {
            Empleado empleado;
            
                
           
                EmpleadoDal helper = new EmpleadoDal();
                empleado = helper.getEmpleadoPorId(id);
          

            return View(empleado);
        }

        public ActionResult Nuevo()
        {
            EmpleadoModel modelo = new EmpleadoModel();

            modelo.Empleado = new Empleado();
                        

            ProvinciaDal helperProvincia = new ProvinciaDal();
            modelo.Provincias = helperProvincia.getListaProvincias();

            PuestoDal helperPuesto = new PuestoDal();
            modelo.Puestos = helperPuesto.getListaPuestos();

            DepartamentoDal helperDepartamento = new DepartamentoDal();
            modelo.Departamentos = helperDepartamento.getListaDepartamentos();
            
            return View(modelo);
        }

        [HttpPost]
        public ActionResult Nuevo(EmpleadoModel modelo,Int32 ciudad)
        {
            if (ModelState.IsValid)
            {

                modelo.Empleado.CiudadEmp = new Ciudad();
                modelo.Empleado.CiudadEmp.IdCiudad = ciudad;
                Debug.WriteLine("ciudad " + ciudad);
                modelo.Empleado.DepartamentoEmp = new Departamento();
                modelo.Empleado.DepartamentoEmp.IdDepartamento = modelo.DepartamentoId;

                modelo.Empleado.PuestoEmp = new Puesto();
                modelo.Empleado.PuestoEmp.IdPuesto = modelo.PuestoId;

                EmpleadoDal helper = new EmpleadoDal();
                int nuevaId=helper.guardarEmpleado(modelo.Empleado);


                Login nuevoLogin = new Login();
                nuevoLogin.Empleado = new Empleado();
                nuevoLogin.Empleado.IdEmpleado = nuevaId;
                nuevoLogin.Usuario = modelo.usuario;
                nuevoLogin.Passwd = modelo.passwd;
                nuevoLogin.UltimoAcceso = DateTime.Now;

               

                LoginDal helperLogin = new LoginDal();
                helperLogin.guardarLogin(nuevoLogin);
                return RedirectToAction("Listado");
            }
            else
            {

                ProvinciaDal helperProvincia = new ProvinciaDal();
                modelo.Provincias = helperProvincia.getListaProvincias();

                PuestoDal helperPuesto = new PuestoDal();
                modelo.Puestos = helperPuesto.getListaPuestos();

                
                DepartamentoDal helperDepartamento = new DepartamentoDal();
                modelo.Departamentos = helperDepartamento.getListaDepartamentos();
                return View(modelo);
            }


            
        }


        public ActionResult Listado()
        {
            EmpleadoDal helper = new EmpleadoDal();
            List<Empleado> listado = helper.getListaEmpleados();
            return View(listado);
        }


        [HttpPost]
        public PartialViewResult listaCiudades(string idprov)
        {
            Response.AppendHeader("Content-Type", "text/xml");
            Debug.WriteLine("provincia " + idprov);
            CiudadDal helper = new CiudadDal();
            System.Collections.Generic.List<Ciudad> lista = helper.getListaPorProvincia(Convert.ToInt32(idprov));

            return PartialView(lista);
        }


        public ViewResult Editar()
        {
            int id = Convert.ToInt32(Url.RequestContext.RouteData.Values["id"]);

            EmpleadoDal helper = new EmpleadoDal();
            Empleado emp = helper.getEmpleadoPorId(id);
            return View(emp);
        }

    }
}
