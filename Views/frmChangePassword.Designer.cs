namespace RutinApp.Views
{
    partial class frmChangePassword
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtCurrentPassword = new TextBox();
            txtNewPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            lblCurrentPassword = new Label();
            lblNewPassword = new Label();
            lblConfirmPassword = new Label();
            btnChangePassword = new Button();
            SuspendLayout();
            // 
            // txtCurrentPassword
            // 
            txtCurrentPassword.Location = new Point(131, 28);
            txtCurrentPassword.Name = "txtCurrentPassword";
            txtCurrentPassword.Size = new Size(176, 23);
            txtCurrentPassword.TabIndex = 0;
            txtCurrentPassword.UseSystemPasswordChar = true;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(131, 66);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(176, 23);
            txtNewPassword.TabIndex = 1;
            txtNewPassword.UseSystemPasswordChar = true;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(131, 103);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(176, 23);
            txtConfirmPassword.TabIndex = 2;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // lblCurrentPassword
            // 
            lblCurrentPassword.AutoSize = true;
            lblCurrentPassword.Location = new Point(22, 33);
            lblCurrentPassword.Name = "lblCurrentPassword";
            lblCurrentPassword.Size = new Size(107, 15);
            lblCurrentPassword.TabIndex = 3;
            lblCurrentPassword.Text = "Contraseña Actual:";
            // 
            // lblNewPassword
            // 
            lblNewPassword.AutoSize = true;
            lblNewPassword.Location = new Point(22, 70);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(107, 15);
            lblNewPassword.TabIndex = 4;
            lblNewPassword.Text = "Nueva Contraseña:";
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Location = new Point(2, 108);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(127, 15);
            lblConfirmPassword.TabIndex = 5;
            lblConfirmPassword.Text = "Confirmar Contraseña:";
            // 
            // btnChangePassword
            // 
            btnChangePassword.Location = new Point(131, 141);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(175, 28);
            btnChangePassword.TabIndex = 6;
            btnChangePassword.Text = "Cambiar Contraseña";
            btnChangePassword.UseVisualStyleBackColor = true;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // frmChangePassword
            // 
            AcceptButton = btnChangePassword;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(332, 188);
            Controls.Add(btnChangePassword);
            Controls.Add(lblConfirmPassword);
            Controls.Add(lblNewPassword);
            Controls.Add(lblCurrentPassword);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtNewPassword);
            Controls.Add(txtCurrentPassword);
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "frmChangePassword";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cambiar Contraseña";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.TextBox txtCurrentPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label lblCurrentPassword;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Button btnChangePassword;
    }
}
