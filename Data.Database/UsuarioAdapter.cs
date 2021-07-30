using System;
using System.Collections.Generic;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class UsuarioAdapter:Adapter
    {
        
        //Método modificado para base de datos
        public List<Usuario> GetAll()
        {
            //La línea 77 pertenecía a la implementación sin base de datos
            //return new List<Usuario>(Usuarios);

            //Instanciamos el objeto de lista para retornar
            List<Usuario> usuarios = new List<Usuario>();

        try
            {

                //Creamos la sentencia a ejecutar
                SqlCommand cmdUsuarios = new SqlCommand("SELECT * FROM usuarios", SqlConnection);

                //Apertura de la conexión a la base de datos
                this.OpenConnection();

                //Objeto DataReader, recuperará los datos de la base de datos
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                //Read() lee una fila de las devueltas por el comando sql
                //carga los datos en drUsuarios para poder accederlos,
                //devuelve verdadero mientras haya podido leer datos, 
                //y avanza a la fila siguiente para el próximo read.


                while (drUsuarios.Read())
                {
                    Usuario usr = new Usuario();

                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.Email = (string)drUsuarios["email"];
                    usuarios.Add(usr);

                }

                //Cerramos el DataReader y la conexión a la DataBase
                drUsuarios.Close();
            }catch(Exception Ex)
            {
                Exception ExceptionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExceptionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
            
            return usuarios;
        }



        //Método modificado para base de datos
        public Usuario GetOne(int ID)
        {
            //Parte previa a la base de datos
            //return Usuarios.Find(delegate (Usuario u) { return u.ID == ID; });

            
            Usuario usr = new Usuario();

            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("SELECT * FROM usuarios WHERE id_usuario = @id", SqlConnection);
                cmdUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();

                if(drUsuarios.Read())
                {
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Clave = (string)drUsuarios["clave"];
                    usr.Habilitado = (bool)drUsuarios["habilitado"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.Email = (string)drUsuarios["email"];
                }
                drUsuarios.Close();
            }catch(Exception ex)
            {
                Exception excepcionManejada = new Exception("Error al recuperar datos de usuario", ex);
                throw excepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return usr;
        }



        //Método modificado para base de datos
        public void Delete(int ID)
        {
            //Parte previa a base de datos
            //Usuarios.Remove(this.GetOne(ID));

            try
            {
                //Abro la conexión
                this.OpenConnection();

                //Creo la sentencia SQL
                SqlCommand cmdDelete = new SqlCommand("DELETE usuarios WHERE id_usuario = @id", SqlConnection);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                //Ejecuto la sentencia
                cmdDelete.ExecuteNonQuery();
            }catch(Exception ex)
            {
                Exception excepcionManejada = new Exception("Error al eliminar el usuario", ex);
                throw excepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

        }


        //Método modificado para base de datos
        public void Save(Usuario usuario)
        {
            if (usuario.State == BusinessEntity.States.Deleted)
            {
                this.Delete(usuario.ID);
            }
            else if (usuario.State == BusinessEntity.States.New)
            {
                this.Insert(usuario);
            }
            else if (usuario.State == BusinessEntity.States.Modified)
            {
                this.Update(usuario);
            }
            usuario.State = BusinessEntity.States.Unmodified;
        }
        



        //Método modificado para base de datos
        protected void Update(Usuario usuario)
        {
            try
            {
                
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE usuarios SET nombre_usuario = @nombre_usuario, clave = @clave, " +
                    "habilitado = @habilitado, nombre = @nombre, apellido = @apellido, email = @email " +
                    "WHERE id_usuario = @id", SqlConnection);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;
                
                this.OpenConnection();
                cmdSave.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Exception excepcionManeja = new Exception("Error al modificar datos del usuario", e);
                throw excepcionManeja;
            }

            finally
            {
                this.CloseConnection();
            }

        }



        //Método modificado para base de datos
        protected void Insert(Usuario usuario)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand(
                    "INSERT INTO usuarios (nombre_usuario, clave, habilitado, nombre, apellido, email) " +
                    "VALUES (@nombre_usuario, @clave, @habilitado, @nombre, @apellido, @email) " +
                    "SELECT @@identity",    //Esta línea es para recuperar el ID que asignó el sql automáticamente
                    SqlConnection);

                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;
                usuario.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                //Asi se obtiene el ID que asignó al BD automáticamente




            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear usuario", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
        }
        

        static void Main(string[] args)
        {

        }


    }
}
