
namespace UI.Desktop
{
    partial class frmAlumnosDesktop
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlAlumnosDesktop = new System.Windows.Forms.TableLayoutPanel();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtCondicion = new System.Windows.Forms.TextBox();
            this.lblCondicion = new System.Windows.Forms.Label();
            this.txtNota = new System.Windows.Forms.TextBox();
            this.lblNota = new System.Windows.Forms.Label();
            this.txtIdCurso = new System.Windows.Forms.TextBox();
            this.lblIdCurso = new System.Windows.Forms.Label();
            this.txtIdAlumno = new System.Windows.Forms.TextBox();
            this.lblIdAlumno = new System.Windows.Forms.Label();
            this.lblIdUsuario = new System.Windows.Forms.Label();
            this.txtIdUsuario = new System.Windows.Forms.TextBox();
            this.tlAlumnosDesktop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlAlumnosDesktop
            // 
            this.tlAlumnosDesktop.ColumnCount = 2;
            this.tlAlumnosDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.75F));
            this.tlAlumnosDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.25F));
            this.tlAlumnosDesktop.Controls.Add(this.btnAceptar, 0, 5);
            this.tlAlumnosDesktop.Controls.Add(this.btnCancelar, 1, 5);
            this.tlAlumnosDesktop.Controls.Add(this.txtCondicion, 1, 4);
            this.tlAlumnosDesktop.Controls.Add(this.lblCondicion, 0, 4);
            this.tlAlumnosDesktop.Controls.Add(this.txtNota, 1, 3);
            this.tlAlumnosDesktop.Controls.Add(this.lblNota, 0, 3);
            this.tlAlumnosDesktop.Controls.Add(this.txtIdCurso, 1, 2);
            this.tlAlumnosDesktop.Controls.Add(this.lblIdCurso, 0, 2);
            this.tlAlumnosDesktop.Controls.Add(this.txtIdAlumno, 1, 0);
            this.tlAlumnosDesktop.Controls.Add(this.lblIdAlumno, 0, 0);
            this.tlAlumnosDesktop.Controls.Add(this.lblIdUsuario, 0, 1);
            this.tlAlumnosDesktop.Controls.Add(this.txtIdUsuario, 1, 1);
            this.tlAlumnosDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlAlumnosDesktop.Location = new System.Drawing.Point(0, 0);
            this.tlAlumnosDesktop.Name = "tlAlumnosDesktop";
            this.tlAlumnosDesktop.RowCount = 6;
            this.tlAlumnosDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlAlumnosDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlAlumnosDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlAlumnosDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlAlumnosDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlAlumnosDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlAlumnosDesktop.Size = new System.Drawing.Size(800, 450);
            this.tlAlumnosDesktop.TabIndex = 0;
            this.tlAlumnosDesktop.Paint += new System.Windows.Forms.PaintEventHandler(this.tlAlumnosDesktop_Paint);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(3, 373);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoEllipsis = true;
            this.btnCancelar.Location = new System.Drawing.Point(137, 373);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtCondicion
            // 
            this.txtCondicion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCondicion.Location = new System.Drawing.Point(137, 323);
            this.txtCondicion.Name = "txtCondicion";
            this.txtCondicion.Size = new System.Drawing.Size(660, 20);
            this.txtCondicion.TabIndex = 5;
            this.txtCondicion.TextChanged += new System.EventHandler(this.txtCondicion_TextChanged);
            // 
            // lblCondicion
            // 
            this.lblCondicion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCondicion.AutoSize = true;
            this.lblCondicion.Location = new System.Drawing.Point(40, 326);
            this.lblCondicion.Name = "lblCondicion";
            this.lblCondicion.Size = new System.Drawing.Size(54, 13);
            this.lblCondicion.TabIndex = 9;
            this.lblCondicion.Text = "Condicion";
            this.lblCondicion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCondicion.Click += new System.EventHandler(this.lblCondicion_Click);
            // 
            // txtNota
            // 
            this.txtNota.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNota.Location = new System.Drawing.Point(137, 249);
            this.txtNota.Name = "txtNota";
            this.txtNota.Size = new System.Drawing.Size(660, 20);
            this.txtNota.TabIndex = 4;
            this.txtNota.TextChanged += new System.EventHandler(this.txtNota_TextChanged);
            // 
            // lblNota
            // 
            this.lblNota.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNota.AutoSize = true;
            this.lblNota.Location = new System.Drawing.Point(52, 252);
            this.lblNota.Name = "lblNota";
            this.lblNota.Size = new System.Drawing.Size(30, 13);
            this.lblNota.TabIndex = 8;
            this.lblNota.Text = "Nota";
            this.lblNota.Click += new System.EventHandler(this.lblNota_Click);
            // 
            // txtIdCurso
            // 
            this.txtIdCurso.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtIdCurso.Location = new System.Drawing.Point(137, 175);
            this.txtIdCurso.Name = "txtIdCurso";
            this.txtIdCurso.Size = new System.Drawing.Size(660, 20);
            this.txtIdCurso.TabIndex = 11;
            this.txtIdCurso.TextChanged += new System.EventHandler(this.txtIdCurso_TextChanged);
            // 
            // lblIdCurso
            // 
            this.lblIdCurso.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIdCurso.AutoSize = true;
            this.lblIdCurso.Location = new System.Drawing.Point(44, 178);
            this.lblIdCurso.Name = "lblIdCurso";
            this.lblIdCurso.Size = new System.Drawing.Size(46, 13);
            this.lblIdCurso.TabIndex = 7;
            this.lblIdCurso.Text = "Id Curso";
            this.lblIdCurso.Click += new System.EventHandler(this.lblIdCurso_Click);
            // 
            // txtIdAlumno
            // 
            this.txtIdAlumno.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtIdAlumno.Location = new System.Drawing.Point(137, 27);
            this.txtIdAlumno.Name = "txtIdAlumno";
            this.txtIdAlumno.ReadOnly = true;
            this.txtIdAlumno.Size = new System.Drawing.Size(660, 20);
            this.txtIdAlumno.TabIndex = 10;
            this.txtIdAlumno.TextChanged += new System.EventHandler(this.txtIdAlumno_TextChanged);
            // 
            // lblIdAlumno
            // 
            this.lblIdAlumno.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIdAlumno.AutoSize = true;
            this.lblIdAlumno.Location = new System.Drawing.Point(40, 30);
            this.lblIdAlumno.Name = "lblIdAlumno";
            this.lblIdAlumno.Size = new System.Drawing.Size(54, 13);
            this.lblIdAlumno.TabIndex = 6;
            this.lblIdAlumno.Text = "Id Alumno";
            this.lblIdAlumno.Click += new System.EventHandler(this.lblIdAlumno_Click);
            // 
            // lblIdUsuario
            // 
            this.lblIdUsuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIdUsuario.AutoSize = true;
            this.lblIdUsuario.Location = new System.Drawing.Point(40, 104);
            this.lblIdUsuario.Name = "lblIdUsuario";
            this.lblIdUsuario.Size = new System.Drawing.Size(53, 13);
            this.lblIdUsuario.TabIndex = 12;
            this.lblIdUsuario.Text = "Id usuario";
            this.lblIdUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblIdUsuario.Click += new System.EventHandler(this.lblIdUsuario_Click);
            // 
            // txtIdUsuario
            // 
            this.txtIdUsuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtIdUsuario.Location = new System.Drawing.Point(137, 101);
            this.txtIdUsuario.Name = "txtIdUsuario";
            this.txtIdUsuario.Size = new System.Drawing.Size(660, 20);
            this.txtIdUsuario.TabIndex = 13;
            this.txtIdUsuario.TextChanged += new System.EventHandler(this.txtIdUsuario_TextChanged);
            // 
            // frmAlumnosDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tlAlumnosDesktop);
            this.Name = "frmAlumnosDesktop";
            this.Text = "AlumnosDesktop";
            this.Load += new System.EventHandler(this.AlumnosDesktop_Load);
            this.tlAlumnosDesktop.ResumeLayout(false);
            this.tlAlumnosDesktop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlAlumnosDesktop;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtNota;
        private System.Windows.Forms.TextBox txtCondicion;
        private System.Windows.Forms.Label lblIdAlumno;
        private System.Windows.Forms.Label lblIdCurso;
        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.Label lblCondicion;
        private System.Windows.Forms.TextBox txtIdAlumno;
        private System.Windows.Forms.TextBox txtIdCurso;
        private System.Windows.Forms.Label lblIdUsuario;
        private System.Windows.Forms.TextBox txtIdUsuario;
    }
}