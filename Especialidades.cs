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

namespace UI.Desktop
{
    public partial class Especialidades : Form
    {
        public Especialidades()
        {
            InitializeComponent();
        }
        
        public void Listar()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            //this.dgvEspecialidades.DataSource = el.GetAll();
        }
        
        private void Especialidades_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbAlta_Click(object sender, EventArgs e)
        {
            EspecialidadesDesktop formEspecialidad = new EspecialidadesDesktop(ApplicationForm.ModoForm.Alta);
            formEspecialidad.ShowDialog();
            this.Listar();
        }

        private void tsbModificar_Click(object sender, EventArgs e)
        {
            int id = ((Business.Entities.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
            //EspecialidadesDesktop modificar = new EspecialidadesDesktop(id, ApplicationForm.ModoForm.Modificacion);
            //modificar.ShowDialog();
        }

        private void tsbBaja_Click(object sender, EventArgs e)
        {
            int id = ((Business.Entities.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
            //EspecialidadesDesktop baja = new EspecialidadesDesktop(id, ApplicationForm.ModoForm.Baja);
            //baja.ShowDialog();
        }
    }
}
