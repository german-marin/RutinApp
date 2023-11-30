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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // trvGruposMusculares
            // 
            trvGruposMusculares.Location = new Point(5, 6);
            trvGruposMusculares.Name = "trvGruposMusculares";
            trvGruposMusculares.Size = new Size(600, 271);
            trvGruposMusculares.TabIndex = 2;
            trvGruposMusculares.BeforeExpand += trvGruposMusculares_BeforeExpand;
            trvGruposMusculares.NodeMouseDoubleClick += trvGruposMusculares_NodeMouseDoubleClick;
            // 
            // lstEjercicios
            // 
            lstEjercicios.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lstEjercicios.FormattingEnabled = true;
            lstEjercicios.Location = new Point(298, 12);
            lstEjercicios.Name = "lstEjercicios";
            lstEjercicios.Size = new Size(629, 124);
            lstEjercicios.TabIndex = 3;
            lstEjercicios.Click += lstEjercicios_Click;
            // 
            // pbFront
            // 
            pbFront.BorderStyle = BorderStyle.FixedSingle;
            pbFront.Image = Properties.Resources.MA;
            pbFront.Location = new Point(614, 6);
            pbFront.Name = "pbFront";
            pbFront.Size = new Size(151, 271);
            pbFront.SizeMode = PictureBoxSizeMode.Zoom;
            pbFront.TabIndex = 4;
            pbFront.TabStop = false;
            // 
            // pbBack
            // 
            pbBack.BorderStyle = BorderStyle.FixedSingle;
            pbBack.Image = Properties.Resources.MP;
            pbBack.Location = new Point(773, 6);
            pbBack.Name = "pbBack";
            pbBack.Size = new Size(151, 271);
            pbBack.SizeMode = PictureBoxSizeMode.Zoom;
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
            panel1.Location = new Point(297, 164);
            panel1.Name = "panel1";
            panel1.Size = new Size(475, 183);
            panel1.TabIndex = 5;
            // 
            // txtNotas
            // 
            txtNotas.AcceptsTab = true;
            txtNotas.Enabled = false;
            txtNotas.Location = new Point(170, 154);
            txtNotas.Name = "txtNotas";
            txtNotas.Size = new Size(304, 27);
            txtNotas.TabIndex = 11;
            // 
            // txtOtros
            // 
            txtOtros.AcceptsTab = true;
            txtOtros.Enabled = false;
            txtOtros.Location = new Point(170, 128);
            txtOtros.Name = "txtOtros";
            txtOtros.Size = new Size(304, 27);
            txtOtros.TabIndex = 10;
            // 
            // txtRecuperacion
            // 
            txtRecuperacion.AcceptsTab = true;
            txtRecuperacion.Enabled = false;
            txtRecuperacion.Location = new Point(170, 102);
            txtRecuperacion.Name = "txtRecuperacion";
            txtRecuperacion.Size = new Size(304, 27);
            txtRecuperacion.TabIndex = 9;
            // 
            // txtPeso
            // 
            txtPeso.AcceptsTab = true;
            txtPeso.Enabled = false;
            txtPeso.Location = new Point(170, 76);
            txtPeso.Name = "txtPeso";
            txtPeso.Size = new Size(304, 27);
            txtPeso.TabIndex = 8;
            // 
            // txtRepes
            // 
            txtRepes.AcceptsTab = true;
            txtRepes.Enabled = false;
            txtRepes.Location = new Point(170, 50);
            txtRepes.Name = "txtRepes";
            txtRepes.Size = new Size(304, 27);
            txtRepes.TabIndex = 7;
            // 
            // txtSeries
            // 
            txtSeries.AcceptsTab = true;
            txtSeries.Enabled = false;
            txtSeries.Location = new Point(170, 25);
            txtSeries.Name = "txtSeries";
            txtSeries.Size = new Size(304, 27);
            txtSeries.TabIndex = 6;
            // 
            // label2
            // 
            label2.BackColor = SystemColors.ControlLight;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(169, 0);
            label2.Name = "label2";
            label2.Size = new Size(305, 25);
            label2.TabIndex = 6;
            label2.Text = "Dato";
            // 
            // label8
            // 
            label8.BackColor = SystemColors.ControlLight;
            label8.BorderStyle = BorderStyle.FixedSingle;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label8.Location = new Point(0, 154);
            label8.Name = "label8";
            label8.Size = new Size(170, 27);
            label8.TabIndex = 6;
            label8.Text = "Notas";
            // 
            // label7
            // 
            label7.BackColor = SystemColors.ControlLight;
            label7.BorderStyle = BorderStyle.FixedSingle;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.Location = new Point(0, 128);
            label7.Name = "label7";
            label7.Size = new Size(170, 27);
            label7.TabIndex = 6;
            label7.Text = "Otros";
            // 
            // label6
            // 
            label6.BackColor = SystemColors.ControlLight;
            label6.BorderStyle = BorderStyle.FixedSingle;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(0, 102);
            label6.Name = "label6";
            label6.Size = new Size(170, 27);
            label6.TabIndex = 6;
            label6.Text = "Recuperación";
            // 
            // label5
            // 
            label5.BackColor = SystemColors.ControlLight;
            label5.BorderStyle = BorderStyle.FixedSingle;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(0, 76);
            label5.Name = "label5";
            label5.Size = new Size(170, 27);
            label5.TabIndex = 6;
            label5.Text = "Pesos";
            // 
            // label4
            // 
            label4.BackColor = SystemColors.ControlLight;
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(0, 50);
            label4.Name = "label4";
            label4.Size = new Size(170, 27);
            label4.TabIndex = 6;
            label4.Text = "Repeticiones";
            // 
            // label3
            // 
            label3.BackColor = SystemColors.ControlLight;
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(0, 24);
            label3.Name = "label3";
            label3.Size = new Size(170, 27);
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
            label1.Size = new Size(170, 25);
            label1.TabIndex = 6;
            label1.Text = "Campo";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(3, 356);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(934, 318);
            tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(trvGruposMusculares);
            tabPage1.Controls.Add(pbBack);
            tabPage1.Controls.Add(pbFront);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(926, 285);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Selección de ejercicios";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(926, 285);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Datos del programa";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnAñadir
            // 
            btnAñadir.Enabled = false;
            btnAñadir.Location = new Point(780, 285);
            btnAñadir.Name = "btnAñadir";
            btnAñadir.Size = new Size(135, 29);
            btnAñadir.TabIndex = 7;
            btnAñadir.Text = "Añadir ejercicio";
            btnAñadir.UseVisualStyleBackColor = true;
            btnAñadir.Click += btnAñadir_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(780, 253);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(135, 29);
            btnLimpiar.TabIndex = 7;
            btnLimpiar.Text = "Limpiar Rutina";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGuardar.Location = new Point(790, 165);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(114, 52);
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "Guardar Rutina";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnRecuperar
            // 
            btnRecuperar.Location = new Point(780, 221);
            btnRecuperar.Name = "btnRecuperar";
            btnRecuperar.Size = new Size(135, 29);
            btnRecuperar.TabIndex = 7;
            btnRecuperar.Text = "Recuperar Rutina";
            btnRecuperar.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.muestra;
            pictureBox1.Location = new Point(63, 68);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(173, 226);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // btnBorrar
            // 
            btnBorrar.Enabled = false;
            btnBorrar.Location = new Point(780, 320);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(135, 29);
            btnBorrar.TabIndex = 7;
            btnBorrar.Text = "Borrar ejercicio";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(939, 674);
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
            Name = "Form1";
            Text = "RutinApp";
            ((System.ComponentModel.ISupportInitialize)pbFront).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbBack).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
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
    }
}
