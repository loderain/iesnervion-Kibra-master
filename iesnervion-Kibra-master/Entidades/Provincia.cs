using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

/* Su tabla es: 
    Create Table Provincias(
	idProvincia integer,
	nombreProv varchar(80),
	CONSTRAINT PK_Provincias PRIMARY KEY(idProvincia))
 */

namespace Entidades
{
    public class Provincia
    {
        private int _IdProvincia;

        public int IdProvincia
        {
            get 
            {
                return _IdProvincia; 
            } 
        
            set 
            {
                _IdProvincia = value;
            }
        }




        [StringLength(80)]
        private String _NombreProv;

        public String NombreProv
        {
            get 
            { 
                return _NombreProv; 
            }
            set
            {
                _NombreProv = value;
            }
        }

        

        public Provincia() { }

        public Provincia(int id, String nom)
        {
            _IdProvincia = id;
            _NombreProv = nom;
        }
    }
}
