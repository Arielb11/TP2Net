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
    public partial class frmEspecialidadesDesktop : ApplicationForm
    {

        EspecialidadLogic especialidadLogic;
        Especialidad especialidadActual;

        public frmEspecialidadesDesktop()
        {
            InitializeComponent();
        }


        //Este constructor servirá para las altas
        public frmEspecialidadesDesktop(ModoForm modo) : this()
        {
            base.modo = modo;
        }

        //Constructor para modificaciones

        public frmEspecialidadesDesktop(int id, ModoForm modo) : this()
        {
            base.modo = modo;
            especialidadLogic = new EspecialidadLogic();
            especialidadActual = especialidadLogic.GetOne(id);
            this.MapearDeDatos();
        }


        public Especialidad EspecialidadActual
        {
            set { this.especialidadActual = value; }
            get { return especialidadActual; }
        }



        private void EspecialidadesDesktop_Load(object sender, EventArgs e)
        {
            if (this.modo == ModoForm.Alta)
            {
                this.Text = "Alta de especialidad";
            }

            else if (this.modo == ModoForm.Modificacion)
            {
                this.Text = "Modificación de especialidad";
            }

            else
            {
                this.Text = "Baja de especialidad";
            }
        }




        //Done
        public override void MapearDeDatos()
        {
            if (this.modo == ModoForm.Alta || this.modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }

            else if (this.modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
            }

            this.txtIdEspecialidad.Text = this.EspecialidadActual.ID.ToString();
            this.txtDescripcion.Text = this.EspecialidadActual.Descripcion;
        }





        //Done
        public override void MapearADatos()
        {
            if (this.modo == ModoForm.Alta)
            {
                EspecialidadActual = new Especialidad();
            }

            this.EspecialidadActual.Descripcion = this.txtDescripcion.Text;
        }





        //Done
        public override void GuardarCambios()
        {

            especialidadLogic = new EspecialidadLogic();

            if (this.modo == ModoForm.Alta)
            {
                this.MapearADatos();
                especialidadLogic.Save(EspecialidadActual);
            }

            else if (this.modo == ModoForm.Modificacion)
            {
                this.MapearADatos();
                especialidadLogic.Save(EspecialidadActual);
            }

            else if (this.modo == ModoForm.Baja)
            {
                especialidadLogic.Save(EspecialidadActual);
            }
            


        }

    

        //Done
        public override bool Validar()
        {
            
            bool bandera = true;

            if (!Validaciones.IsFieldEmpty(txtDescripcion.Text))
            {
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

            bool bandera = true;

            if (this.modo == ModoForm.Alta)
            {
                
                bandera = this.Validar();

                if (bandera)
                {
                    this.GuardarCambios();
                    this.Notificar("Alta de Especialidad", "Especialidad agregada correctamente", MessageBoxButtons.OK, MessageBoxIcon.None);
                }

                else
                {
                    this.Notificar("Alta de Especialidad", "La especialidad no pudo ser agregada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }


            else if (this.modo == ModoForm.Baja)
            {
                this.EspecialidadActual.State = Business.Entities.BusinessEntity.States.Deleted;
                this.GuardarCambios();
                this.Notificar("Baja de especialidad", "Especialidad eliminada correctamente", MessageBoxButtons.OK, MessageBoxIcon.None);
            }



            else if (this.modo == ModoForm.Modificacion)
            {
                this.EspecialidadActual.State = Business.Entities.BusinessEntity.States.Modified;
                bandera = this.Validar();

                if (bandera)
                {
                    this.GuardarCambios();
                    this.Notificar("Modificación de especialidad", "Especialidad actualizada correctamente", MessageBoxButtons.OK, MessageBoxIcon.None);
                }

                else
                {
                    this.Notificar("Modificación de especialidad", "La especialidad no pudo ser actualizada correctamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            this.Close();
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void tlEspecialidadesDesktop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
    