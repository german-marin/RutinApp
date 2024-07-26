namespace RutinApp.Views
{
    partial class frmAltaCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAltaCliente));
            label1 = new Label();
            txtNombre = new TextBox();
            label2 = new Label();
            txtApellido1 = new TextBox();
            label3 = new Label();
            txtApellido2 = new TextBox();
            label4 = new Label();
            label5 = new Label();
            txtTelefono = new TextBox();
            label6 = new Label();
            txtEmail = new TextBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            txtNotas = new TextBox();
            label10 = new Label();
            dtpNacimiento = new DateTimePicker();
            dtpAlta = new DateTimePicker();
            dtpBaja = new DateTimePicker();
            cmbSex = new ComboBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(232, 87);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 1;
            label1.Text = "Genero";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(62, 40);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 43);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 1;
            label2.Text = "Nombre";
            // 
            // txtApellido1
            // 
            txtApellido1.Location = new Point(232, 40);
            txtApellido1.Name = "txtApellido1";
            txtApellido1.Size = new Size(100, 23);
            txtApellido1.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(167, 43);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 1;
            label3.Text = "Apellido 1";
            // 
            // txtApellido2
            // 
            txtApellido2.Location = new Point(402, 40);
            txtApellido2.Name = "txtApellido2";
            txtApellido2.Size = new Size(100, 23);
            txtApellido2.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(337, 43);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 1;
            label4.Text = "Apellido 2";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 87);
            label5.Name = "label5";
            label5.Size = new Size(103, 15);
            label5.TabIndex = 1;
            label5.Text = "Fecha Nacimiento";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(64, 131);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(110, 23);
            txtTelefono.TabIndex = 6;
            txtTelefono.KeyPress += txtTelefono_KeyPress;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 134);
            label6.Name = "label6";
            label6.Size = new Size(52, 15);
            label6.TabIndex = 1;
            label6.Text = "Teléfono";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(224, 131);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(274, 23);
            txtEmail.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(180, 134);
            label7.Name = "label7";
            label7.Size = new Size(36, 15);
            label7.TabIndex = 1;
            label7.Text = "Email";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 178);
            label8.Name = "label8";
            label8.Size = new Size(60, 15);
            label8.TabIndex = 1;
            label8.Text = "Fecha alta";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(212, 178);
            label9.Name = "label9";
            label9.Size = new Size(63, 15);
            label9.TabIndex = 1;
            label9.Text = "Fecha Baja";
            // 
            // txtNotas
            // 
            txtNotas.Location = new Point(62, 221);
            txtNotas.Multiline = true;
            txtNotas.Name = "txtNotas";
            txtNotas.Size = new Size(436, 81);
            txtNotas.TabIndex = 10;
            txtNotas.Text = ".";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(18, 221);
            label10.Name = "label10";
            label10.Size = new Size(38, 15);
            label10.TabIndex = 1;
            label10.Text = "Notas";
            // 
            // dtpNacimiento
            // 
            dtpNacimiento.Format = DateTimePickerFormat.Short;
            dtpNacimiento.Location = new Point(119, 84);
            dtpNacimiento.Name = "dtpNacimiento";
            dtpNacimiento.Size = new Size(95, 23);
            dtpNacimiento.TabIndex = 4;
            // 
            // dtpAlta
            // 
            dtpAlta.Format = DateTimePickerFormat.Short;
            dtpAlta.Location = new Point(72, 172);
            dtpAlta.Name = "dtpAlta";
            dtpAlta.Size = new Size(104, 23);
            dtpAlta.TabIndex = 8;
            // 
            // dtpBaja
            // 
            dtpBaja.Checked = false;
            dtpBaja.Format = DateTimePickerFormat.Short;
            dtpBaja.Location = new Point(281, 175);
            dtpBaja.Name = "dtpBaja";
            dtpBaja.ShowCheckBox = true;
            dtpBaja.Size = new Size(116, 23);
            dtpBaja.TabIndex = 9;
            // 
            // cmbSex
            // 
            cmbSex.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSex.FormattingEnabled = true;
            cmbSex.Items.AddRange(new object[] { "Masculino", "Femenino", "Otro" });
            cmbSex.Location = new Point(283, 84);
            cmbSex.Name = "cmbSex";
            cmbSex.Size = new Size(80, 23);
            cmbSex.TabIndex = 5;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(154, 326);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 11;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(282, 326);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // frmAltaCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(510, 356);
            ControlBox = false;
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(cmbSex);
            Controls.Add(dtpBaja);
            Controls.Add(dtpAlta);
            Controls.Add(dtpNacimiento);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtNotas);
            Controls.Add(txtEmail);
            Controls.Add(txtTelefono);
            Controls.Add(txtApellido2);
            Controls.Add(txtApellido1);
            Controls.Add(txtNombre);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmAltaCliente";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Alta nuevo cliente";
            TopMost = true;
            Load += frmAltaCliente_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private TextBox txtNombre;
        private Label label2;
        private TextBox txtApellido1;
        private Label label3;
        private TextBox txtApellido2;
        private Label label4;
        private Label label5;
        private TextBox txtTelefono;
        private Label label6;
        private TextBox txtEmail;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox txtNotas;
        private Label label10;
        private DateTimePicker dtpNacimiento;
        private DateTimePicker dtpAlta;
        private DateTimePicker dtpBaja;
        private ComboBox cmbSex;
        private Button btnGuardar;
        private Button btnCancelar;
    }
}