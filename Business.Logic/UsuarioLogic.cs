using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class UsuarioLogic: BusinessLogic
    {
        Data.Database.UsuarioAdapter UsuarioData;

        public UsuarioLogic()
        {
            UsuarioData = new Data.Database.UsuarioAdapter();
        }


        //Método que crea una lista de usuarios, y la devuelve
        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = UsuarioData.GetAll();
            return usuarios;
        }


        //Método que recibe como parámetro un id, y que devuelve un usuario.
        public Usuario GetOne(int id)
        {
            Usuario user = UsuarioData.GetOne(id);
            return user;
        }


        //Método que recibe como parámetro un id, y que elimina a un usuario
        public void Delete(int id)
        {
            UsuarioData.Delete(id);
        }

        //Método que recibe como parámetro un usuario, y lo guarda en la lista
        public void Save(Usuario usuario)
        {
            UsuarioData.Save(usuario);
        }




        //Método para validar campos del formulario de UsuarioDesktop
        public bool ValidaCampos(Usuario usuarioValido)
        {
            if(string.IsNullOrEmpty(usuarioValido._Apellido))
            {
                return false;
            }

            if(string.IsNullOrEmpty(usuarioValido._Nombre))
            {
                return false;
            }

            if (string.IsNullOrEmpty(usuarioValido._NombreUsuario))
            {
                return false;
            }


            //Email
            if (string.IsNullOrEmpty(usuarioValido._Email))
            {
                return false;
            }

            else
            {
                if (usuarioValido._Email.Contains("@"))
                {

                }

                else
                {
                    return false;
                }
            }

            //Clave

            if (string.IsNullOrEmpty(usuarioValido._Clave))
            {
                return false;
            }

            else
            {
                if (usuarioValido._Clave.Length < 8)
                {
                    //MessageBox.Show("La clave debe poseer un mínimo de 8 caracteres");
                    return false;

                }

            }


            return true;
        }

        static void Main(string[] args)
        {

        }



    }
}
