using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Entidades;



namespace Proyecto_kibra.Models
{
    /// <summary>
    /// Modelo usado por la vista login
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// objeto login para inicializar los datos del usuario
        /// </summary>
        [Required]
        public Login login{ get; set; }

        /// <summary>
        /// Mensaje de error en caso de que el login no sea correcto.
        /// </summary>
        public String ErrorMessage { get; set; }

    }
}