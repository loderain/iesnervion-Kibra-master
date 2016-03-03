/*
create table Puestos(
	idPuesto integer identity,
	nombrePue varchar(80) not null,
	descPue varchar(150) not null,
	salario money,
	constraint PK_Puestos primary key(idPuesto))
*/
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Puesto
    {
        #region "Campos privados y propiedades públicas"

        private int _IdPuesto;
        public int IdPuesto
        {
            get
            {
                return _IdPuesto;
            }

            set
            {
                _IdPuesto = value;
            }
        }

        
        private string _NombrePue;
        [StringLength(80)]
        [Required(ErrorMessage="El nombre es obligatorio")]
        public string NombrePue
        {
            get
            {
                return _NombrePue;
            }

            set
            {
                _NombrePue = value;
            }
        }

        
        private string _DescPue;
        [StringLength(150)]
        [Required(ErrorMessage = "La descripcion es obligatoria")]
        public string DescPue
        {
            get
            {
                return _DescPue;
            }

            set
            {
                _DescPue = value;
            }
        }

        [DataType(DataType.Currency)]
        private double _Salario;

        public double Salario
        {
            get
            {
                return _Salario;
            }

            set
            {
                _Salario = value;
            }
        }

        #endregion

        #region "Constructores"

        public Puesto() { }

        public Puesto(int idPuesto, string nombrePue, string descPue, double salario)
        {
            _IdPuesto = idPuesto;
            _NombrePue = nombrePue;
            _DescPue = descPue;
            _Salario = salario;
        }

        #endregion
    }
}
