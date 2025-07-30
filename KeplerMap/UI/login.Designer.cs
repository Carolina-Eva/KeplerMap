namespace UI
{
    partial class login
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
            label1 = new Label();
            groupBox1 = new GroupBox();
            Ingresar = new Button();
            txtPassword = new TextBox();
            txtUsuario = new TextBox();
            label2 = new Label();
            CerrarApp = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 43);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 0;
            label1.Text = "Usuario";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(Ingresar);
            groupBox1.Controls.Add(txtPassword);
            groupBox1.Controls.Add(txtUsuario);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(172, 90);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(462, 271);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Login";
            // 
            // Ingresar
            // 
            Ingresar.Location = new Point(160, 191);
            Ingresar.Name = "Ingresar";
            Ingresar.Size = new Size(121, 42);
            Ingresar.TabIndex = 4;
            Ingresar.Text = "Ingresar";
            Ingresar.UseVisualStyleBackColor = true;
            Ingresar.Click += Ingresar_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(52, 136);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(349, 23);
            txtPassword.TabIndex = 3;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(52, 61);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(349, 23);
            txtUsuario.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(52, 118);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 1;
            label2.Text = "Contraseña";
            // 
            // CerrarApp
            // 
            CerrarApp.Location = new Point(634, 379);
            CerrarApp.Name = "CerrarApp";
            CerrarApp.Size = new Size(127, 47);
            CerrarApp.TabIndex = 2;
            CerrarApp.Text = "Cerrar";
            CerrarApp.UseVisualStyleBackColor = true;
            CerrarApp.Click += CerrarApp_Click;
            // 
            // login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CerrarApp);
            Controls.Add(groupBox1);
            Name = "login";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private Button Ingresar;
        private TextBox txtPassword;
        private TextBox txtUsuario;
        private Label label2;
        private Button CerrarApp;
    }
}
