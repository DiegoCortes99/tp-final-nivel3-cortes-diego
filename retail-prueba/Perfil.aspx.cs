using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace retail_prueba
{
	public partial class Perfil : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            //Verifica si viene algo viajando en la session.
            //Y verifica si existe una session activa.

            //if (!Seguridad.sessionActiva(Session["sessionActiva"]))
            //    Response.Redirect("Login.aspx",false);

            if (!IsPostBack)
            {
                try
                {
                    if (Seguridad.sessionActiva(Session["sessionActiva"]))
                    {
                        Usuarios usuario = (Usuarios)Session["sessionActiva"];
                        
                        txtNombre.Text = usuario.Nombre;
                        txtApellido.Text = usuario.Apellido;
                        txtEmail.Text = usuario.Email;

                        if (!string.IsNullOrEmpty(usuario.UrlImagen))
                        {
                            imgPerfil.ImageUrl = "~/Images/" + usuario.UrlImagen;
                        }

                    }
                    else
                    {
                        Response.Redirect("Login.aspx", false);
                        Context.ApplicationInstance.CompleteRequest();
                    }
                }
                catch (Exception ex)
                {

                    Session.Add("error", ex.ToString());
                    Response.Redirect("Error.aspx",false);
                }
            }
  
		}

        protected void txtImagenURL_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Escribir perfil

                UsuarioNegocio negocio = new UsuarioNegocio();

                Usuarios usuario = (Usuarios)Session["sessionActiva"];

                string ruta = Server.MapPath("./Images/");

                txtImagen.PostedFile.SaveAs(ruta + "Perfil-" + usuario.Id + ".jpg");

                usuario.UrlImagen = "Perfil-" + usuario.Id + ".jpg";

                negocio.actualizarPerfil(usuario);
                Response.Redirect("Default.aspx",false);

                //Leer perfil

                Image imgLogin = (Image)Master.FindControl("BtnLogin");
                imgLogin.ImageUrl = "~/Images/" + usuario.UrlImagen;

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }
    }
}