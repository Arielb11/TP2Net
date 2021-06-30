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
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {

        Usuario usuarioActual;
        UsuarioLogic usuarioLogic;

        public Usuario UsuarioActual
        {
            get { return usuarioActual; }
            set { usuarioActual = value; }
        }


        //Este constructor servirá para las altas
        public UsuarioDesktop(ModoForm modo):this()
        {
            _modo = modo;
        }


        //Constructor para modificaciones
        public UsuarioDesktop(int id, ModoForm modo) : this()
        {
            _modo = modo;
            usuarioLogic = new UsuarioLogic();
            UsuarioActual = usuarioLogic.GetOne(id);
            this.MapearDeDatos();
        }





        public UsuarioDesktop()
        {
            InitializeComponent();
        }




        //Check It out
        public override void MapearDeDatos()
        {
            if(this._modo == ModoForm.Alta || this._modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }

            else if(this._modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
            }


            this.txtIdUsuario.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual._Habilitado;
            this.txtNombre.Text = this.UsuarioActual._Nombre;
            this.txtApellido.Text = this.UsuarioActual._Apellido;
            this.txtEmail.Text = this.UsuarioActual._Email;
            this.txtUsuario.Text = this.UsuarioActual._NombreUsuario;
        }


        //Done
        public override void MapearADatos()
        {
            
            if(this._modo == ModoForm.Alta)
            {
                UsuarioActual = new Usuario();
            }
            
            this.UsuarioActual._Apellido = this.txtApellido.Text;
            this.UsuarioActual._Nombre = this.txtNombre.Text;
            this.UsuarioActual._NombreUsuario = this.txtUsuario.Text;
            this.UsuarioActual._Email = this.txtEmail.Text;
            this.UsuarioActual._Clave = this.txtClave.Text;
            this.UsuarioActual._Habilitado = this.chkHabilitado.Checked;

        }



        //Done
        public override void GuardarCambios()
        {
            usuarioLogic = new UsuarioLogic();

            if (this._modo == ModoForm.Alta)
            {
                this.MapearADatos();
                usuarioLogic.Save(UsuarioActual);
            }

            else if(this._modo == ModoForm.Modificacion)
            {
                this.MapearADatos();
                usuarioLogic.Save(UsuarioActual);
            }

            else if(this._modo == ModoForm.Baja)
            {
                usuarioLogic.Save(UsuarioActual);
            }

            
            
        }
        


        //Check It out
        public override bool Validar()
        {
            usuarioLogic = new UsuarioLogic();
            bool bandera = true;

            if (string.IsNullOrEmpty(this.txtApellido.Text))
            {
                //MessageBox.Show("Debe completar el campo apellido");
                this.Notificar("Debe completar el campo apellido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
            }

            if (string.IsNullOrEmpty(this.txtNombre.Text))
            {
                //MessageBox.Show("Debe completar el campo nombre");
                this.Notificar("Debe completar el campo nombre", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
            }

            if (string.IsNullOrEmpty(this.txtUsuario.Text))
            {
                //MessageBox.Show("Debe completar el campo nombre de usuario");
                this.Notificar("Debe completar el campo nombre de usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;

            }


            //Parte del email
            if (string.IsNullOrEmpty(this.txtEmail.Text))
            {
                //MessageBox.Show("Debe completar el campo email");
                this.Notificar("Debe completar el campo email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;

            }

            else
            {
                if (this.txtEmail.Text.Contains("@"))
                {

                }

                else
                {
                    //MessageBox.Show("Email incorrecto, falta el símbolo @");
                    this.Notificar("Email incorrecto, falta el símbolo @", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bandera = false;

                }
            }
            //Parte del email




            if (string.IsNullOrEmpty(this.txtClave.Text))
            {
                //MessageBox.Show("Debe completar el campo clave");
                this.Notificar("Debe completar el campo clave", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;

            }

            else
            {
                if (this.txtClave.Text.Length < 8)
                {
                    //MessageBox.Show("La clave debe poseer un mínimo de 8 caracteres");
                    this.Notificar("La clave debe poseer un mínimo de 8 caracteres", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bandera = false;


                }

            }

            if (string.IsNullOrEmpty(this.txtConfirmarClave.Text))
            {
                //MessageBox.Show("Debe completar el campo confirmar clave");
                this.Notificar("Debe completar el campo confirmar clave", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;

            }

            else
            {
                if (!this.txtClave.Text.Equals(this.txtConfirmarClave.Text))
                {
                    //MessageBox.Show("Las contraseñas no coinciden");
                    this.Notificar("Las contraseñas no coinciden", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bandera = false;

                }
            }

            return bandera;
        }


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }






        //Botón aceptar del formulario USUARIO DESKTOP, acepta dos valores = (Aceptar, eliminar)
        //Check It out
        private void label1_Click_1(object sender, EventArgs e)
        {

            if(this._modo == ModoForm.Alta)
            {
                bool bandera = true;
                bandera = this.Validar();

                if (bandera)
                {
                    this.GuardarCambios();
                    //Llamar al método Notificar()
                    MessageBox.Show("Usuario agregado correctamente");
                }

                else
                {
                    //Llamar al método Notificar()
                    MessageBox.Show("El usuario no pudo ser agregado");
                }
            }



            else if(this._modo == ModoForm.Baja)
            {
                this.UsuarioActual.State = Business.Entities.BusinessEntity.States.Deleted;
                this.GuardarCambios();
            }



            else if (this._modo == ModoForm.Modificacion)
            {
                this.UsuarioActual.State = Business.Entities.BusinessEntity.States.Modified;
                this.GuardarCambios();
            }

            this.Close();
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


        //Done
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {

        }

        private void UsuarioDesktop_Load(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkHabilitado_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
