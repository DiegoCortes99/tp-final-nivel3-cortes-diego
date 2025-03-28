using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class UsuarioNegocio
    {
        public int insertarNuevo(Usuarios nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.crearConsulta("insert into USERS(email, pass, nombre, apellido, admin) output inserted.Id values (@email, @pass,@nombre,@apellido, 0 )");
                datos.setearParametros("@email", nuevo.Email);
                datos.setearParametros("@pass", nuevo.Pass);
                datos.setearParametros("@nombre", nuevo.Nombre);
                datos.setearParametros("@apellido", nuevo.Apellido);
                return datos.ejecutarScalar();
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

        public bool login(Usuarios usuarios)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.crearConsulta("Select Id,email,pass, admin, urlImagenPerfil, nombre, apellido from USERS where email = @email and pass = @pass");
                datos.setearParametros("@email", usuarios.Email);
                datos.setearParametros("@pass", usuarios.Pass);
                datos.ejecutarConsulta();
                if (datos.Lector.Read())
                {
                    //Lector recorre los datos y si encuentra un usuario el Id y admin los asigna a el objeto usuarios.

                    usuarios.Id = (int)datos.Lector["Id"];
                    usuarios.Admin = (bool)datos.Lector["admin"];

                    if (!(datos.Lector["urlImagenPerfil"] is DBNull))
                        usuarios.UrlImagen = (string)datos.Lector["urlImagenPerfil"];
                    if (!(datos.Lector["nombre"] is DBNull))
                        usuarios.Nombre = (string)datos.Lector["nombre"];
                    if (!(datos.Lector["apellido"] is DBNull))
                        usuarios.Apellido = (string)datos.Lector["apellido"];

                    return true;
                }
                return false;
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

        public void actualizarPerfil(Usuarios usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //Operador coalessing Validar Null
                datos.crearConsulta("Update USERS set nombre = @nombre, apellido = @apellido, urlImagenPerfil = @imagenPerfil where Id = @Id");
                datos.setearParametros("@imagenPerfil", (object)usuario.UrlImagen ?? DBNull.Value);
                datos.setearParametros("@nombre",(object)usuario.Nombre ?? DBNull.Value);
                datos.setearParametros("@apellido",(object)usuario.Apellido ?? DBNull.Value);
                datos.setearParametros("@Id", usuario.Id);
                datos.ejecutarConsultaParametro();
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
    }
}
