using BLL;

namespace UI
{
    public partial class login : Form
    {
        private UsuarioManager _usuarioManager = new UsuarioManager();
        public login()
        {
            InitializeComponent();
        }

        private async void Ingresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Text.Trim();
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, ingrese usuario y contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                bool esValido = await _usuarioManager.ValidarUsuarioAsync(usuario, password);
                if (!esValido)
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    Form contenedor = new Contenedor();
                    contenedor.Show();
                    this.Hide();
                }
            }
        }

        private void CerrarApp_Click(object sender, EventArgs e)
        {
            this.components?.Dispose();
            this.Close();
        }
    }
}
