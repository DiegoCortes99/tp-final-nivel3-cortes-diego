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
    public partial class FormularioArticulos : System.Web.UI.Page
    {

        List<Marcas> listaMarcas = new List<Marcas>();
        List<Categorias> listaCategorias = new List<Categorias>();

        MarcaNegocio marcaNegocio = new MarcaNegocio();
        CategoriaNegocio CategoriaNegocio = new CategoriaNegocio();

        Articulos articulos = new Articulos();

        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Visible = false;
            txtEliminar.Visible = false;
            btnConfirmarEliminacion.Visible = false;

            try
            {
                //Codigo para Agregar
                if (!IsPostBack)
                {


                    listaMarcas = marcaNegocio.listarMarca();
                    listaCategorias = CategoriaNegocio.ListarCategoria();

                    ddlMarca.DataSource = listaMarcas;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();

                    ddlCategoria.DataSource = listaCategorias;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();
                }


                if (Request.QueryString["id"] != null && !IsPostBack)
                {
                    txtId.Visible = true;
                    txtId.Enabled = false;

                    ArticuloNegocio articuloNegocio = new ArticuloNegocio();

                    // se agrego una sobrecarga al metodo listar, para capturar el id
                    List<Articulos> listaArticulos = articuloNegocio.listadoArticulos(Request.QueryString["id"].ToString());

                    Articulos seleccionado = listaArticulos[0];


                    //guardo articulo seleccionado en session
                    Session.Add("articuloSeleccionado", seleccionado);

                    //Pre cargar todos los campos

                    txtId.Text = seleccionado.Id.ToString();
                    txtCodigo.Text = seleccionado.codigoArticulo;
                    txtNombre.Text = seleccionado.Nombre;

                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();

                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtPrecio.Text = seleccionado.precio.ToString();

                    txtImagenUrl.Text = seleccionado.ImagenUrl;
                    txtImagen_TextChanged(sender, e);

                }

                //Codigo para Modificar


            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            try
            {
                articulos.codigoArticulo = txtCodigo.Text;
                articulos.Nombre = txtNombre.Text;

                articulos.Marca = new Marcas();
                articulos.Marca.Id = int.Parse(ddlMarca.SelectedValue);

                articulos.Categoria = new Categorias();
                articulos.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                articulos.Descripcion = txtDescripcion.Text;
                articulos.ImagenUrl = txtImagenUrl.Text;
                articulos.precio = decimal.Parse(txtPrecio.Text);


                if (Request.QueryString["id"] != null)
                {
                    //Para el modificar tenemos que pasarle un id

                    articulos.Id = int.Parse(txtId.Text);
                    articuloNegocio.modificar(articulos);
                }
                else
                {
                    articuloNegocio.agregar(articulos);
                }

                Response.Redirect("ListaArticulos.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }


        }

        protected void txtImagen_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImagenUrl.Text;
        }

        protected void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            Marcas nuevo = new Marcas();
            btnAgregarMarca.Visible = false;


            btnAgregarMarca.Visible = true;
            try
            {
                nuevo.Descripcion = txtAgregarMarca.Text;
                marcaNegocio.agregarMarca(nuevo);

                listaMarcas = marcaNegocio.listarMarca();

                ddlMarca.DataSource = listaMarcas;
                ddlMarca.DataValueField = "Id";
                ddlMarca.DataTextField = "Descripcion";
                ddlMarca.DataBind();

                txtAgregarMarca.Text = string.Empty;
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }


        }

        protected void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            Categorias nuevo = new Categorias();


            try
            {
                nuevo.Descripcion = txtAgregarCategoria.Text;
                CategoriaNegocio.agregarCategoria(nuevo);

                listaCategorias = CategoriaNegocio.ListarCategoria();

                ddlCategoria.DataSource = listaCategorias;
                ddlCategoria.DataValueField = "Id";
                ddlCategoria.DataTextField = "Descripcion";
                ddlCategoria.DataBind();

                txtAgregarCategoria.Text = string.Empty;

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }

        }

        protected void txtEliminar_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEliminar.Text) && txtEliminar.Text.Count() == 3 && txtEliminar.Text == txtCodigo.Text.ToString())
            {
                btnConfirmarEliminacion.Enabled = true;
                lblMensaje.Text = "Código correcto. Confirme la eliminación.";
            }
            else
            {
                btnConfirmarEliminacion.Enabled = false;
                lblMensaje.Text = "Código incorrecto.";
            }
        }

        protected void btnConfirmarEliminacion_Click(object sender, EventArgs e)
        {

            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            try
            {
                if (Request.QueryString["id"] != null)
                {
                    //Para el eliminar tenemos que pasarle un id

                    articulos.Id = int.Parse(txtId.Text);
                    articuloNegocio.eliminar(articulos);
                }
                Response.Redirect("ListaArticulos.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            txtEliminar.Visible = true;
            btnConfirmarEliminacion.Visible = true;

            if (Request.QueryString["id"] != null)
            {
                txtId.Visible = true;
                btnAgregarMarca.Visible = false;
                btnAgregarCategoria.Visible = false;
            }

        }
    }
}