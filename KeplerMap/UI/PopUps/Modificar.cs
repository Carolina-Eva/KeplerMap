using BLL;
using BE;

namespace UI.PopUps
{
    public partial class Modificar : Form
    {
        private readonly ElementoManager _manager = new ElementoManager();
        private readonly int? _idElemento;
        public event Action ElementoModificado;

        public Modificar()
        {
            InitializeComponent();
            _idElemento = null;
        }

        public Modificar(int Id) : this()
        {
            _idElemento = Id;
        }

        private async void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos())
                    return;

                if (!chkEsGrupo.Checked)
                {
                    var nuevoElemento = new ElementoAstronomico
                    {
                        Id = _idElemento ?? 0,
                        Nombre = txtNombre.Text.Trim(),
                        Tipo = txtTipo.Text.Trim(),
                        Masa = double.TryParse(txtMasa.Text, out var masa) ? masa : 0,
                        Distancia = double.TryParse(txtDistancia.Text, out var distancia) ? distancia : 0,
                        EsGrupo = chkEsGrupo.Checked
                    };

                    if (_idElemento.HasValue)
                        await _manager.modificarElementoAsync(nuevoElemento);
                    else
                        await _manager.AgregarElementoAsync(nuevoElemento);
                }
                else
                {
                    var nuevoGrupo = new GrupoAstronomico
                    {
                        Id = _idElemento ?? 0,
                        Nombre = txtNombre.Text.Trim(),
                        Tipo = txtTipo.Text.Trim(),
                        Masa = double.TryParse(txtMasa.Text, out var masa) ? masa : 0,
                        Distancia = double.TryParse(txtDistancia.Text, out var distancia) ? distancia : 0,
                        EsGrupo = chkEsGrupo.Checked
                    };

                    if (_idElemento.HasValue)
                        await _manager.modificarElementoAsync(nuevoGrupo);
                    else
                        await _manager.AgregarElementoAsync(nuevoGrupo);
                }

                MessageBox.Show("Elemento guardado correctamente.");
                ElementoModificado?.Invoke();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async void Modificar_Load(object sender, EventArgs e)
        {
            if (_idElemento.HasValue)
            {
                var elm = await _manager.ObtenerElementoPorIdAsync(_idElemento.Value);
                if (elm == null)
                {
                    MessageBox.Show("No se encontró el elemento.");
                    ElementoModificado?.Invoke();
                    Close();
                    return;
                }

                CargarDatosElemento(elm);
            }
        }

        private void CargarDatosElemento(IComponenteAstronomico elem)
        {
            txtNombre.Text = elem.Nombre;
            txtTipo.Text = elem.Tipo;
            txtMasa.Text = elem.Masa.ToString();
            txtDistancia.Text = elem.Distancia.ToString();
            chkEsGrupo.Checked = elem.EsGrupo;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El campo Nombre es obligatorio.");
                return false;
            }

            if (!double.TryParse(txtMasa.Text, out _))
            {
                MessageBox.Show("Masa inválida.");
                return false;
            }

            if (!double.TryParse(txtDistancia.Text, out _))
            {
                MessageBox.Show("Distancia inválida.");
                return false;
            }

            return true;
        }


    }
}
