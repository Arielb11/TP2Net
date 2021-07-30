using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class frmMain : Form
    {

        //Formulario principal en desarrollo de escritorio
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnAlumnos_Click(object sender, EventArgs e)
        {
            //Con el método ShowDialog(), me aseguro que se muestre el formulario de alumnos, de manera modal
            frmAlumnos frmAlumnos = new frmAlumnos();
            frmAlumnos.ShowDialog();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            //Con el método ShowDialog(), me aseguro que se muestre el formulario de usuarios, de manera modal
            frmUsuarios frmUsuarios = new frmUsuarios();
            frmUsuarios.ShowDialog();
        }

        private void btnProfesores_Click(object sender, EventArgs e)
        {
            //Con el método ShowDialog(), me aseguro que se muestre el formulario de usuarios, de manera modal

        }

        private void btnEspecialidad_Click(object sender, EventArgs e)
        {
            //Con el método ShowDialog(), me aseguro que se muestre el formulario de usuarios, de manera modal
            frmEspecialidades frmEspecialidades = new frmEspecialidades();
            frmEspecialidades.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {

        }


    }
}
