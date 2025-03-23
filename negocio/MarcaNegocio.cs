using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class MarcaNegocio
    {
        public List<Marcas> listarMarca()
        {
            List<Marcas> lista = new List<Marcas>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.crearConsulta("Select Id, Descripcion from MARCAS");
                datos.ejecutarConsulta();

                while (datos.Lector.Read())
                {
                    Marcas aux = new Marcas();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    lista.Add(aux);
                }
                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Marcas> ListarHome()
        {

            // Creamos la listar

            List<Marcas> lista = new List<Marcas>();


            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.crearConsulta("SELECT DISTINCT m.Id, m.Descripcion FROM MARCAS m inner join ARTICULOS art on m.id = art.IdMarca");


                datos.ejecutarConsulta();


                // Cargar los datos 

                while (datos.Lector.Read())
                {

                    Marcas aux = new Marcas();
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

        public void agregarMarca(Marcas nuevo)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.crearConsulta("insert into MARCAS (Descripcion) values (@descripcion)");
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
