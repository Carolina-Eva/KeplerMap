namespace UI
{
    partial class treeView
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
            treeView1 = new TreeView();
            Quitar_Elemento = new Button();
            Agregar_Elemento = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            groupBox1 = new GroupBox();
            listBox2 = new ListBox();
            listBox1 = new ListBox();
            groupBox2 = new GroupBox();
            Modificar_Eliminar = new Button();
            Elminar_Elemento = new Button();
            Crear_Elemento = new Button();
            groupBox3 = new GroupBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.Location = new Point(32, 70);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(386, 514);
            treeView1.TabIndex = 0;
            treeView1.AfterSelect += TreeView1_AfterSelect;
            // 
            // Quitar_Elemento
            // 
            Quitar_Elemento.Location = new Point(46, 350);
            Quitar_Elemento.Name = "Quitar_Elemento";
            Quitar_Elemento.Size = new Size(203, 39);
            Quitar_Elemento.TabIndex = 3;
            Quitar_Elemento.Text = "Quitar Elemento";
            Quitar_Elemento.UseVisualStyleBackColor = true;
            Quitar_Elemento.Click += Quitar_Elemento_Click;
            // 
            // Agregar_Elemento
            // 
            Agregar_Elemento.Location = new Point(279, 350);
            Agregar_Elemento.Name = "Agregar_Elemento";
            Agregar_Elemento.Size = new Size(205, 38);
            Agregar_Elemento.TabIndex = 4;
            Agregar_Elemento.Text = "Agregar Elemento";
            Agregar_Elemento.UseVisualStyleBackColor = true;
            Agregar_Elemento.Click += Agregar_Elemento_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 37);
            label1.Name = "label1";
            label1.Size = new Size(158, 15);
            label1.TabIndex = 5;
            label1.Text = "Arbol de elementos estelares";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(473, 78);
            label2.Name = "label2";
            label2.Size = new Size(117, 15);
            label2.TabIndex = 6;
            label2.Text = "Elementos Aplicados";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(700, 79);
            label3.Name = "label3";
            label3.Size = new Size(126, 15);
            label3.TabIndex = 7;
            label3.Text = "Elementos Disponibles";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(listBox2);
            groupBox1.Controls.Add(listBox1);
            groupBox1.Controls.Add(Quitar_Elemento);
            groupBox1.Controls.Add(Agregar_Elemento);
            groupBox1.Location = new Point(441, 49);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(507, 412);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Administrar elementos";
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(279, 67);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(205, 259);
            listBox2.TabIndex = 6;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(46, 67);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(203, 259);
            listBox1.TabIndex = 5;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(Modificar_Eliminar);
            groupBox2.Controls.Add(Elminar_Elemento);
            groupBox2.Controls.Add(Crear_Elemento);
            groupBox2.Location = new Point(441, 481);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(507, 103);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "ABM";
            // 
            // Modificar_Eliminar
            // 
            Modificar_Eliminar.Location = new Point(205, 38);
            Modificar_Eliminar.Name = "Modificar_Eliminar";
            Modificar_Eliminar.Size = new Size(125, 41);
            Modificar_Eliminar.TabIndex = 2;
            Modificar_Eliminar.Text = "Modificar Elemento";
            Modificar_Eliminar.UseVisualStyleBackColor = true;
            Modificar_Eliminar.Click += Modificar_Eliminar_Click;
            // 
            // Elminar_Elemento
            // 
            Elminar_Elemento.Location = new Point(368, 38);
            Elminar_Elemento.Name = "Elminar_Elemento";
            Elminar_Elemento.Size = new Size(126, 41);
            Elminar_Elemento.TabIndex = 1;
            Elminar_Elemento.Text = "Eliminar Elemento";
            Elminar_Elemento.UseVisualStyleBackColor = true;
            Elminar_Elemento.Click += Elminar_Elemento_Click;
            // 
            // Crear_Elemento
            // 
            Crear_Elemento.Location = new Point(38, 38);
            Crear_Elemento.Name = "Crear_Elemento";
            Crear_Elemento.Size = new Size(125, 41);
            Crear_Elemento.TabIndex = 0;
            Crear_Elemento.Text = "Crear Elemento";
            Crear_Elemento.UseVisualStyleBackColor = true;
            Crear_Elemento.Click += Crear_Elemento_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label1);
            groupBox3.Location = new Point(12, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(960, 626);
            groupBox3.TabIndex = 10;
            groupBox3.TabStop = false;
            groupBox3.Text = "Kepler Map";
            // 
            // treeView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 661);
            Controls.Add(groupBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(treeView1);
            Controls.Add(groupBox1);
            Controls.Add(groupBox3);
            Name = "treeView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView treeView1;
        private Button Quitar_Elemento;
        private Button Agregar_Elemento;
        private Label label1;
        private Label label2;
        private Label label3;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button Crear_Elemento;
        private ListBox listBox2;
        private ListBox listBox1;
        private Button Elminar_Elemento;
        private GroupBox groupBox3;
        private Button Modificar_Eliminar;
    }
}