namespace RutinApp.Views
{
    partial class frmParametros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParametros));
            label1 = new Label();
            btnCambiar = new Button();
            btnBorrar = new Button();
            txtDays = new TextBox();
            label2 = new Label();
            txtNotasGenerales = new TextBox();
            label3 = new Label();
            btnGuardar = new Button();
            btnCancelar = new Button();
            pbLogo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(47, 34);
            label1.Name = "label1";
            label1.Size = new Size(113, 15);
            label1.TabIndex = 1;
            label1.Text = "Logo de la empresa:";
            // 
            // btnCambiar
            // 
            btnCambiar.Location = new Point(178, 84);
            btnCambiar.Name = "btnCambiar";
            btnCambiar.Size = new Size(75, 23);
            btnCambiar.TabIndex = 2;
            btnCambiar.Text = "Cambiar";
            btnCambiar.UseVisualStyleBackColor = true;
            btnCambiar.Click += btnCambiar_Click;
            // 
            // btnBorrar
            // 
            btnBorrar.Location = new Point(178, 113);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(75, 23);
            btnBorrar.TabIndex = 2;
            btnBorrar.Text = "Borrar";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // txtDays
            // 
            txtDays.Location = new Point(201, 205);
            txtDays.Name = "txtDays";
            txtDays.Size = new Size(52, 23);
            txtDays.TabIndex = 3;
            txtDays.Text = "30";
            txtDays.KeyPress += txtDays_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(47, 208);
            label2.Name = "label2";
            label2.Size = new Size(148, 15);
            label2.TabIndex = 1;
            label2.Text = "Validez de la rutina en días:";
            // 
            // txtNotasGenerales
            // 
            txtNotasGenerales.Location = new Point(47, 267);
            txtNotasGenerales.Margin = new Padding(3, 2, 3, 2);
            txtNotasGenerales.Multiline = true;
            txtNotasGenerales.Name = "txtNotasGenerales";
            txtNotasGenerales.Size = new Size(454, 152);
            txtNotasGenerales.TabIndex = 4;
            txtNotasGenerales.Text = resources.GetString("txtNotasGenerales.Text");
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(47, 250);
            label3.Name = "label3";
            label3.Size = new Size(211, 15);
            label3.TabIndex = 1;
            label3.Text = "Texto predeterminado notas generales:";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(188, 424);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 5;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(269, 424);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // pbLogo
            // 
            pbLogo.BackColor = Color.Transparent;
            pbLogo.Image = Properties.Resources.rutinApp;
            pbLogo.Location = new Point(47, 55);
            pbLogo.Margin = new Padding(3, 2, 3, 2);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(113, 118);
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.TabIndex = 9;
            pbLogo.TabStop = false;
            // 
            // frmParametros
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(533, 450);
            Controls.Add(pbLogo);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(txtNotasGenerales);
            Controls.Add(txtDays);
            Controls.Add(btnBorrar);
            Controls.Add(btnCambiar);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmParametros";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Parametros de la aplicacion";
            Load += frmParametros_Load;
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Button btnCambiar;
        private Button btnBorrar;
        private TextBox txtDays;
        private Label label2;
        private TextBox txtNotasGenerales;
        private Label label3;
        private Button btnGuardar;
        private Button btnCancelar;
        private PictureBox pbLogo;
    }
}