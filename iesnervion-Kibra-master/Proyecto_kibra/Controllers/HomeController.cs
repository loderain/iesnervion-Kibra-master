using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaDal_kibra;
using Entidades;
using Proyecto_kibra.Models;

namespace Proyecto_kibra.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        /// <summary>
        /// Pagina Inicial(Login)
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ActionResult res;
            if (Session["usuario"] == null)
            {
                res = View(new LoginModel());
            }
            else
            {
                res = RedirectToAction("Home");
            }
            return res;
        }

        /// <summary>
        /// Action del login una vez se han facilitado los datos de acceso
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(LoginModel l)
        {
            Login log;
            ActionResult actRes;
            LoginDal helper = new LoginDal();
            try
            {
                log = helper.getLogin(l.login.Usuario, l.login.Passwd);
                if (log == null)
                {
                    l.ErrorMessage = "Error. nombre de usuario o password no validos.";
                    actRes = View(l);

                }
                else
                {

                    //creamos el objeto de sesion
                    Session["usuario"] = log;
                    actRes = RedirectToAction("Home");
                }
            }
            catch (SqlException e)
            {

                l.ErrorMessage = "Problemas al conectar a la bbdd. " + e.Message;
                actRes = View(l);
            }
            catch (InvalidOperationException e)
            {

                l.ErrorMessage = "Problemas al conectar a la bbdd. " + e.Message;
                actRes = View(l);
            }
            return actRes;
        }

        /// <summary>
        /// Pagina Principal del erp.
        /// </summary>
        /// <returns> Si la sesion no existe, se redirecciona al login. En caso contrario muestra la pagina principal.</returns>
        public ActionResult Home()
        {
            ActionResult res;
            if (Session["usuario"] == null)
            {
                res = RedirectToAction("Index");
            }
            else
            {
                res = View();
            }
            return res;
        }

        /// <summary>
        ///  Action para cierre de sesión
        /// </summary>
        /// <returns> Al destruir la session redirecciona a la pagina de login</returns>
        public ActionResult CerrarSession()
        {
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Index");
        }

    }
    
}
