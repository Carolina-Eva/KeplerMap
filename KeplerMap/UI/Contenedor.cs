namespace UI
{
    public partial class Contenedor : Form
    {
        public Contenedor()
        {
            InitializeComponent();
        }

        private void verArbolEstelarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form treeView = new treeView
            {
                MdiParent = this
            };
            treeView.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form loginForm = new login
            {
                MdiParent = this.MdiParent
            };
            loginForm.Show();
            this.Close();
        }
    }
}
