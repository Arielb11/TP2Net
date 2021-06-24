using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class UsuarioAdapter:Adapter
    {

        #region DatosEnMemoria
        // Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta será eliminada
        private static List<Usuario> _Usuarios;



        //Esto es una propiedad de la lista de Usuarios
        private static List<Usuario> Usuarios
        {
            get
            {
                if (_Usuarios == null)
                {
                    _Usuarios = new List<Business.Entities.Usuario>();
                    Business.Entities.Usuario usr;
                    usr = new Business.Entities.Usuario();
                    usr.ID = 1;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr._Nombre = "Casimiro";
                    usr._Apellido = "Cegado";
                    usr._NombreUsuario = "casicegado";
                    usr._Clave = "miro";
                    usr._Email = "casimirocegado@gmail.com";
                    usr._Habilitado = true;
                    _Usuarios.Add(usr);

                    usr = new Business.Entities.Usuario();
                    usr.ID = 2;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr._Nombre = "Armando Esteban";
                    usr._Apellido = "Quito";
                    usr._NombreUsuario = "aequito";
                    usr._Clave = "carpintero";
                    usr._Email = "armandoquito@gmail.com";
                    usr._Habilitado = true;
                    _Usuarios.Add(usr);

                    usr = new Business.Entities.Usuario();
                    usr.ID = 3;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr._NombreUsuario = "Alan";
                    usr._Apellido = "Brado";
                    usr._NombreUsuario = "alanbrado";
                    usr._Clave = "abrete sesamo";
                    usr._Email = "alanbrado@gmail.com";
                    usr._Habilitado = true;
                    _Usuarios.Add(usr);

                }
                return _Usuarios;
            }
        }
        #endregion





        public List<Usuario> GetAll()
        {
            //La línea 77 pertenecía a la implementación sin base de datos
            //return new List<Usuario>(Usuarios);

            //Instanciamos el objeto de lista para retornar
            List<Usuario> usuarios = new List<Usuario>();


        try
            {
                //Apertura de la conexión a la base de datos
                this.OpenConnection();


                //Creamos la sentencia a ejecutar
                SqlCommand cmdUsuarios = new SqlCommand("SELECT * FROM usuarios", _SqlConnection);

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
                    usr._NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr._Clave = (string)drUsuarios["clave"];
                    usr._Habilitado = (bool)drUsuarios["habilitado"];
                    usr._Nombre = (string)drUsuarios["nombre"];
                    usr._Apellido = (string)drUsuarios["apellido"];
                    usr._Email = (string)drUsuarios["email"];

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




        public Business.Entities.Usuario GetOne(int ID)
        {
            return Usuarios.Find(delegate (Usuario u) { return u.ID == ID; });
        }

        public void Delete(int ID)
        {
            Usuarios.Remove(this.GetOne(ID));
        }

        public void Save(Usuario usuario)
        {
            if (usuario.State == BusinessEntity.States.New)
            {
                int NextID = 0;
                foreach (Usuario usr in Usuarios)
                {
                    if (usr.ID > NextID)
                    {
                        NextID = usr.ID;
                    }
                }
                usuario.ID = NextID + 1;
                Usuarios.Add(usuario);
            }
            else if (usuario.State == BusinessEntity.States.Deleted)
            {
                this.Delete(usuario.ID);
            }
            else if (usuario.State == BusinessEntity.States.Modified)
            {
                Usuarios[Usuarios.FindIndex(delegate (Usuario u) { return u.ID == usuario.ID; })] = usuario;
            }
            usuario.State = BusinessEntity.States.Unmodified;
        }



        static void Main(string[] args)
        {

        }


    }
}
