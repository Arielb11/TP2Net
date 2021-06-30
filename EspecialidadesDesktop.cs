using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;
using Data.Database;

namespace UI.Desktop
{
    public partial class EspecialidadesDesktop : ApplicationForm
    {

        EspecialidadLogic especialidadLogic;
        Especialidad especialidadActual;

        public EspecialidadesDesktop()
        {
            InitializeComponent();
        }


        //Este constructor servirá para las altas
        public EspecialidadesDesktop(ModoForm modo) : this()
        {
            _modo = modo;
        }

        //Constructor para modificaciones
        /*
        public EspecialidadesDesktop(int id, ModoForm modo) : this()
        {
            _modo = modo;
            especialidadLogic = new EspecialidadLogic();
            especialidadActual = especialidadLogic.GetOne(id);
            this.MapearDeDatos();
        }*/


        public Especialidad EspecialidadActual
        {
            set { this.especialidadActual = value; }
            get { return especialidadActual; }
        }



        private void EspecialidadesDesktop_Load(object sender, EventArgs e)
        {

        }




        //Done
        public override void MapearDeDatos()
        {
            if (this._modo == ModoForm.Alta || this._modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }

            else if (this._modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
            }

            this.txtIdEspecialidad.Text = this.EspecialidadActual.ID.ToString();
            this.txtDescripcion.Text = this.EspecialidadActual.Descripcion;
            this.txtEstado.Text = this.EspecialidadActual.State.ToString();
        }





        //Done
        public override void MapearADatos()
        {
            if (this._modo == ModoForm.Alta)
            {
                EspecialidadActual = new Especialidad();
            }

            this.EspecialidadActual.Descripcion = this.txtDescripcion.Text;
        }





        //Done
        public override void GuardarCambios()
        {
            especialidadLogic = new EspecialidadLogic();

            if (this._modo == ModoForm.Alta)
            {
                this.MapearADatos();
                //especialidadLogic.Save(EspecialidadActual);
            }

            else if (this._modo == ModoForm.Modificacion)
            {
                this.MapearADatos();
                //especialidadLogic.Save(EspecialidadActual);
            }

            else if (this._modo == ModoForm.Baja)
            {
                //especialidadLogic.Save(EspecialidadActual);
            }
            


        }

    

        //Check It out
        public override bool Validar()
        {
            especialidadLogic = new EspecialidadLogic();
            bool bandera = true;

            if (string.IsNullOrEmpty(this.txtDescripcion.Text))
            {
                //MessageBox.Show("Debe completar el campo apellido");
                this.Notificar("Debe completar el campo descripción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
            }


            return bandera;
        }


        //Done
        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        //Done
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this._modo == ModoForm.Alta)
            {
                bool bandera = true;
                bandera = this.Validar();

                if (bandera)
                {
                    this.GuardarCambios();
                    //Llamar al método Notificar()
                    //MessageBox.Show("Usuario agregado correctamente");
                }

                else
                {
                    //Llamar al método Notificar()
                    //MessageBox.Show("El usuario no pudo ser agregado");
                }
            }



            else if (this._modo == ModoForm.Baja)
            {
                this.EspecialidadActual.State = Business.Entities.BusinessEntity.States.Deleted;
                this.GuardarCambios();
            }



            else if (this._modo == ModoForm.Modificacion)
            {
                this.EspecialidadActual.State = Business.Entities.BusinessEntity.States.Modified;
                this.GuardarCambios();
            }

            this.Close();
        }
    }
}
    