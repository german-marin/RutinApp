namespace RutinApp.Views
{
    partial class frmSelectorImagenes
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
            flpImagenes = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // flpImagenes
            // 
            flpImagenes.AutoScroll = true;
            flpImagenes.Dock = DockStyle.Fill;
            flpImagenes.Location = new Point(0, 0);
            flpImagenes.Name = "flpImagenes";
            flpImagenes.Size = new Size(800, 450);
            flpImagenes.TabIndex = 1;
            // 
            // frmSelectorImagenes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(flpImagenes);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmSelectorImagenes";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Seleccione una imagen";
            TopMost = true;
            Load += frmSelectorImagenes_Load;
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpImagenes;
    }
}