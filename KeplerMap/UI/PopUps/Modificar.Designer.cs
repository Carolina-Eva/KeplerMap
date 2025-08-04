namespace UI.PopUps
{
    partial class Modificar
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
            groupBox1 = new GroupBox();
            btnEnviar = new Button();
            txtDistancia = new TextBox();
            txtMasa = new TextBox();
            txtTipo = new TextBox();
            txtNombre = new TextBox();
            chkEsGrupo = new CheckBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnEnviar);
            groupBox1.Controls.Add(txtDistancia);
            groupBox1.Controls.Add(txtMasa);
            groupBox1.Controls.Add(txtTipo);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(chkEsGrupo);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(30, 28);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(551, 327);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Crear / Modificar";
            // 
            // btnEnviar
            // 
            btnEnviar.Location = new Point(38, 238);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(135, 39);
            btnEnviar.TabIndex = 11;
            btnEnviar.Text = "Enviar";
            btnEnviar.UseVisualStyleBackColor = true;
            btnEnviar.Click += btnEnviar_Click;
            // 
            // txtDistancia
            // 
            txtDistancia.Location = new Point(289, 55);
            txtDistancia.Name = "txtDistancia";
            txtDistancia.Size = new Size(215, 23);
            txtDistancia.TabIndex = 9;
            // 
            // txtMasa
            // 
            txtMasa.Location = new Point(38, 180);
            txtMasa.Name = "txtMasa";
            txtMasa.Size = new Size(215, 23);
            txtMasa.TabIndex = 8;
            // 
            // txtTipo
            // 
            txtTipo.Location = new Point(38, 117);
            txtTipo.Name = "txtTipo";
            txtTipo.Size = new Size(215, 23);
            txtTipo.TabIndex = 7;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(38, 53);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(215, 23);
            txtNombre.TabIndex = 6;
            // 
            // chkEsGrupo
            // 
            chkEsGrupo.AutoSize = true;
            chkEsGrupo.Location = new Point(299, 117);
            chkEsGrupo.Name = "chkEsGrupo";
            chkEsGrupo.Size = new Size(73, 19);
            chkEsGrupo.TabIndex = 5;
            chkEsGrupo.Text = "Es Grupo";
            chkEsGrupo.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(289, 37);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 3;
            label4.Text = "Distancia";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 162);
            label3.Name = "label3";
            label3.Size = new Size(35, 15);
            label3.TabIndex = 2;
            label3.Text = "Masa";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 99);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 1;
            label2.Text = "Tipo";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 35);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre";
            // 
            // Modificar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(614, 391);
            Controls.Add(groupBox1);
            Name = "Modificar";
            Text = "Form1";
            Load += Modificar_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private CheckBox chkEsGrupo;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnEnviar;
        private TextBox txtDistancia;
        private TextBox txtMasa;
        private TextBox txtTipo;
        private TextBox txtNombre;
    }
}