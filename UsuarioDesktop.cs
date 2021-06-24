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
        Business.Logic.UsuarioLogic usuarioValido;

        public Business.Entities.Usuario UsuarioActual
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
            Business.Logic.UsuarioLogic usuarioLogic = new Business.Logic.UsuarioLogic();
            UsuarioActual = usuarioLogic.GetOne(id);
            this.MapearDeDatos();
        }





        public UsuarioDesktop()
        {
            InitializeComponent();
        }





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



        public override void MapearADatos()
        {
            
            if(this._modo == ModoForm.Alta)
            {
                Business.Entities.Usuario nuevoUsuario = new Business.Entities.Usuario();
                UsuarioActual = nuevoUsuario;
            }
            
            this.UsuarioActual._Apellido = this.txtApellido.Text;
            this.UsuarioActual._Nombre = this.txtNombre.Text;
            this.UsuarioActual._NombreUsuario = this.txtUsuario.Text;
            this.UsuarioActual._Email = this.txtEmail.Text;
            this.UsuarioActual._Clave = this.txtClave.Text;
            this.UsuarioActual._Habilitado = this.chkHabilitado.Checked;

        }




        public override void GuardarCambios()
        {
            Business.Logic.UsuarioLogic usuario = new Business.Logic.UsuarioLogic();

            if (this._modo == ModoForm.Alta)
            {
                this.MapearADatos();    
                usuario.Save(UsuarioActual);
            }

            else if(this._modo == ModoForm.Modificacion)
            {
                this.MapearADatos();
                usuario.Save(UsuarioActual);
            }

            else if(this._modo == ModoForm.Baja)
            {
                usuario.Save(UsuarioActual);
            }

            
            
        }
        



        public override bool Validar()
        {
            //Parte en prueba
            usuarioValido = new Business.Logic.UsuarioLogic();
            bool bandera = true;
            bandera = usuarioValido.ValidaCampos(this.usuarioActual);
            //Parte en prueba
            
            //Parte vieja

            //if (string.IsNullOrEmpty(this.txtApellido.Text)) 
            //{
            //    MessageBox.Show("Debe completar el campo apellido");
            //    bandera = false;
            //}

            //if (string.IsNullOrEmpty(this.txtNombre.Text))
            //{
            //    MessageBox.Show("Debe completar el campo nombre");
            //    bandera = false;
            //}

            //if (string.IsNullOrEmpty(this.txtUsuario.Text))
            //{
            //    MessageBox.Show("Debe completar el campo nombre de usuario");
            //    bandera = false;
                
            //}


            //Parte del email
            //if (string.IsNullOrEmpty(this.txtEmail.Text))
            //{
            //    MessageBox.Show("Debe completar el campo email");
            //    bandera = false;
                
            //}

            //else
            //{
            //    if(this.txtEmail.Text.Contains("@"))
            //    {

            //    }

            //    else
            //    {
            //        MessageBox.Show("Email incorrecto, falta el símbolo @");
            //        bandera = false;
                    
            //    }
            //}
            //Parte del email




            //if(string.IsNullOrEmpty(this.txtClave.Text))
            //{
            //    MessageBox.Show("Debe completar el campo clave");
            //    bandera = false;

            //}

            //else
            //{
            //    if(this.txtClave.Text.Length < 8)
            //    {
            //        MessageBox.Show("La clave debe poseer un mínimo de 8 caracteres");
            //        bandera = false;
                    
                    
            //    }

            //}

            if(string.IsNullOrEmpty(this.txtConfirmarClave.Text))
            {
                MessageBox.Show("Debe completar el campo confirmar clave");
                bandera = false;
                
            }

            else
            {
                if(!this.txtClave.Text.Equals(this.txtConfirmarClave.Text))
                {
                    MessageBox.Show("Las contraseñas no coinciden");
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

            if(this._modo == ModoForm.Alta)
            {
                bool bandera = true;
                bandera = this.Validar();

                if (bandera)
                {
                    this.GuardarCambios();
                    MessageBox.Show("Usuario agregado correctamente");
                }

                else
                {
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
    }
}
