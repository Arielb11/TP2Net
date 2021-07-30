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
    public partial class frmUsuarioDesktop : ApplicationForm
    {

        Usuario usuarioActual;
        UsuarioLogic usuarioLogic;

        public Usuario UsuarioActual
        {
            get { return usuarioActual; }
            set { usuarioActual = value; }
        }


        //Este constructor servirá para las altas
        public frmUsuarioDesktop(ModoForm modo):this()
        {
            base.modo = modo;
        }


        //Constructor para modificaciones
        public frmUsuarioDesktop(int id, ModoForm modo) : this()
        {
            base.modo = modo;
            usuarioLogic = new UsuarioLogic();
            UsuarioActual = usuarioLogic.GetOne(id);
            this.MapearDeDatos();
        }





        public frmUsuarioDesktop()
        {
            InitializeComponent();
        }




        //Check It out
        public override void MapearDeDatos()
        {
            if(this.modo == ModoForm.Alta || this.modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }

            else if(this.modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
            }



            this.txtIdUsuario.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtEmail.Text = this.UsuarioActual.Email;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;

        }


        //Done
        public override void MapearADatos()
        {

            if (this.modo == ModoForm.Alta)
            {
                UsuarioActual = new Usuario();
            }

            else if(this.modo == ModoForm.Modificacion)
            {
                UsuarioActual.State = BusinessEntity.States.Modified;
            }

            this.UsuarioActual.Apellido = this.txtApellido.Text;
            this.UsuarioActual.Nombre = this.txtNombre.Text;
            this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
            this.UsuarioActual.Email = this.txtEmail.Text;
            this.UsuarioActual.Clave = this.txtClave.Text;
            this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;

        }



        //Done
        public override void GuardarCambios()
        {
            usuarioLogic = new UsuarioLogic();

            if (this.modo == ModoForm.Alta)
            {
                this.MapearADatos();
                usuarioLogic.Save(UsuarioActual);
            }

            else if(this.modo == ModoForm.Modificacion)
            {
                this.MapearADatos();
                usuarioLogic.Save(UsuarioActual);
            }

            else if(this.modo == ModoForm.Baja)
            {
                usuarioLogic.Save(UsuarioActual);
            }

        }
        

        public override bool Validar()
        {

            //Para validar una cadena vacía con expresiones regulares, usar "^$"

            bool bandera = true;

            //Si no se completó ningún campo, se muestra un mensaje de que los campos están vacíos
            if (!Validaciones.IsFieldEmpty(this.txtApellido.Text) && !Validaciones.IsFieldEmpty(this.txtNombre.Text) && !Validaciones.IsFieldEmpty(this.txtUsuario.Text) && !Validaciones.IsFieldEmpty(this.txtEmail.Text) && !Validaciones.IsFieldEmpty(this.txtClave.Text) && !Validaciones.IsFieldEmpty(this.txtConfirmarClave.Text))
            {
                this.Notificar("Debe completar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
                return bandera;
            }


            if (!Validaciones.IsFieldEmpty(this.txtApellido.Text))
            {
                this.Notificar("Debe completar el campo apellido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
            }

            if (!Validaciones.IsFieldEmpty(this.txtNombre.Text))
            {
                this.Notificar("Debe completar el campo nombre", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
            }

            if (!Validaciones.IsFieldEmpty(this.txtUsuario.Text))
            {
                this.Notificar("Debe completar el campo nombre de usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;

            }




            //Parte del email
            if (!Validaciones.IsFieldEmpty(this.txtEmail.Text))
            {
                this.Notificar("Debe completar el campo email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;

            }

            else
            {
                if (Validaciones.IsMailValue(this.txtEmail.Text))
                {

                }

                else
                {
                    this.Notificar("Email incorrecto, falta el símbolo @", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bandera = false;

                }
            }
            //Parte del email




            if (!Validaciones.IsFieldEmpty(this.txtClave.Text))
            {
                this.Notificar("Debe completar el campo clave", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;

            }

            else
            {
                if (this.txtClave.Text.Length < 8)
                {
                    this.Notificar("La clave debe poseer un mínimo de 8 caracteres", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bandera = false;


                }

            }

            if (!Validaciones.IsFieldEmpty(this.txtConfirmarClave.Text))
            {
                this.Notificar("Debe completar el campo confirmar clave", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;

            }

            else
            {
                if (!this.txtClave.Text.Equals(this.txtConfirmarClave.Text))
                {
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
        private void label1_Click_1(object sender, EventArgs e)
        {
            bool bandera;

            if (this.modo == ModoForm.Alta)
            {
                bandera = this.Validar();

                if (bandera)
                {
                    this.GuardarCambios();
                    this.Notificar("Alta de Usuario", "Usuario agregado correctamente", MessageBoxButtons.OK, MessageBoxIcon.None);
                }

                else
                {
                    this.Notificar("Alta de Usuario", "El usuario no pudo ser agregado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }



            else if(this.modo == ModoForm.Baja)
            {
                this.UsuarioActual.State = Business.Entities.BusinessEntity.States.Deleted;
                this.GuardarCambios();
                this.Notificar("Baja de Usuario", "Usuario eliminado correctamente", MessageBoxButtons.OK, MessageBoxIcon.None);
            }



            else if (this.modo == ModoForm.Modificacion)
            {
                this.UsuarioActual.State = Business.Entities.BusinessEntity.States.Modified;
                bandera = this.Validar();

                if(bandera)
                {
                    this.GuardarCambios();
                    this.Notificar("Modificación de Usuario", "Usuario actualizado correctamente", MessageBoxButtons.OK, MessageBoxIcon.None);
                }

                else
                {
                    this.Notificar("Modificación de Usuario", "El usuario no pudo ser actualizado correctamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }   
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

        //Done
        private void UsuarioDesktop_Load(object sender, EventArgs e)
        {
            if(this.modo == ModoForm.Alta)
            {
                this.Text = "Alta de usuario";
            }

            else if(this.modo == ModoForm.Modificacion)
            {
                this.Text = "Modificación de usuario";
            }

            else
            {
                this.Text = "Baja de usuario";
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkHabilitado_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
