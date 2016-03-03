using System.ComponentModel.DataAnnotations;
/*
Create table Privilegios (
	idPrivilegio integer identity,
	nombrePriv varchar(80) not null,
	descPriv varchar(150) not null,
	valorPriv integer not null, 
	CONSTRAINT PK_Privilegios PRIMARY KEY (idPrivilegio)
)
*/
namespace Entidades
{
    public class Privilegio
    {
        #region "Campos privados y propiedades publicas"

        private int _IdPrivilegio;
        public int IdPrivilegio
        {
            get
            {
                return _IdPrivilegio;
            }

            set
            {
                _IdPrivilegio = value;
            }
        }

        [StringLength(80)]
        private string _NombrePriv;
        public string NombrePriv
        {
            get
            {
                return _NombrePriv;
            }

            set
            {
                _NombrePriv = value;
            }
        }

        [StringLength(150)]
        private string _DescPriv;
        public string DescPriv
        {
            get
            {
                return _DescPriv;
            }

            set
            {
                _DescPriv = value;
            }
        }

        private int _ValorPriv;
        public int ValorPriv
        {
            get
            {
                return _ValorPriv;
            }
            set
            {
                _ValorPriv = value;
            }
        }

        #endregion

        #region "Constructores"

        public Privilegio() { }

        public Privilegio(int idPrivilegio, string nombrePriv, string descPriv,int valorPriv)
        {
            _IdPrivilegio = idPrivilegio;
            _NombrePriv = nombrePriv;
            _DescPriv = descPriv;
            _ValorPriv = valorPriv;
        }

        #endregion
    }
}
