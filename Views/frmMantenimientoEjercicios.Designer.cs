namespace RutinApp.Views
{
    partial class frmMantenimientoEjercicios
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
            cmbGruposMusculares = new ComboBox();
            label1 = new Label();
            cmbCategoria = new ComboBox();
            label2 = new Label();
            txtEjercicio = new TextBox();
            label3 = new Label();
            pbExercise = new PictureBox();
            chkbActivo = new CheckBox();
            btnAñadir = new Button();
            btnCambiar = new Button();
            lstEjercicios = new ListBox();
            btnSave = new Button();
            btnDelete = new Button();
            btnCancelar = new Button();
            btnNuevoEjercicio = new Button();
            ((System.ComponentModel.ISupportInitialize)pbExercise).BeginInit();
            SuspendLayout();
            // 
            // cmbGruposMusculares
            // 
            cmbGruposMusculares.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGruposMusculares.FormattingEnabled = true;
            cmbGruposMusculares.Location = new Point(24, 76);
            cmbGruposMusculares.Name = "cmbGruposMusculares";
            cmbGruposMusculares.Size = new Size(363, 23);
            cmbGruposMusculares.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 58);
            label1.Name = "label1";
            label1.Size = new Size(92, 15);
            label1.TabIndex = 1;
            label1.Text = "Grupo Muscular";
            // 
            // cmbCategoria
            // 
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.Enabled = false;
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(24, 127);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(363, 23);
            cmbCategoria.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 109);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 1;
            label2.Text = "Categoria";
            // 
            // txtEjercicio
            // 
            txtEjercicio.Location = new Point(24, 181);
            txtEjercicio.Name = "txtEjercicio";
            txtEjercicio.Size = new Size(363, 23);
            txtEjercicio.TabIndex = 2;
            txtEjercicio.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(24, 163);
            label3.Name = "label3";
            label3.Size = new Size(98, 15);
            label3.TabIndex = 1;
            label3.Text = "Nombre ejercicio";
            // 
            // pbExercise
            // 
            pbExercise.BackColor = Color.Transparent;
            pbExercise.Image = Properties.Resources.rutinApp;
            pbExercise.Location = new Point(482, 8);
            pbExercise.Margin = new Padding(3, 2, 3, 2);
            pbExercise.Name = "pbExercise";
            pbExercise.Size = new Size(151, 170);
            pbExercise.SizeMode = PictureBoxSizeMode.Zoom;
            pbExercise.TabIndex = 9;
            pbExercise.TabStop = false;
            // 
            // chkbActivo
            // 
            chkbActivo.AutoSize = true;
            chkbActivo.CheckAlign = ContentAlignment.MiddleRight;
            chkbActivo.Checked = true;
            chkbActivo.CheckState = CheckState.Checked;
            chkbActivo.Location = new Point(24, 218);
            chkbActivo.Name = "chkbActivo";
            chkbActivo.Size = new Size(60, 19);
            chkbActivo.TabIndex = 10;
            chkbActivo.Text = "Activo";
            chkbActivo.UseVisualStyleBackColor = true;
            chkbActivo.Visible = false;
            // 
            // btnAñadir
            // 
            btnAñadir.Location = new Point(482, 203);
            btnAñadir.Name = "btnAñadir";
            btnAñadir.Size = new Size(68, 47);
            btnAñadir.TabIndex = 11;
            btnAñadir.Text = "Nueva imagen";
            btnAñadir.UseVisualStyleBackColor = true;
            btnAñadir.Visible = false;
            btnAñadir.Click += btnAñadir_Click;
            // 
            // btnCambiar
            // 
            btnCambiar.Location = new Point(567, 203);
            btnCambiar.Name = "btnCambiar";
            btnCambiar.Size = new Size(66, 47);
            btnCambiar.TabIndex = 11;
            btnCambiar.Text = "Cambiar Imagen";
            btnCambiar.UseVisualStyleBackColor = true;
            btnCambiar.Visible = false;
            btnCambiar.Click += btnCambiar_Click;
            // 
            // lstEjercicios
            // 
            lstEjercicios.AllowDrop = true;
            lstEjercicios.Enabled = false;
            lstEjercicios.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lstEjercicios.FormattingEnabled = true;
            lstEjercicios.ItemHeight = 15;
            lstEjercicios.Location = new Point(23, 181);
            lstEjercicios.Margin = new Padding(3, 2, 3, 2);
            lstEjercicios.Name = "lstEjercicios";
            lstEjercicios.Size = new Size(642, 94);
            lstEjercicios.TabIndex = 12;
            lstEjercicios.Click += lstEjercicios_Click;
            lstEjercicios.MouseDoubleClick += lstEjercicios_MouseDoubleClick;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(150, 216);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 34);
            btnSave.TabIndex = 13;
            btnSave.Text = "Guardar";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Visible = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(312, 216);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 34);
            btnDelete.TabIndex = 13;
            btnDelete.Text = "Eliminar";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Visible = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(231, 216);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 34);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Visible = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnNuevoEjercicio
            // 
            btnNuevoEjercicio.Enabled = false;
            btnNuevoEjercicio.Location = new Point(393, 127);
            btnNuevoEjercicio.Name = "btnNuevoEjercicio";
            btnNuevoEjercicio.Size = new Size(65, 49);
            btnNuevoEjercicio.TabIndex = 14;
            btnNuevoEjercicio.Text = "Nuevo ejercicio";
            btnNuevoEjercicio.UseVisualStyleBackColor = true;
            btnNuevoEjercicio.Click += btnNew_Click;
            // 
            // frmMantenimientoEjercicios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(677, 289);
            Controls.Add(btnNuevoEjercicio);
            Controls.Add(btnDelete);
            Controls.Add(btnCancelar);
            Controls.Add(btnSave);
            Controls.Add(btnAñadir);
            Controls.Add(btnCambiar);
            Controls.Add(chkbActivo);
            Controls.Add(pbExercise);
            Controls.Add(txtEjercicio);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbCategoria);
            Controls.Add(cmbGruposMusculares);
            Controls.Add(lstEjercicios);
            MaximizeBox = false;
            Name = "frmMantenimientoEjercicios";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mantenimiento de ejercicios";
            Load += frmMantenimientoEjercicios_Load;
            ((System.ComponentModel.ISupportInitialize)pbExercise).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbGruposMusculares;
        private Label label1;
        private ComboBox cmbCategoria;
        private Label label2;
        private TextBox txtEjercicio;
        private Label label3;
        private PictureBox pbExercise;
        private CheckBox chkbActivo;
        private Button btnAñadir;
        private Button btnCambiar;
        private ListBox lstEjercicios;
        private Button btnSave;
        private Button btnDelete;
        private Button btnCancelar;
        private Button btnNuevoEjercicio;
    }
}