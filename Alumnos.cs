﻿using System;
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
    public partial class Alumnos : Form
    {
        public Alumnos()
        {
            InitializeComponent();
        }

        private void Alumnos_Load(object sender, EventArgs e)
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

        public void Listar()
        {
            AlumnoLogic al = new AlumnoLogic();
            this.dgvAlumnos.DataSource = al.GetAll();
        }




        //Botones del menú formulario alumnos
        private void tsbAlta_Click(object sender, EventArgs e)
        {
            AlumnosDesktop formAlumno = new AlumnosDesktop(ApplicationForm.ModoForm.Alta);
            formAlumno.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int id = ((Business.Entities.Alumno)this.dgvAlumnos.SelectedRows[0].DataBoundItem).ID;
            AlumnosDesktop baja = new AlumnosDesktop(id, ApplicationForm.ModoForm.Baja);
            baja.ShowDialog();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {

        }

        private void dgvAlumnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
