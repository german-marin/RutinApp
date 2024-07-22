namespace RutinApp.Views
{
    partial class frmSelectorRutinas
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dgvRutinas = new DataGridView();
            Column3 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            btnRecuperar = new Button();
            btnEliminar = new Button();
            label14 = new Label();
            txtFilter = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvRutinas).BeginInit();
            SuspendLayout();
            // 
            // dgvRutinas
            // 
            dgvRutinas.AllowUserToAddRows = false;
            dgvRutinas.AllowUserToDeleteRows = false;
            dgvRutinas.BorderStyle = BorderStyle.Fixed3D;
            dgvRutinas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvRutinas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvRutinas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRutinas.Columns.AddRange(new DataGridViewColumn[] { Column3, Column1, Column2 });
            dgvRutinas.Location = new Point(10, 9);
            dgvRutinas.Margin = new Padding(3, 2, 3, 2);
            dgvRutinas.MultiSelect = false;
            dgvRutinas.Name = "dgvRutinas";
            dgvRutinas.ReadOnly = true;
            dgvRutinas.RowHeadersVisible = false;
            dgvRutinas.RowHeadersWidth = 51;
            dgvRutinas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRutinas.Size = new Size(356, 293);
            dgvRutinas.TabIndex = 0;
            dgvRutinas.DoubleClick += dgvRutinas_DoubleClick;
            // 
            // Column3
            // 
            Column3.HeaderText = "id";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Visible = false;
            Column3.Width = 125;
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column1.HeaderText = "Título rutina";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.HeaderText = "Cliente";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Width = 125;
            // 
            // btnRecuperar
            // 
            btnRecuperar.Location = new Point(220, 306);
            btnRecuperar.Margin = new Padding(3, 2, 3, 2);
            btnRecuperar.Name = "btnRecuperar";
            btnRecuperar.Size = new Size(68, 48);
            btnRecuperar.TabIndex = 1;
            btnRecuperar.Text = "Recuperar Rutina";
            btnRecuperar.UseVisualStyleBackColor = true;
            btnRecuperar.Click += btnRecuperar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(294, 306);
            btnEliminar.Margin = new Padding(3, 2, 3, 2);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(70, 48);
            btnEliminar.TabIndex = 1;
            btnEliminar.Text = "Eliminar Rutina";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(7, 322);
            label14.Name = "label14";
            label14.Size = new Size(37, 15);
            label14.TabIndex = 14;
            label14.Text = "Filtro:";
            // 
            // txtFilter
            // 
            txtFilter.AcceptsTab = true;
            txtFilter.Location = new Point(46, 319);
            txtFilter.Margin = new Padding(3, 2, 3, 2);
            txtFilter.Name = "txtFilter";
            txtFilter.Size = new Size(168, 23);
            txtFilter.TabIndex = 13;
            txtFilter.TextChanged += txtFilter_TextChanged;
            // 
            // frmSelectorRutinas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(376, 361);
            Controls.Add(label14);
            Controls.Add(txtFilter);
            Controls.Add(btnEliminar);
            Controls.Add(btnRecuperar);
            Controls.Add(dgvRutinas);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmSelectorRutinas";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Seleccione rutina a cargar";
            ((System.ComponentModel.ISupportInitialize)dgvRutinas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvRutinas;
        private Button btnEliminar;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private Label label14;
        private TextBox txtFilter;
        internal Button btnRecuperar;
    }
}