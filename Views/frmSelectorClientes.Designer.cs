namespace RutinApp.Views
{
    partial class frmSelectorClientes
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dgvClientes = new DataGridView();
            Column3 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            apellido1 = new DataGridViewTextBoxColumn();
            column4 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            btnNew = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            txtFilter = new TextBox();
            label14 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // dgvClientes
            // 
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.AllowUserToOrderColumns = true;
            dgvClientes.BorderStyle = BorderStyle.Fixed3D;
            dgvClientes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Columns.AddRange(new DataGridViewColumn[] { Column3, Column1, apellido1, column4, Column2 });
            dgvClientes.Location = new Point(10, 9);
            dgvClientes.Margin = new Padding(3, 2, 3, 2);
            dgvClientes.MultiSelect = false;
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.RowHeadersVisible = false;
            dgvClientes.RowHeadersWidth = 51;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.Size = new Size(398, 293);
            dgvClientes.TabIndex = 0;
            dgvClientes.MouseDoubleClick += dgvClientes_MouseDoubleClick;
            // 
            // Column3
            // 
            Column3.HeaderText = "Id Cliente";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Width = 68;
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column1.HeaderText = "Nombre";
            Column1.MinimumWidth = 80;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // apellido1
            // 
            apellido1.HeaderText = "1er Apellido";
            apellido1.Name = "apellido1";
            apellido1.ReadOnly = true;
            // 
            // column4
            // 
            column4.HeaderText = "2do Apellido";
            column4.Name = "column4";
            column4.ReadOnly = true;
            column4.Width = 105;
            // 
            // Column2
            // 
            Column2.HeaderText = "Telefono";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Visible = false;
            Column2.Width = 125;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(278, 307);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(62, 23);
            btnNew.TabIndex = 2;
            btnNew.Text = "Nuevo";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(210, 307);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(62, 23);
            btnEditar.TabIndex = 3;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(346, 307);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(62, 23);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // txtFilter
            // 
            txtFilter.AcceptsTab = true;
            txtFilter.Location = new Point(49, 308);
            txtFilter.Margin = new Padding(3, 2, 3, 2);
            txtFilter.Name = "txtFilter";
            txtFilter.Size = new Size(155, 23);
            txtFilter.TabIndex = 11;
            txtFilter.TextChanged += txtFilter_TextChanged;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(10, 311);
            label14.Name = "label14";
            label14.Size = new Size(37, 15);
            label14.TabIndex = 12;
            label14.Text = "Filtro:";
            // 
            // frmSelectorClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 338);
            Controls.Add(label14);
            Controls.Add(txtFilter);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnNew);
            Controls.Add(dgvClientes);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmSelectorClientes";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Seleccione cliente a cargar";
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvClientes;
        private Button btnNew;
        private Button btnEditar;
        private Button btnEliminar;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn apellido1;
        private DataGridViewTextBoxColumn column4;
        private DataGridViewTextBoxColumn Column2;
        private TextBox txtFilter;
        private Label label14;
    }
}