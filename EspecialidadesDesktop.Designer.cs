
namespace UI.Desktop
{
    partial class frmEspecialidadesDesktop
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
            this.tlEspecialidadesDesktop = new System.Windows.Forms.TableLayoutPanel();
            this.lblIdEspecialidad = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtIdEspecialidad = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.tlEspecialidadesDesktop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlEspecialidadesDesktop
            // 
            this.tlEspecialidadesDesktop.ColumnCount = 2;
            this.tlEspecialidadesDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.125F));
            this.tlEspecialidadesDesktop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.875F));
            this.tlEspecialidadesDesktop.Controls.Add(this.lblIdEspecialidad, 0, 0);
            this.tlEspecialidadesDesktop.Controls.Add(this.lblDescripcion, 0, 1);
            this.tlEspecialidadesDesktop.Controls.Add(this.txtIdEspecialidad, 1, 0);
            this.tlEspecialidadesDesktop.Controls.Add(this.txtDescripcion, 1, 1);
            this.tlEspecialidadesDesktop.Controls.Add(this.btnCancelar, 1, 2);
            this.tlEspecialidadesDesktop.Controls.Add(this.btnAceptar, 0, 2);
            this.tlEspecialidadesDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlEspecialidadesDesktop.Location = new System.Drawing.Point(0, 0);
            this.tlEspecialidadesDesktop.Name = "tlEspecialidadesDesktop";
            this.tlEspecialidadesDesktop.RowCount = 3;
            this.tlEspecialidadesDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlEspecialidadesDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlEspecialidadesDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlEspecialidadesDesktop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlEspecialidadesDesktop.Size = new System.Drawing.Size(800, 450);
            this.tlEspecialidadesDesktop.TabIndex = 0;
            this.tlEspecialidadesDesktop.Paint += new System.Windows.Forms.PaintEventHandler(this.tlEspecialidadesDesktop_Paint);
            // 
            // lblIdEspecialidad
            // 
            this.lblIdEspecialidad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIdEspecialidad.AutoSize = true;
            this.lblIdEspecialidad.Location = new System.Drawing.Point(73, 68);
            this.lblIdEspecialidad.Name = "lblIdEspecialidad";
            this.lblIdEspecialidad.Size = new System.Drawing.Size(78, 13);
            this.lblIdEspecialidad.TabIndex = 0;
            this.lblIdEspecialidad.Text = "Id especialidad";
            this.lblIdEspecialidad.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(81, 218);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Descripcion";
            // 
            // txtIdEspecialidad
            // 
            this.txtIdEspecialidad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtIdEspecialidad.Location = new System.Drawing.Point(228, 65);
            this.txtIdEspecialidad.Name = "txtIdEspecialidad";
            this.txtIdEspecialidad.ReadOnly = true;
            this.txtIdEspecialidad.Size = new System.Drawing.Size(569, 20);
            this.txtIdEspecialidad.TabIndex = 3;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDescripcion.Location = new System.Drawing.Point(228, 215);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(569, 20);
            this.txtDescripcion.TabIndex = 4;
            this.txtDescripcion.TextChanged += new System.EventHandler(this.txtDescripcion_TextChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancelar.Location = new System.Drawing.Point(228, 363);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAceptar.Location = new System.Drawing.Point(75, 363);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmEspecialidadesDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tlEspecialidadesDesktop);
            this.Name = "frmEspecialidadesDesktop";
            this.Text = "EspecialidadesDesktop";
            this.Load += new System.EventHandler(this.EspecialidadesDesktop_Load);
            this.tlEspecialidadesDesktop.ResumeLayout(false);
            this.tlEspecialidadesDesktop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlEspecialidadesDesktop;
        private System.Windows.Forms.Label lblIdEspecialidad;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtIdEspecialidad;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}