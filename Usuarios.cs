using System;
using System.Windows.Forms;
using Business.Logic;

namespace UI.Desktop
{
    public partial class frmUsuarios : Form
    {

        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void ToolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        public void Listar()
        {
            UsuarioLogic ul = new UsuarioLogic();
            this.dgvUsuarios.DataSource = ul.GetAll();
        }
        


        private void Usuarios_Load(object sender, EventArgs e)
        {
            this.Listar();
        }
        


        public void BtnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //Botón del menú para modificar
        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            int id = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
            frmUsuarioDesktop modificar = new frmUsuarioDesktop(id, ApplicationForm.ModoForm.Modificacion);
            modificar.ShowDialog();
            this.Listar();
        }





        //Boton del menú para alta. Funciona correctamente, revisar el checkPoint
        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmUsuarioDesktop formUsuario = new frmUsuarioDesktop(ApplicationForm.ModoForm.Alta);
            formUsuario.ShowDialog();
            this.Listar();
        }






        //Boton del menú para eliminar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
            frmUsuarioDesktop baja = new frmUsuarioDesktop(id, ApplicationForm.ModoForm.Baja);
            baja.ShowDialog();
            this.Listar();
        }




        private void tlUsuarios_Paint(object sender, PaintEventArgs e)
        {

        }


        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tcUsuarios_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }
    }
}
