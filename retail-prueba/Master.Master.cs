using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace retail_prueba
{
    public partial class Mater : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BtnLogin.ImageUrl = "https://thumbs.dreamstime.com/b/default-avatar-profile-icon-vector-social-media-user-image-182145777.jpg";

            if (!IsPostBack)
            {
                // 1. Siempre configuramos primero la navegación según el estado de la sesión
                ConfigurarNavegacion();

                // 2. Luego verificamos si debe redirigir dependiendo de la página actual
                VerificarRedirecciones();

                if (Seguridad.sessionActiva(Session["sessionActiva"]))
                {
                    Usuarios usuario = (Usuarios)Session["sessionActiva"];
                    if (!string.IsNullOrEmpty(usuario.UrlImagen))
                    {
                        BtnLogin.ImageUrl = "~/Images/" + usuario.UrlImagen;
                    }
                }

            }
        }

        private void ConfigurarNavegacion()
        {
            // Por defecto, el enlace a Default/Catálogo siempre está visible
            // Los demás enlaces requieren autenticación

            lnkPerfil.Visible = false;
            //lnkFavoritos.Visible = false;
            lnkLista.Visible = false;

            // Si hay sesión activa, mostramos enlaces básicos
            if (Seguridad.sessionActiva(Session["sessionActiva"]))
            {
                lnkPerfil.Visible = true;
                //lnkFavoritos.Visible = true;

                // Si además es administrador, mostramos enlace a Lista
                if (Seguridad.esAdmin(Session["sessionActiva"]))
                {
                    lnkLista.Visible = true;
                }
            }
        }

        private void VerificarRedirecciones()
        {
            string paginaActual = Path.GetFileName(Request.Path).ToLower();

            // Si no es Default.aspx o Login.aspx, verificamos acceso
            if (paginaActual != "default.aspx" && paginaActual != "login.aspx" && paginaActual != "error.aspx")
            {
                // Si intenta acceder a ListaArticulos.aspx, verificamos si es admin
                if (paginaActual == "listaarticulos.aspx")
                {
                    if (!Seguridad.sessionActiva(Session["sessionActiva"]) ||
                        !Seguridad.esAdmin(Session["sessionActiva"]))
                    {
                        Response.Redirect("Default.aspx", false);
                        Context.ApplicationInstance.CompleteRequest();
                    }
                }
                // Para el resto de páginas protegidas (Perfil, Favoritos, etc.)
                else if (!Seguridad.sessionActiva(Session["sessionActiva"]))
                {
                    Response.Redirect("Default.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
        }



        protected void BtnLogin_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Login.aspx", false);
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx");
        }
    }
}