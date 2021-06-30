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
    public partial class AlumnosDesktop : ApplicationForm
    {

        Alumno alumnoActual;
        AlumnoLogic alumnoLogic;


        public Alumno AlumnoActual
        {
            set { alumnoActual = value; }
            get { return alumnoActual;}
        }




        //Constructor para las altas
        public AlumnosDesktop(ModoForm modo):this()
        {
            _modo = modo;
        }






        //Constructor para modificaciones
        public AlumnosDesktop(int id, ModoForm modo):this()
        {
            _modo = modo;
            alumnoLogic = new AlumnoLogic();
            alumnoActual = alumnoLogic.GetOne(id);
            this.MapearDeDatos();
        }



        public AlumnosDesktop()
        {
            InitializeComponent();
        }



        private void AlumnosDesktop_Load(object sender, EventArgs e)
        {

        }


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

            this.txtIdAlumno.Text = this.alumnoActual.IdAlumno.ToString();
            this.txtIdCurso.Text = this.alumnoActual.IdCurso.ToString();
            this.txtNota.Text = this.alumnoActual.Nota.ToString();
            this.txtCondicion.Text = this.alumnoActual.Condicion;

        }




        public override void MapearADatos()
        {
            if (this._modo == ModoForm.Alta)
            {
                alumnoActual = new Alumno();
            }

            this.alumnoActual.IdCurso = int.Parse(this.txtIdCurso.Text);
            this.alumnoActual.Nota = int.Parse(this.txtNota.Text);
            this.alumnoActual.Condicion = this.txtCondicion.Text;



        }

        public override void GuardarCambios()
        {
            alumnoLogic = new AlumnoLogic();

            if (this._modo == ModoForm.Alta)
            {
                this.MapearADatos();
                alumnoLogic.Save(alumnoActual);
            }

            else if (this._modo == ModoForm.Modificacion)
            {
                this.MapearADatos();
                alumnoLogic.Save(alumnoActual);
            }

            else if (this._modo == ModoForm.Baja)
            {
                alumnoLogic.Save(alumnoActual);
            }
        }

        public override bool Validar() { return false; }

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

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            if (this._modo == ModoForm.Alta)
            {
                bool bandera = true;
                bandera = this.Validar();

                if (bandera)
                {
                    this.GuardarCambios();
                    MessageBox.Show("Alumno agregado correctamente");
                }

                else
                {
                    MessageBox.Show("El alumno no pudo ser agregado");
                }
            }



            else if (this._modo == ModoForm.Baja)
            {
                this.alumnoActual.State = Business.Entities.BusinessEntity.States.Deleted;
                this.GuardarCambios();
            }



            else if (this._modo == ModoForm.Modificacion)
            {
                this.alumnoActual.State = Business.Entities.BusinessEntity.States.Modified;
                this.GuardarCambios();
            }



            this.Close();




        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
