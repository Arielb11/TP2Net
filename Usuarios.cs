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






        //Botón del menú para modificar
        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            int id = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
            UsuarioDesktop modificar = new UsuarioDesktop(id, ApplicationForm.ModoForm.Modificacion);
            modificar.ShowDialog();
        }





        //Boton del menú para alta. Funciona correctamente, revisar el checkPoint
        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            UsuarioDesktop formUsuario = new UsuarioDesktop(ApplicationForm.ModoForm.Alta);
            //alta.btnAceptar.Text = "Guardar";
            formUsuario.ShowDialog();
            this.Listar();

        }






        //Boton del menú para eliminar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
            UsuarioDesktop baja = new UsuarioDesktop(id, ApplicationForm.ModoForm.Baja);
            baja.ShowDialog();
            
        }








        //Botón del menú para consulta
        private void tsbConsulta_Click(object sender, EventArgs e)
        {
            UsuarioDesktop consulta = new UsuarioDesktop();
            consulta._modo = ApplicationForm.ModoForm.Consulta;
            consulta.Show();
        }






        private void tlUsuarios_Paint(object sender, PaintEventArgs e)
        {

        }






        /*
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
        }*/


        
        private int ConsultaUsuario()
        {
            Business.Entities.Usuario usuario = new Business.Entities.Usuario();
            Data.Database.UsuarioAdapter database = new Data.Database.UsuarioAdapter();
            string id;

            do
            {
                id = Microsoft.VisualBasic.Interaction.InputBox("Ingrese ID", "Consulta por ID", "UsuarioID", 100, 0);
                usuario = database.GetOne(int.Parse(id));

                if (usuario == null)
                {
                    MessageBox.Show("Id incorrecto, por favor ingrese otro");
                }

            } while (usuario == null);

            return int.Parse(id);
        }







        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
