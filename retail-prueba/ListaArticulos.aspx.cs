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
	public partial class ListaArticulos : System.Web.UI.Page
	{
		

		protected void Page_Load(object sender, EventArgs e)
		{

			try
			{

				if (!IsPostBack)
				{
					//Valida si existe una session activa y si eres admin.

					if (!Seguridad.esAdmin(Session["sessionActiva"]))
					{
                        Response.Redirect("Default.aspx", false);
                    }

					//if (Session["sessionActiva"] != null)
					//{
					//	Usuarios usuario = (Usuarios)Session["sessionActiva"];

					//	if (!(usuario != null && usuario.Id != 0 && usuario.Admin == true))
					//	{
					//		Response.Redirect("Default.aspx", false);
					//	}
					//}

					ArticuloNegocio articuloNegocio = new ArticuloNegocio();
					Session.Add("articuloLista",articuloNegocio.listadoArticulos());
					dgvArticulos.DataSource = Session["articuloLista"];
					dgvArticulos.DataBind();

                }
			}
			catch (Exception ex)
			{

				Session.Add("Error", ex.Message);
				Response.Redirect("PantallaError.aspx", false);
			}
		}

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Session["id"] = dgvArticulos.SelectedDataKey.Value.ToString();
            //Response.Redirect("FormularioArticulos.aspx");

            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect($"FormularioArticulos.aspx?id={id}");
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
			Response.Redirect("FormularioArticulos.aspx");
        }
    }
}