namespace RutinApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            trvGruposMusculares = new TreeView();
            lstEjercicios = new ListBox();
            pbFront = new PictureBox();
            pbBack = new PictureBox();
            panel1 = new Panel();
            txtNotas = new TextBox();
            txtOtros = new TextBox();
            txtRecuperacion = new TextBox();
            txtPeso = new TextBox();
            txtRepes = new TextBox();
            txtSeries = new TextBox();
            label2 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            txtDescripcion = new TextBox();
            label13 = new Label();
            txtCliente = new TextBox();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            dtpFechaFin = new DateTimePicker();
            dtpFechaInicio = new DateTimePicker();
            label9 = new Label();
            txtNotasGenerales = new TextBox();
            btnAñadir = new Button();
            btnLimpiar = new Button();
            btnGuardar = new Button();
            btnRecuperar = new Button();
            pictureBox1 = new PictureBox();
            btnBorrar = new Button();
            ((System.ComponentModel.ISupportInitialize)pbFront).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbBack).BeginInit();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // trvGruposMusculares
            // 
            trvGruposMusculares.Location = new Point(4, 4);
            trvGruposMusculares.Margin = new Padding(3, 2, 3, 2);
            trvGruposMusculares.Name = "trvGruposMusculares";
            trvGruposMusculares.Size = new Size(526, 204);
            trvGruposMusculares.TabIndex = 2;
            trvGruposMusculares.BeforeExpand += trvGruposMusculares_BeforeExpand;
            trvGruposMusculares.AfterSelect += trvGruposMusculares_AfterSelect;
            trvGruposMusculares.NodeMouseDoubleClick += trvGruposMusculares_NodeMouseDoubleClick;
            // 
            // lstEjercicios
            // 
            lstEjercicios.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lstEjercicios.FormattingEnabled = true;
            lstEjercicios.ItemHeight = 15;
            lstEjercicios.Location = new Point(261, 9);
            lstEjercicios.Margin = new Padding(3, 2, 3, 2);
            lstEjercicios.Name = "lstEjercicios";
            lstEjercicios.Size = new Size(551, 94);
            lstEjercicios.TabIndex = 3;
            lstEjercicios.Click += lstEjercicios_Click;
            // 
            // pbFront
            // 
            pbFront.BorderStyle = BorderStyle.FixedSingle;
            pbFront.ErrorImage = Properties.Resources.MA;
            pbFront.Image = Properties.Resources.MA;
            pbFront.InitialImage = Properties.Resources.MA;
            pbFront.Location = new Point(537, 4);
            pbFront.Margin = new Padding(3, 2, 3, 2);
            pbFront.Name = "pbFront";
            pbFront.Size = new Size(132, 204);
            pbFront.SizeMode = PictureBoxSizeMode.StretchImage;
            pbFront.TabIndex = 4;
            pbFront.TabStop = false;
            // 
            // pbBack
            // 
            pbBack.BorderStyle = BorderStyle.FixedSingle;
            pbBack.ErrorImage = Properties.Resources.MP;
            pbBack.Image = Properties.Resources.MP;
            pbBack.InitialImage = Properties.Resources.MP;
            pbBack.Location = new Point(676, 4);
            pbBack.Margin = new Padding(3, 2, 3, 2);
            pbBack.Name = "pbBack";
            pbBack.Size = new Size(132, 204);
            pbBack.SizeMode = PictureBoxSizeMode.StretchImage;
            pbBack.TabIndex = 4;
            pbBack.TabStop = false;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(txtNotas);
            panel1.Controls.Add(txtOtros);
            panel1.Controls.Add(txtRecuperacion);
            panel1.Controls.Add(txtPeso);
            panel1.Controls.Add(txtRepes);
            panel1.Controls.Add(txtSeries);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(260, 123);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(416, 138);
            panel1.TabIndex = 5;
            // 
            // txtNotas
            // 
            txtNotas.AcceptsTab = true;
            txtNotas.Enabled = false;
            txtNotas.Location = new Point(149, 116);
            txtNotas.Margin = new Padding(3, 2, 3, 2);
            txtNotas.Name = "txtNotas";
            txtNotas.Size = new Size(266, 23);
            txtNotas.TabIndex = 11;
            // 
            // txtOtros
            // 
            txtOtros.AcceptsTab = true;
            txtOtros.Enabled = false;
            txtOtros.Location = new Point(149, 96);
            txtOtros.Margin = new Padding(3, 2, 3, 2);
            txtOtros.Name = "txtOtros";
            txtOtros.Size = new Size(266, 23);
            txtOtros.TabIndex = 10;
            // 
            // txtRecuperacion
            // 
            txtRecuperacion.AcceptsTab = true;
            txtRecuperacion.Enabled = false;
            txtRecuperacion.Location = new Point(149, 76);
            txtRecuperacion.Margin = new Padding(3, 2, 3, 2);
            txtRecuperacion.Name = "txtRecuperacion";
            txtRecuperacion.Size = new Size(266, 23);
            txtRecuperacion.TabIndex = 9;
            // 
            // txtPeso
            // 
            txtPeso.AcceptsTab = true;
            txtPeso.Enabled = false;
            txtPeso.Location = new Point(149, 57);
            txtPeso.Margin = new Padding(3, 2, 3, 2);
            txtPeso.Name = "txtPeso";
            txtPeso.Size = new Size(266, 23);
            txtPeso.TabIndex = 8;
            // 
            // txtRepes
            // 
            txtRepes.AcceptsTab = true;
            txtRepes.Enabled = false;
            txtRepes.Location = new Point(149, 38);
            txtRepes.Margin = new Padding(3, 2, 3, 2);
            txtRepes.Name = "txtRepes";
            txtRepes.Size = new Size(266, 23);
            txtRepes.TabIndex = 7;
            // 
            // txtSeries
            // 
            txtSeries.AcceptsTab = true;
            txtSeries.Enabled = false;
            txtSeries.Location = new Point(149, 19);
            txtSeries.Margin = new Padding(3, 2, 3, 2);
            txtSeries.Name = "txtSeries";
            txtSeries.Size = new Size(266, 23);
            txtSeries.TabIndex = 6;
            // 
            // label2
            // 
            label2.BackColor = SystemColors.ControlLight;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(148, 0);
            label2.Name = "label2";
            label2.Size = new Size(267, 19);
            label2.TabIndex = 6;
            label2.Text = "Dato";
            // 
            // label8
            // 
            label8.BackColor = SystemColors.ControlLight;
            label8.BorderStyle = BorderStyle.FixedSingle;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label8.Location = new Point(0, 116);
            label8.Name = "label8";
            label8.Size = new Size(149, 21);
            label8.TabIndex = 6;
            label8.Text = "Notas";
            // 
            // label7
            // 
            label7.BackColor = SystemColors.ControlLight;
            label7.BorderStyle = BorderStyle.FixedSingle;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.Location = new Point(0, 96);
            label7.Name = "label7";
            label7.Size = new Size(149, 21);
            label7.TabIndex = 6;
            label7.Text = "Otros";
            // 
            // label6
            // 
            label6.BackColor = SystemColors.ControlLight;
            label6.BorderStyle = BorderStyle.FixedSingle;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(0, 76);
            label6.Name = "label6";
            label6.Size = new Size(149, 21);
            label6.TabIndex = 6;
            label6.Text = "Recuperación";
            // 
            // label5
            // 
            label5.BackColor = SystemColors.ControlLight;
            label5.BorderStyle = BorderStyle.FixedSingle;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(0, 57);
            label5.Name = "label5";
            label5.Size = new Size(149, 21);
            label5.TabIndex = 6;
            label5.Text = "Pesos";
            // 
            // label4
            // 
            label4.BackColor = SystemColors.ControlLight;
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(0, 38);
            label4.Name = "label4";
            label4.Size = new Size(149, 21);
            label4.TabIndex = 6;
            label4.Text = "Repeticiones";
            // 
            // label3
            // 
            label3.BackColor = SystemColors.ControlLight;
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(0, 18);
            label3.Name = "label3";
            label3.Size = new Size(149, 21);
            label3.TabIndex = 6;
            label3.Text = "Series";
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ControlLight;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(149, 19);
            label1.TabIndex = 6;
            label1.Text = "Campo";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(3, 267);
            tabControl1.Margin = new Padding(3, 2, 3, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(817, 238);
            tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(trvGruposMusculares);
            tabPage1.Controls.Add(pbBack);
            tabPage1.Controls.Add(pbFront);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(3, 2, 3, 2);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 2, 3, 2);
            tabPage1.Size = new Size(809, 210);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Selección de ejercicios";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(txtDescripcion);
            tabPage2.Controls.Add(label13);
            tabPage2.Controls.Add(txtCliente);
            tabPage2.Controls.Add(label12);
            tabPage2.Controls.Add(label11);
            tabPage2.Controls.Add(label10);
            tabPage2.Controls.Add(dtpFechaFin);
            tabPage2.Controls.Add(dtpFechaInicio);
            tabPage2.Controls.Add(label9);
            tabPage2.Controls.Add(txtNotasGenerales);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(3, 2, 3, 2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 2, 3, 2);
            tabPage2.Size = new Size(809, 210);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Datos del programa";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(485, 40);
            txtDescripcion.Margin = new Padding(3, 2, 3, 2);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(310, 23);
            txtDescripcion.TabIndex = 5;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(485, 22);
            label13.Name = "label13";
            label13.Size = new Size(102, 15);
            label13.TabIndex = 4;
            label13.Text = "Titulo de la rutina:";
            // 
            // txtCliente
            // 
            txtCliente.Location = new Point(601, 135);
            txtCliente.Margin = new Padding(3, 2, 3, 2);
            txtCliente.Name = "txtCliente";
            txtCliente.Size = new Size(194, 23);
            txtCliente.TabIndex = 5;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(545, 137);
            label12.Name = "label12";
            label12.Size = new Size(47, 15);
            label12.TabIndex = 4;
            label12.Text = "Cliente:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(500, 105);
            label11.Name = "label11";
            label11.Size = new Size(88, 15);
            label11.TabIndex = 4;
            label11.Text = "Fin de la rutina:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(485, 76);
            label10.Name = "label10";
            label10.Size = new Size(101, 15);
            label10.TabIndex = 4;
            label10.Text = "Inicio de la rutina:";
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Format = DateTimePickerFormat.Short;
            dtpFechaFin.Location = new Point(601, 103);
            dtpFechaFin.Margin = new Padding(3, 2, 3, 2);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(112, 23);
            dtpFechaFin.TabIndex = 3;
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaInicio.Location = new Point(601, 74);
            dtpFechaInicio.Margin = new Padding(3, 2, 3, 2);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(110, 23);
            dtpFechaInicio.TabIndex = 2;
            dtpFechaInicio.Value = new DateTime(2023, 11, 30, 15, 48, 18, 0);
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(26, 22);
            label9.Name = "label9";
            label9.Size = new Size(94, 15);
            label9.TabIndex = 1;
            label9.Text = "Notas generales:";
            // 
            // txtNotasGenerales
            // 
            txtNotasGenerales.Location = new Point(26, 40);
            txtNotasGenerales.Margin = new Padding(3, 2, 3, 2);
            txtNotasGenerales.Multiline = true;
            txtNotasGenerales.Name = "txtNotasGenerales";
            txtNotasGenerales.Size = new Size(454, 152);
            txtNotasGenerales.TabIndex = 0;
            txtNotasGenerales.Text = resources.GetString("txtNotasGenerales.Text");
            // 
            // btnAñadir
            // 
            btnAñadir.Enabled = false;
            btnAñadir.Location = new Point(682, 214);
            btnAñadir.Margin = new Padding(3, 2, 3, 2);
            btnAñadir.Name = "btnAñadir";
            btnAñadir.Size = new Size(118, 22);
            btnAñadir.TabIndex = 7;
            btnAñadir.Text = "Añadir ejercicio";
            btnAñadir.UseVisualStyleBackColor = true;
            btnAñadir.Click += btnAñadir_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Enabled = false;
            btnLimpiar.Location = new Point(682, 190);
            btnLimpiar.Margin = new Padding(3, 2, 3, 2);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(118, 22);
            btnLimpiar.TabIndex = 7;
            btnLimpiar.Text = "Limpiar Rutina";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Enabled = false;
            btnGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGuardar.Location = new Point(691, 124);
            btnGuardar.Margin = new Padding(3, 2, 3, 2);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 39);
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "Guardar Rutina";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnRecuperar
            // 
            btnRecuperar.Location = new Point(682, 166);
            btnRecuperar.Margin = new Padding(3, 2, 3, 2);
            btnRecuperar.Name = "btnRecuperar";
            btnRecuperar.Size = new Size(118, 22);
            btnRecuperar.TabIndex = 7;
            btnRecuperar.Text = "Recuperar Rutina";
            btnRecuperar.UseVisualStyleBackColor = true;
            btnRecuperar.Click += btnRecuperar_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.muestra;
            pictureBox1.Location = new Point(55, 51);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(151, 170);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // btnBorrar
            // 
            btnBorrar.Enabled = false;
            btnBorrar.Location = new Point(682, 240);
            btnBorrar.Margin = new Padding(3, 2, 3, 2);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(118, 22);
            btnBorrar.TabIndex = 7;
            btnBorrar.Text = "Borrar ejercicio";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(822, 506);
            Controls.Add(pictureBox1);
            Controls.Add(btnRecuperar);
            Controls.Add(btnGuardar);
            Controls.Add(btnLimpiar);
            Controls.Add(btnBorrar);
            Controls.Add(btnAñadir);
            Controls.Add(panel1);
            Controls.Add(lstEjercicios);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "RutinApp";
            ((System.ComponentModel.ISupportInitialize)pbFront).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbBack).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TreeView trvGruposMusculares;
        private ListBox lstEjercicios;
        private PictureBox pbFront;
        private PictureBox pbBack;
        private Panel panel1;
        private Label label2;
        private Label label1;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label8;
        private TextBox txtSeries;
        private TextBox txtNotas;
        private TextBox txtOtros;
        private TextBox txtRecuperacion;
        private TextBox txtPeso;
        private TextBox txtRepes;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button btnAñadir;
        private Button btnLimpiar;
        private Button btnGuardar;
        private Button btnRecuperar;
        private PictureBox pictureBox1;
        private Button btnBorrar;
        private Label label9;
        private TextBox txtNotasGenerales;
        private DateTimePicker dtpFechaInicio;
        private DateTimePicker dtpFechaFin;
        private Label label11;
        private Label label10;
        private TextBox txtCliente;
        private Label label12;
        private TextBox txtDescripcion;
        private Label label13;
    }
}
