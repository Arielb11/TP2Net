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
    public partial class frmAlumnosDesktop : ApplicationForm
    {

        Alumno alumnoActual;
        AlumnoLogic alumnoLogic;


        public Alumno AlumnoActual
        {
            set { alumnoActual = value; }
            get { return alumnoActual;}
        }




        //Constructor para las altas
        public frmAlumnosDesktop(ModoForm modo):this()
        {
            base.modo = modo;
        }



        //Constructor para modificaciones
        public frmAlumnosDesktop(int id, ModoForm modo):this()
        {
            base.modo = modo;
            alumnoLogic = new AlumnoLogic();
            AlumnoActual = alumnoLogic.GetOne(id);
            this.MapearDeDatos();
        }



        public frmAlumnosDesktop()
        {
            InitializeComponent();
        }



        private void AlumnosDesktop_Load(object sender, EventArgs e)
        {
            if (this.modo == ModoForm.Alta)
            {
                this.Text = "Alta de alumno";
            }

            else if (this.modo == ModoForm.Modificacion)
            {
                this.Text = "Modificación de alumno";
            }

            else
            {
                this.Text = "Baja de alumno";
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


            this.txtIdUsuario.Text = this.AlumnoActual.ID.ToString();
            this.txtIdAlumno.Text = this.AlumnoActual.IdAlumno.ToString();
            this.txtIdCurso.Text = this.AlumnoActual.IdCurso.ToString();
            this.txtNota.Text = this.AlumnoActual.Nota.ToString();
            this.txtCondicion.Text = this.AlumnoActual.Condicion;

        }



        //Check It out
        public override void MapearADatos()
        {
            if (this.modo == ModoForm.Alta)
            {
                AlumnoActual = new Alumno();
            }
            
            else if (this.modo == ModoForm.Modificacion)
            {
                AlumnoActual.State = BusinessEntity.States.Modified;
            }

            
            this.AlumnoActual.IdCurso = int.Parse(this.txtIdCurso.Text);
            this.AlumnoActual.Nota = int.Parse(this.txtNota.Text);
            this.AlumnoActual.Condicion = this.txtCondicion.Text;

        }

        public override void GuardarCambios()
        {
            alumnoLogic = new AlumnoLogic();

            if (this.modo == ModoForm.Alta)
            {
                this.MapearADatos();
                alumnoLogic.Save(AlumnoActual);
            }

            else if (this.modo == ModoForm.Modificacion)
            {
                this.MapearDeDatos();
                alumnoLogic.Save(AlumnoActual);
            }

            else if (this.modo == ModoForm.Baja)
            {
                alumnoLogic.Save(AlumnoActual);
            }
        }


        //Done
        public override bool Validar()
        {
            bool bandera = true;

            if (!Validaciones.IsFieldEmpty(this.txtIdUsuario.Text) && !Validaciones.IsFieldEmpty(this.txtIdCurso.Text) && !Validaciones.IsFieldEmpty(this.txtNota.Text) && !Validaciones.IsFieldEmpty(this.txtCondicion.Text))
            {
                this.Notificar("Debe completar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
                return bandera;
            }

            if (!Validaciones.IsFieldEmpty(this.txtIdUsuario.Text))
            {
                this.Notificar("Debe completar el campo Id usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
            }

            if (!Validaciones.IsFieldEmpty(this.txtIdCurso.Text))
            {
                this.Notificar("Debe completar el campo Id de curso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
            }

            if (!Validaciones.IsFieldEmpty(this.txtNota.Text))
            {
                this.Notificar("Debe completar el campo nota", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
            }

            if (!Validaciones.IsFieldEmpty(this.txtCondicion.Text))
            {
                this.Notificar("Debe completar el campo condición", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bandera = false;
            }

            return bandera;
        }

        private void tlAlumnosDesktop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblIdAlumno_Click(object sender, EventArgs e)
        {

        }

        private void lblIdCurso_Click(object sender, EventArgs e)
        {

        }

        private void lblNota_Click(object sender, EventArgs e)
        {

        }

        private void lblCondicion_Click(object sender, EventArgs e)
        {

        }

        private void txtIdAlumno_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIdCurso_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNota_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCondicion_TextChanged(object sender, EventArgs e)
        {

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
                    this.Notificar("Alta de Alumno", "Alumno agregado correctamente", MessageBoxButtons.OK, MessageBoxIcon.None);
                }

                else
                {
                    this.Notificar("Alta de Alumno", "El alumno no pudo ser agregado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }



            else if (this.modo == ModoForm.Baja)
            {
                this.AlumnoActual.State = Business.Entities.BusinessEntity.States.Deleted;
                this.GuardarCambios();
                this.Notificar("Baja de Alumno", "Alumno eliminado correctamente", MessageBoxButtons.OK, MessageBoxIcon.None);
            }



            else if (this.modo == ModoForm.Modificacion)
            {
                this.AlumnoActual.State = Business.Entities.BusinessEntity.States.Modified;
                bandera = this.Validar();
                
                if (bandera)
                {
                    this.GuardarCambios();
                    this.Notificar("Modificación de Alumno", "Alumno actualizado correctamente", MessageBoxButtons.OK, MessageBoxIcon.None);
                }

                else
                {
                    this.Notificar("Modificación de Alumno", "El alumno no pudo ser actualizado correctamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            this.Close();




        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblIdUsuario_Click(object sender, EventArgs e)
        {

        }

        private void txtIdUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
