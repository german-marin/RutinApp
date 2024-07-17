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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            trvGruposMusculares = new TreeView();
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
            btnClientes = new Button();
            txtdias = new TextBox();
            label14 = new Label();
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
            pbExercise = new PictureBox();
            btnBorrar = new Button();
            bsTraining = new BindingSource(components);
            btnImprimir = new Button();
            menuStrip1 = new MenuStrip();
            tsmArchivo = new ToolStripMenuItem();
            tsmRecuperar = new ToolStripMenuItem();
            tsmImprimir = new ToolStripMenuItem();
            editarToolStripMenuItem = new ToolStripMenuItem();
            tsmAltaCliente = new ToolStripMenuItem();
            mantenimientoDeClientesToolStripMenuItem = new ToolStripMenuItem();
            mantenimientoDeEjerciciosToolStripMenuItem = new ToolStripMenuItem();
            ayudaToolStripMenuItem = new ToolStripMenuItem();
            sobreRutinAPPToolStripMenuItem = new ToolStripMenuItem();
            lstEjercicios = new ListBox();
            btnAgarre = new Button();
            pbAgarre = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbFront).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbBack).BeginInit();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbExercise).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsTraining).BeginInit();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbAgarre).BeginInit();
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
            panel1.Location = new Point(260, 141);
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
            tabControl1.Location = new Point(3, 285);
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
            tabPage2.Controls.Add(btnClientes);
            tabPage2.Controls.Add(txtdias);
            tabPage2.Controls.Add(label14);
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
            // btnClientes
            // 
            btnClientes.BackgroundImage = Properties.Resources.buscar;
            btnClientes.BackgroundImageLayout = ImageLayout.Zoom;
            btnClientes.Location = new Point(774, 165);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(23, 23);
            btnClientes.TabIndex = 8;
            btnClientes.UseVisualStyleBackColor = true;
            btnClientes.Click += btnClientes_Click;
            // 
            // txtdias
            // 
            txtdias.Location = new Point(603, 132);
            txtdias.Name = "txtdias";
            txtdias.Size = new Size(34, 23);
            txtdias.TabIndex = 7;
            txtdias.KeyPress += txtdias_KeyPress;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(485, 135);
            label14.Name = "label14";
            label14.Size = new Size(113, 15);
            label14.TabIndex = 6;
            label14.Text = "Días entrenamiento:";
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
            txtCliente.Enabled = false;
            txtCliente.Location = new Point(603, 165);
            txtCliente.Margin = new Padding(3, 2, 3, 2);
            txtCliente.Name = "txtCliente";
            txtCliente.Size = new Size(194, 23);
            txtCliente.TabIndex = 5;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(550, 168);
            label12.Name = "label12";
            label12.Size = new Size(47, 15);
            label12.TabIndex = 4;
            label12.Text = "Cliente:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(510, 109);
            label11.Name = "label11";
            label11.Size = new Size(88, 15);
            label11.TabIndex = 4;
            label11.Text = "Fin de la rutina:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(497, 80);
            label10.Name = "label10";
            label10.Size = new Size(101, 15);
            label10.TabIndex = 4;
            label10.Text = "Inicio de la rutina:";
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Format = DateTimePickerFormat.Short;
            dtpFechaFin.Location = new Point(603, 103);
            dtpFechaFin.Margin = new Padding(3, 2, 3, 2);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(112, 23);
            dtpFechaFin.TabIndex = 3;
            dtpFechaFin.Value = new DateTime(2024, 7, 27, 10, 32, 5, 856);
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaInicio.Location = new Point(603, 74);
            dtpFechaInicio.Margin = new Padding(3, 2, 3, 2);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(110, 23);
            dtpFechaInicio.TabIndex = 2;
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
            btnAñadir.Location = new Point(682, 233);
            btnAñadir.Margin = new Padding(3, 2, 3, 2);
            btnAñadir.Name = "btnAñadir";
            btnAñadir.Size = new Size(118, 23);
            btnAñadir.TabIndex = 7;
            btnAñadir.Text = "Añadir ejercicio";
            btnAñadir.UseVisualStyleBackColor = true;
            btnAñadir.Click += btnAñadir_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(682, 209);
            btnLimpiar.Margin = new Padding(3, 2, 3, 2);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(118, 23);
            btnLimpiar.TabIndex = 7;
            btnLimpiar.Text = "Limpiar Rutina";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Enabled = false;
            btnGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGuardar.Location = new Point(691, 142);
            btnGuardar.Margin = new Padding(3, 2, 3, 2);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(100, 39);
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "Guardar Rutina";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // pbExercise
            // 
            pbExercise.BackColor = Color.Transparent;
            pbExercise.Image = Properties.Resources.rutinApp;
            pbExercise.Location = new Point(55, 37);
            pbExercise.Margin = new Padding(3, 2, 3, 2);
            pbExercise.Name = "pbExercise";
            pbExercise.Size = new Size(151, 170);
            pbExercise.SizeMode = PictureBoxSizeMode.Zoom;
            pbExercise.TabIndex = 8;
            pbExercise.TabStop = false;
            // 
            // btnBorrar
            // 
            btnBorrar.Enabled = false;
            btnBorrar.Location = new Point(682, 257);
            btnBorrar.Margin = new Padding(3, 2, 3, 2);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(118, 23);
            btnBorrar.TabIndex = 7;
            btnBorrar.Text = "Borrar ejercicio";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // btnImprimir
            // 
            btnImprimir.BackgroundImage = Properties.Resources.imprimir;
            btnImprimir.BackgroundImageLayout = ImageLayout.Zoom;
            btnImprimir.Enabled = false;
            btnImprimir.Location = new Point(7, 231);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(51, 48);
            btnImprimir.TabIndex = 9;
            btnImprimir.UseVisualStyleBackColor = true;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { tsmArchivo, editarToolStripMenuItem, ayudaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(822, 24);
            menuStrip1.TabIndex = 10;
            menuStrip1.Text = "menuStrip1";
            // 
            // tsmArchivo
            // 
            tsmArchivo.DropDownItems.AddRange(new ToolStripItem[] { tsmRecuperar, tsmImprimir });
            tsmArchivo.Name = "tsmArchivo";
            tsmArchivo.Size = new Size(60, 20);
            tsmArchivo.Text = "Archivo";
            // 
            // tsmRecuperar
            // 
            tsmRecuperar.Name = "tsmRecuperar";
            tsmRecuperar.Size = new Size(161, 22);
            tsmRecuperar.Text = "Recuperar rutina";
            tsmRecuperar.Click += recuperarRutinaToolStripMenuItem_Click;
            // 
            // tsmImprimir
            // 
            tsmImprimir.Enabled = false;
            tsmImprimir.Name = "tsmImprimir";
            tsmImprimir.Size = new Size(161, 22);
            tsmImprimir.Text = "Imprimir rutina";
            tsmImprimir.Click += imprimirRutinaToolStripMenuItem_Click;
            // 
            // editarToolStripMenuItem
            // 
            editarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tsmAltaCliente, mantenimientoDeClientesToolStripMenuItem, mantenimientoDeEjerciciosToolStripMenuItem });
            editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            editarToolStripMenuItem.Size = new Size(49, 20);
            editarToolStripMenuItem.Text = "Editar";
            // 
            // tsmAltaCliente
            // 
            tsmAltaCliente.Name = "tsmAltaCliente";
            tsmAltaCliente.Size = new Size(224, 22);
            tsmAltaCliente.Text = "Alta cliente";
            tsmAltaCliente.Click += tsmAltaCliente_Click;
            // 
            // mantenimientoDeClientesToolStripMenuItem
            // 
            mantenimientoDeClientesToolStripMenuItem.Name = "mantenimientoDeClientesToolStripMenuItem";
            mantenimientoDeClientesToolStripMenuItem.Size = new Size(224, 22);
            mantenimientoDeClientesToolStripMenuItem.Text = "Mantenimiento de clientes";
            mantenimientoDeClientesToolStripMenuItem.Click += mantenimientoDeClientesToolStripMenuItem_Click;
            // 
            // mantenimientoDeEjerciciosToolStripMenuItem
            // 
            mantenimientoDeEjerciciosToolStripMenuItem.Name = "mantenimientoDeEjerciciosToolStripMenuItem";
            mantenimientoDeEjerciciosToolStripMenuItem.Size = new Size(224, 22);
            mantenimientoDeEjerciciosToolStripMenuItem.Text = "Mantenimiento de ejercicios";
            mantenimientoDeEjerciciosToolStripMenuItem.Click += mantenimientoDeEjerciciosToolStripMenuItem_Click;
            // 
            // ayudaToolStripMenuItem
            // 
            ayudaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { sobreRutinAPPToolStripMenuItem });
            ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            ayudaToolStripMenuItem.Size = new Size(53, 20);
            ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // sobreRutinAPPToolStripMenuItem
            // 
            sobreRutinAPPToolStripMenuItem.Name = "sobreRutinAPPToolStripMenuItem";
            sobreRutinAPPToolStripMenuItem.Size = new Size(180, 22);
            sobreRutinAPPToolStripMenuItem.Text = "Sobre RutinAPP";
            sobreRutinAPPToolStripMenuItem.Click += sobreRutinAPPToolStripMenuItem_Click;
            // 
            // lstEjercicios
            // 
            lstEjercicios.AllowDrop = true;
            lstEjercicios.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lstEjercicios.FormattingEnabled = true;
            lstEjercicios.ItemHeight = 15;
            lstEjercicios.Location = new Point(261, 27);
            lstEjercicios.Margin = new Padding(3, 2, 3, 2);
            lstEjercicios.Name = "lstEjercicios";
            lstEjercicios.Size = new Size(551, 94);
            lstEjercicios.TabIndex = 3;
            lstEjercicios.Click += lstEjercicios_Click;
            lstEjercicios.DragDrop += lstEjercicios_DragDrop;
            lstEjercicios.DragOver += lstEjercicios_DragOver;
            lstEjercicios.MouseDown += lstEjercicios_MouseDown;
            // 
            // btnAgarre
            // 
            btnAgarre.Enabled = false;
            btnAgarre.Location = new Point(682, 185);
            btnAgarre.Margin = new Padding(3, 2, 3, 2);
            btnAgarre.Name = "btnAgarre";
            btnAgarre.Size = new Size(118, 23);
            btnAgarre.TabIndex = 7;
            btnAgarre.Text = "Seleccionar agarre";
            btnAgarre.UseVisualStyleBackColor = true;
            btnAgarre.Click += btnAgarre_Click;
            // 
            // pbAgarre
            // 
            pbAgarre.Location = new Point(99, 212);
            pbAgarre.Name = "pbAgarre";
            pbAgarre.Size = new Size(62, 62);
            pbAgarre.SizeMode = PictureBoxSizeMode.Zoom;
            pbAgarre.TabIndex = 11;
            pbAgarre.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(822, 521);
            Controls.Add(pbAgarre);
            Controls.Add(btnImprimir);
            Controls.Add(pbExercise);
            Controls.Add(btnGuardar);
            Controls.Add(btnAgarre);
            Controls.Add(btnLimpiar);
            Controls.Add(btnBorrar);
            Controls.Add(btnAñadir);
            Controls.Add(panel1);
            Controls.Add(lstEjercicios);
            Controls.Add(tabControl1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RutinApp";
            ((System.ComponentModel.ISupportInitialize)pbFront).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbBack).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbExercise).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsTraining).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbAgarre).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private PictureBox pbExercise;
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
        private BindingSource bsTraining;
        private Button btnImprimir;
        private TextBox txtdias;
        private Label label14;
        private Button btnClientes;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem tsmArchivo;
        private ToolStripMenuItem tsmImprimir;
        private ToolStripMenuItem editarToolStripMenuItem;
        private ToolStripMenuItem ayudaToolStripMenuItem;
        private ToolStripMenuItem tsmAltaCliente;
        private ToolStripMenuItem mantenimientoDeClientesToolStripMenuItem;
        private ToolStripMenuItem mantenimientoDeEjerciciosToolStripMenuItem;
        private ToolStripMenuItem sobreRutinAPPToolStripMenuItem;
        private ToolStripMenuItem tsmRecuperar;
        private Button btnAgarre;
        private PictureBox pbAgarre;
    }
}
