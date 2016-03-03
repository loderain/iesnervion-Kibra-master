using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
/* Su tabla es:
    Create Table Ciudades(
	idCiudad integer,
	nombreCiu varchar(80),
	provincia Integer,
	CONSTRAINT PK_Ciudades PRIMARY KEY(idCiudad),	
	constraint FK_Ciudades_Provincias foreign key (provincia) references provincias(idProvincia))
*/


namespace Entidades
{
    public class Ciudad
    {
        public Ciudad()
        {

        }
        public Ciudad(Int32 idC,string nC, Provincia p)
        {
            _IdCiudad = idC;
            _NombreCiu = nC;
            _Provincia = p;
        }


        private int _IdCiudad;
        public int IdCiudad
        {
            get 
            {
                return _IdCiudad; 
            } 
        
            set 
            {
                _IdCiudad = value;
            }
        }

        [StringLength(80)]
        private string _NombreCiu;
        public string NombreCiu
        {
            get
            {
                return _NombreCiu;
            }

            set
            {
                _NombreCiu = value;
            }
        }

        private Provincia _Provincia;
        public Provincia Provincia
        {
            get
            {
                return _Provincia;
            }

            set
            {
                _Provincia = value;
            }
        }
    }
}
