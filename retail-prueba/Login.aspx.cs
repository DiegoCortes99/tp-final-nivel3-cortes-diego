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
	public partial class Login : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            
		}

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
			UsuarioNegocio negocio = new UsuarioNegocio();
			Usuarios usuario = new Usuarios();
			try
			{
                usuario.Email = txtUsuarioo.Text;
                usuario.Pass = txtContraa.Text;

				//devuelve true o false si se logeo y si leyo nos trae el Id y si es admin
				if (negocio.login(usuario))
				{
					//Con el session guardamos una sessionActiva que nos permitira ingresar o no en determinadas pantallas.
					Session.Add("sessionActiva", usuario);
					Response.Redirect("Default.aspx",false);
				}
				else
				{
					Session.Add("error", "usuario o contrasenia incorrecta");
					Response.Redirect("Error.aspx",false);
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