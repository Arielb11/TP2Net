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
    public partial class Usuarios : Form
    {
        public Usuarios()
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






        //Botón para modificar
        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            UsuarioDesktop modificar = new UsuarioDesktop();
            modificar._modo = ApplicationForm.ModoForm.Modificacion;
            this.ConsultaUsuario();
            //modificar.Show();
        }

        //Boton para alta
        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            UsuarioDesktop alta = new UsuarioDesktop();
            alta._modo = ApplicationForm.ModoForm.Alta;
            alta.Show();

        }

        //Boton para eliminar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            UsuarioDesktop baja = new UsuarioDesktop();
            baja._modo = ApplicationForm.ModoForm.Baja;
            baja.Show();
        }


        //Botón para consulta
        private void tsbConsulta_Click(object sender, EventArgs e)
        {
            UsuarioDesktop consulta = new UsuarioDesktop();
            consulta._modo = ApplicationForm.ModoForm.Consulta;
            consulta.Show();
        }

        private void tlUsuarios_Paint(object sender, PaintEventArgs e)
        {

        }




        private Business.Entities.Usuario ConsultaUsuario()
        {
            Business.Entities.Usuario usuario = new Business.Entities.Usuario();
            Data.Database.UsuarioAdapter database = new Data.Database.UsuarioAdapter();
            string id;

            do
            {
                id = Microsoft.VisualBasic.Interaction.InputBox("Ingrese ID", "Consulta por ID", "UsuarioID", 100, 0);
                usuario = database.GetOne(int.Parse(id));

                if(usuario == null)
                {
                    MessageBox.Show("Id incorrecto, por favor ingrese otro");
                }

            } while (usuario == null);

            return usuario;
        }








        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
