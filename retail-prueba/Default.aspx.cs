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
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulos> listaArticulos = new List<Articulos>();
        public List<Marcas> listaMarcas = new List<Marcas>();
        public List<Categorias> listaCategorias = new List<Categorias>();

        public ArticuloNegocio articuloNegocio = new ArticuloNegocio();
        public MarcaNegocio marcaNegocio = new MarcaNegocio();
        public CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                
                    listaMarcas = marcaNegocio.ListarHome();
                    listaArticulos = articuloNegocio.listadoArticulos();
                    listaCategorias = categoriaNegocio.ListarHome();

                    //llenar categoria

                    chkCategorias.DataSource = listaCategorias;
                    chkCategorias.DataBind();

                    //llenar marcas

                    chkMarcas.DataSource = listaMarcas;
                    chkMarcas.DataBind();

                    rpArticulos.DataSource = listaArticulos;
                    rpArticulos.DataBind();
                }
                catch (Exception ex)
                {

                    Session.Add("Error", ex.Message);
                    Response.Redirect("PantallaError.aspx", false);
                }
            }
            else
            {
                // Frente al postback tmb carga llenamos las listas 
                try
                {


                    // Llenamos las listas 
                    listaMarcas = marcaNegocio.ListarHome();
                    listaArticulos = articuloNegocio.listadoArticulos();
                    listaCategorias = categoriaNegocio.ListarHome();

                }
                catch (Exception ex)
                {

                    Session.Add("Error", ex.Message);
                    Response.Redirect("PantallaError.aspx", false);
                }
            }


        }
        private List<Articulos> FiltrarArticulos(List<int> marcasIds, List<int> categoriasIds)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            List<Articulos> todos = negocio.listadoArticulos();

            //Se utiliza LINQ para filtrar articulos cuyas marcas y categorias esten en la lista de ID

            // Filtro combinado
            if (marcasIds.Any()) todos = todos.Where(a => marcasIds.Contains(a.Marca.Id)).ToList();
            if (categoriasIds.Any()) todos = todos.Where(a => categoriasIds.Contains(a.Categoria.Id)).ToList();

            //Si no cumplen con ambos filtros se retorna la lista completa

            return todos;
        }

        //Identifica que opciones del grupo de checkbox fue marcada por el usuario
        private List<int> GetSelectedCheckboxValues(CheckBoxList checkBoxList)
        {
            return checkBoxList.Items.Cast<ListItem>()
                .Where(li => li.Selected)
                .Select(li => int.Parse(li.Value))
                .ToList();
        }

        protected void FiltrarProductos(object sender, EventArgs e)
        {
            try
            {
                // Obtener selecciones actuales
                List<int> marcasSeleccionadas = GetSelectedCheckboxValues(chkMarcas);
                List<int> categoriasSeleccionadas = GetSelectedCheckboxValues(chkCategorias);

                // Aplicar filtro combinado
                List<Articulos> resultados = FiltrarArticulos(marcasSeleccionadas, categoriasSeleccionadas);

                // Actualizar Repeater
                rpArticulos.DataSource = resultados;
                rpArticulos.DataBind();
            }
            catch (Exception ex)
            {
                // Manejar errores
                throw ex;
            }
        }


        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
           
        }


        protected void btnDetalle_Command(object sender, CommandEventArgs e)
        {

        }


    }
}