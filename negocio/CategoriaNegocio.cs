using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class CategoriaNegocio
    {
        public List<Categorias> ListarCategoria()
        {
            List<Categorias> lista = new List<Categorias>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.crearConsulta("Select Id, Descripcion from CATEGORIAS");
                datos.ejecutarConsulta();
                while (datos.Lector.Read())
                {
                    Categorias aux = new Categorias();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    lista.Add(aux);
                }
                return lista;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Categorias> ListarHome()
        {

            // Creamos la listar para el home Solo vamos a listar las categorias en las que tenemos existencias de productos

            List<Categorias> lista = new List<Categorias>();


            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.crearConsulta("SELECT DISTINCT cat.Id , cat.Descripcion FROM CATEGORIAS cat inner join ARTICULOS art on cat.id = art.IdCategoria");


                datos.ejecutarConsulta();


                // Cargar los datos 

                while (datos.Lector.Read())
                {

                    Categorias aux = new Categorias();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = datos.Lector["Descripcion"].ToString();

                    lista.Add(aux);

                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                datos.cerrarConexion();
            }
        }

        public void agregarCategoria(Categorias nuevo)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.crearConsulta("insert into CATEGORIAS (Descripcion) values (@descripcion)");
                datos.setearParametros("@descripcion", nuevo.Descripcion);
                datos.ejecutarConsultaParametro();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar articulo: " + ex.Message, ex);
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
    }
}
