using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_kibra.Models
{
    public class EmpleadoModel
    {
        public Empleado Empleado { get; set; }

        public List<Provincia> Provincias { get; set; }

        public Login login { get; set; }



        public List<Puesto> Puestos { get; set; }
        public int PuestoId { get; set; }
        public int DepartamentoId { get; set; }

        public List<Departamento> Departamentos { get; set; }

        public int ProvinciaId { get; set; }

        public int CiudadId { get; set; }

        public string usuario { get; set; }

        public string passwd { get; set; }
    }
}