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
    public partial class frmEspecialidades : Form
    {
        public frmEspecialidades()
        {
            InitializeComponent();
        }
        
        public void Listar()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            this.dgvEspecialidades.DataSource = el.GetAll();
        }
        
        private void Especialidades_Load(object sender, EventArgs e)
        {
            this.Listar();
        }


        //Done
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }


        //Done
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        //Done
        private void tsbAlta_Click(object sender, EventArgs e)
        {
            frmEspecialidadesDesktop formEspecialidad = new frmEspecialidadesDesktop(ApplicationForm.ModoForm.Alta);
            formEspecialidad.ShowDialog();
            this.Listar();
        }


        //Done
        private void tsbModificar_Click(object sender, EventArgs e)
        {
            int id = ((Business.Entities.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
            frmEspecialidadesDesktop modificar = new frmEspecialidadesDesktop(id, ApplicationForm.ModoForm.Modificacion);
            modificar.ShowDialog();
            this.Listar();
        }

        //Done
        private void tsbBaja_Click(object sender, EventArgs e)
        {
            int id = ((Business.Entities.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
            frmEspecialidadesDesktop baja = new frmEspecialidadesDesktop(id, ApplicationForm.ModoForm.Baja);
            baja.ShowDialog();
            this.Listar();
        }
    }
}
