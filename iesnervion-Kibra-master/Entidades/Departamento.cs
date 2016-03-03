using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
  Create table Departamentos(
	idDepartamento integer identity,
	nombreDep varchar(80) not null,
	descDep varchar(150) not null,
	telefono varchar(12) not null,
	CONSTRAINT PK_Departamentos PRIMARY KEY (idDepartamento))
*/
namespace Entidades
{
    public class Departamento
    {
        public Departamento() { }

        public Departamento(int idDep, String nomDep, String descDep, String telDep)
        {
            _IdDepartamento = idDep;
            _NombreDep = nomDep;
            _DescDep = descDep;
            _Telefono = telDep;
        }

        private int _IdDepartamento;
        public int IdDepartamento
        {
            get
            {
                return _IdDepartamento;
            }
            set
            {
                _IdDepartamento = value;
            }
        }


        private String _NombreDep;
        [StringLength(80)]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [DisplayName("Nombre")]
        public String NombreDep
        {
            get
            {
                return _NombreDep;
            }
            set
            {
                _NombreDep = value;
            }
        }


        private String _DescDep;
        [StringLength(150)]
        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [DisplayName("Descripción")]
        public String DescDep
        {
            get
            {
                return _DescDep;
            }
            set
            {
                _DescDep = value;
            }
        }


        private String _Telefono;
        [StringLength(12)]
        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [DisplayName("Teléfono")]
        public String Telefono
        {
            get
            {
                return _Telefono;
            }
            set
            {
                _Telefono = value;
            }
        }
    }
}
