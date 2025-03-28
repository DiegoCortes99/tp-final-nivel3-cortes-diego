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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            Usuarios usuarios = new Usuarios();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

            try
            {
                Page.Validate();
                if (!Page.IsValid)
                {
                    return;
                }
                else
                {
                    usuarios.Email = txtEmaill.Text;
                    usuarios.Pass = txtContraa.Text;
                    usuarios.Nombre = txtNombree.Text;
                    usuarios.Apellido = txtApellidoo.Text;

                    usuarios.Id = usuarioNegocio.insertarNuevo(usuarios);

                    Session.Add("sessionActiva", usuarios);

                    Response.Redirect("Default.aspx", false);
                }


            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}