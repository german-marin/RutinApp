﻿namespace RutinApp
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
            btnObtener = new Button();
            dgvCities = new DataGridView();
            name = new DataGridViewTextBoxColumn();
            countryCode = new DataGridViewTextBoxColumn();
            district = new DataGridViewTextBoxColumn();
            trvGruposMusculares = new TreeView();
            ((System.ComponentModel.ISupportInitialize)dgvCities).BeginInit();
            SuspendLayout();
            // 
            // btnObtener
            // 
            btnObtener.Location = new Point(285, 682);
            btnObtener.Name = "btnObtener";
            btnObtener.Size = new Size(159, 61);
            btnObtener.TabIndex = 0;
            btnObtener.Text = "Obtener grupos Musculares";
            btnObtener.UseVisualStyleBackColor = true;
            btnObtener.Click += btnObtener_Click;
            // 
            // dgvCities
            // 
            dgvCities.AllowUserToAddRows = false;
            dgvCities.AllowUserToDeleteRows = false;
            dgvCities.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCities.Columns.AddRange(new DataGridViewColumn[] { name, countryCode, district });
            dgvCities.Location = new Point(12, 28);
            dgvCities.Name = "dgvCities";
            dgvCities.ReadOnly = true;
            dgvCities.RowHeadersWidth = 51;
            dgvCities.Size = new Size(776, 343);
            dgvCities.TabIndex = 1;
            // 
            // name
            // 
            name.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            name.HeaderText = "Grupo Muscular";
            name.MinimumWidth = 6;
            name.Name = "name";
            name.ReadOnly = true;
            name.Width = 130;
            // 
            // countryCode
            // 
            countryCode.HeaderText = "Imagen Delantera";
            countryCode.MinimumWidth = 6;
            countryCode.Name = "countryCode";
            countryCode.ReadOnly = true;
            countryCode.Width = 125;
            // 
            // district
            // 
            district.HeaderText = "Imagen Trasera";
            district.MinimumWidth = 6;
            district.Name = "district";
            district.ReadOnly = true;
            district.Width = 125;
            // 
            // trvGruposMusculares
            // 
            trvGruposMusculares.Location = new Point(12, 405);
            trvGruposMusculares.Name = "trvGruposMusculares";
            trvGruposMusculares.Size = new Size(776, 220);
            trvGruposMusculares.TabIndex = 2;
            trvGruposMusculares.BeforeExpand += trvGruposMusculares_BeforeExpand;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 755);
            Controls.Add(trvGruposMusculares);
            Controls.Add(dgvCities);
            Controls.Add(btnObtener);
            Name = "Form1";
            Text = "RutinApp";
            ((System.ComponentModel.ISupportInitialize)dgvCities).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnObtener;
        private DataGridView dgvCities;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn countryCode;
        private DataGridViewTextBoxColumn district;
        private TreeView trvGruposMusculares;
    }
}
