using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data.Database;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {

        Business.Entities.Usuario usuarioActual;



        //Este constructor servirá para las altas
        public UsuarioDesktop(ModoForm modo):this()
        {
            _modo = modo;
        }




        //Constructor para modificaciones
        public UsuarioDesktop(int id, ModoForm modo) : this()
        {
            _modo = modo;
            Business.Logic.UsuarioLogic usuarioLogic = new Business.Logic.UsuarioLogic();
            usuarioActual = usuarioLogic.GetOne(id);
            this.MapearDeDatos();
        }





        public UsuarioDesktop()
        {
            InitializeComponent();
        }








        //Consulta
        public override void MapearDeDatos()
        {
            this.txtIdUsuario.Text = this.usuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.usuarioActual._Habilitado;
            this.txtNombre.Text = this.usuarioActual._Nombre;
            this.txtApellido.Text = this.usuarioActual._Apellido;
            this.txtEmail.Text = this.usuarioActual._Email;
            this.txtIdUsuario.Text = this.usuarioActual._NombreUsuario;
            this.txtClave.Text = this.usuarioActual._Clave;

            if(_modo == ModoForm.Alta)
            {
                this.btnAceptar.Text = "Guardar";
            }

            else if(_modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
            }

            else
            {
            }


        }



        public override void MapearADatos()
        {
            usuarioActual = new Business.Entities.Usuario();
            this.usuarioActual._Apellido = this.txtApellido.Text;
            this.usuarioActual._Nombre = this.txtNombre.Text;
            this.usuarioActual._NombreUsuario = this.txtUsuario.Text;
            this.usuarioActual._Email = this.txtEmail.Text;
            this.usuarioActual._Clave = this.txtClave.Text;
            this.usuarioActual.State = Business.Entities.BusinessEntity.States.New;
            this.GuardarCambios(usuarioActual);
        }



        public override void GuardarCambios(Business.Entities.Usuario usuario)
        {
            UsuarioAdapter usuarioNuevo = new UsuarioAdapter();
            usuarioNuevo.Save(usuario);
        }


        public override bool Validar()
        {

            bool bandera = true;

            if(string.IsNullOrEmpty(this.txtApellido.Text)) 
            {
                bandera = false;
                throw new Exception("Debe completar el campo apellido");

            }

            if (string.IsNullOrEmpty(this.txtNombre.Text))
            {
                bandera = false;
                throw new Exception("Debe completar el campo nombre");
            }

            if (string.IsNullOrEmpty(this.txtUsuario.Text))
            {
                bandera = false;
                throw new Exception("Debe completar el campo usuario");
            }

            //Parte del email
            if (string.IsNullOrEmpty(this.txtEmail.Text))
            {
                bandera = false;
                throw new Exception("Debe completar el campo email");
            }

            else
            {
                if(this.txtEmail.Text.Contains("@"))
                {

                }

                else
                {
                    bandera = false;
                    throw new Exception("Email incorrecto, falta el símbolo @");
                }
            }
            //Parte del email




            if(string.IsNullOrEmpty(this.txtClave.Text))
            {
                bandera = false;
                throw new Exception("Debe completar el campo clave");
                
            }

            else
            {
                if(this.txtClave.Text.Length < 8)
                {
                    bandera = false;
                    throw new Exception("La clave debe poseer un mínimo de 8 caracteres");
                    
                }

            }

            if(string.IsNullOrEmpty(this.txtConfirmarClave.Text))
            {
                bandera = false;
                throw new Exception("Debe completar el campo confirmar clave");
                
            }

            else
            {
                if(!this.txtClave.Text.Equals(this.txtConfirmarClave.Text))
                {
                    bandera = false;
                    throw new Exception("Las contraseñas no coinciden");
                    
                }
            }

            if(!bandera)
            {
                string mensaje = "Datos incorrectos";
                //this.Notificar(mensaje);
            }

            return bandera;
        }


        













        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }






        //Botón aceptar posee este método
        private void label1_Click_1(object sender, EventArgs e)
        {
            if(_modo == ModoForm.Alta)
            {
                this.MapearADatos();
                MessageBox.Show("Usuario ingresado correctamente. Actualice la tabla!!!");
                this.Close();
            }



        }






        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void tbxIdUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
