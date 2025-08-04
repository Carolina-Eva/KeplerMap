using BE;
using BLL;
using System.ComponentModel;
using System.Security;
using System.Xml.Linq;

namespace UI
{
    public partial class treeView : Form
    {
        private readonly ElementoManager BLL = new ElementoManager();
        public event Action ElementoModificado;
        private ImageList imageListIconos = new ImageList();
        private TreeNode? nodoSeleccionadoAnterior = null;
        private List<IComponenteAstronomico> _elementos;
        private List<IComponenteAstronomico> _elementosHijos = new List<IComponenteAstronomico>();
        private int _elementoId;

        public treeView()
        {
            InitializeComponent();
            InicializarImageList();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await CargarTreeView();
        }

        private async Task CargarTreeView()
        {
            treeView1.CheckBoxes = true;
            treeView1.Nodes.Clear();
            LimpiarListbox(); 

            var arbol = await BLL.ListarElementosAsync();
            _elementos = arbol;

            foreach (var raiz in arbol)
                treeView1.Nodes.Add(CrearNodo(raiz));

            treeView1.ExpandAll();

            treeView1.AfterCheck += treeView1_AfterCheck;
            treeView1.BeforeCheck += treeView1_BeforeCheck;
        }

        private void LimpiarListbox() {
            listBox1.DataSource = null;
            listBox2.DataSource = null;
        }

        private async Task<List<IComponenteAstronomico>> ObtenerElementosporId(int id)
        {
            _elementosHijos = await BLL.ListarElementosPorIdAsync(id);
            return _elementosHijos;
        }

        private TreeNode CrearNodo(IComponenteAstronomico comp)
        {
            var nodo = new TreeNode($"{comp.Nombre} ({comp.Tipo})")
            {
                Tag = comp,
                ImageKey = comp.EsGrupo ? "grupo" : "elemento",
                SelectedImageKey = comp.EsGrupo ? "grupo" : "elemento"
            };

            if (!comp.EsGrupo)
            {
                nodo.ForeColor = Color.Gray;
                nodo.NodeFont = new Font(treeView1.Font, FontStyle.Italic);
            }

            foreach (var hijo in comp.ObtenerHijos())
                nodo.Nodes.Add(CrearNodo(hijo));

            return nodo;
        }

        private void InicializarImageList()
        {
            imageListIconos.Images.Clear();
            imageListIconos.ImageSize = new Size(25, 25);
            imageListIconos.ColorDepth = ColorDepth.Depth32Bit;
            imageListIconos.Images.Add("grupo", Properties.Resources.icono_grupo);
            imageListIconos.Images.Add("elemento", Properties.Resources.icono_elemento);
            treeView1.ImageList = imageListIconos;
        }

        private void treeView1_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Tag is IComponenteAstronomico comp && !comp.EsGrupo)
            {
                e.Cancel = true;
            }
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.Unknown) return;
            treeView1.AfterCheck -= treeView1_AfterCheck;

            DeseleccionarOtrosNodos(treeView1.Nodes, e.Node);
            _ = ProcesarSeleccionNodoAsync(e.Node);

            treeView1.AfterCheck += treeView1_AfterCheck;
        }

        private void DeseleccionarOtrosNodos(TreeNodeCollection nodes, TreeNode nodoSeleccionado)
        {
            foreach (TreeNode node in nodes)
            {
                if (node != nodoSeleccionado && node.Checked)
                    node.Checked = false;

                if (node.Nodes.Count > 0)
                    DeseleccionarOtrosNodos(node.Nodes, nodoSeleccionado);
            }
        }

        private async Task ProcesarSeleccionNodoAsync(TreeNode node)
        {
            if (node.Checked)
            {
                if (nodoSeleccionadoAnterior != null && nodoSeleccionadoAnterior != node)
                {
                    nodoSeleccionadoAnterior.Checked = false;
                }

                nodoSeleccionadoAnterior = node;

                var componente = node.Tag as IComponenteAstronomico;
                if (componente != null)
                {
                    List<IComponenteAstronomico> elementosHijos = new List<IComponenteAstronomico>();
                    elementosHijos = await ObtenerElementosporId(componente.Id);

                    listBox1.DataSource = null;
                    listBox1.DataSource = elementosHijos;
                    listBox1.DisplayMember = "Nombre";

                    if (_elementos == null || !_elementos.Any())
                    {
                        await CargarTreeView();
                    }

                    var todos = ObtenerTodosLoselementos(_elementos)
                    .DistinctBy(p => p.Id)
                    .ToList();
                    var idsYaAsignados = ObtenerIdsConDescendientes(_elementosHijos);
                    var idsAncestros = ObtenerIdsAncestros(componente);

                    var faltantes = todos
                        .Where(p =>
                            !idsYaAsignados.Contains(p.Id) &&
                            p.Id != componente.Id &&
                            !idsAncestros.Contains(p.Id)
                        )
                        .ToList();

                    listBox2.DataSource = null;
                    listBox2.DataSource = faltantes;
                    listBox2.DisplayMember = "Nombre";
                }
            }
            else
            {
                if (nodoSeleccionadoAnterior == node)
                    nodoSeleccionadoAnterior = null;

                listBox1.DataSource = null;
                listBox2.DataSource = null;
            }
        }

        private void TreeView1_AfterSelect(object? sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.Unknown) return;

            if (e.Node?.IsSelected == true)
            {
                var componente = e.Node.Tag as IComponenteAstronomico;
                if (componente != null)
                {
                    _elementoId = componente.Id;
                }
            }
        }

        private List<IComponenteAstronomico> ObtenerTodosLoselementos(List<IComponenteAstronomico> elementosCompuestos)
        {
            var todos = new List<IComponenteAstronomico>();

            foreach (var elemento in elementosCompuestos)
            {
                todos.Add(elemento);

                var hijos = elemento.ObtenerHijos();
                if (hijos != null && hijos.Any())
                {
                    todos.AddRange(ObtenerTodosLoselementos(hijos));
                }
            }

            return todos;
        }

        private List<int> ObtenerIdsConDescendientes(List<IComponenteAstronomico> elementos)
        {
            var ids = new List<int>();

            foreach (var elemento in elementos)
            {
                ids.Add(elemento.Id);
                var hijos = elemento.ObtenerHijos();
                if (hijos != null && hijos.Any())
                {
                    ids.AddRange(ObtenerIdsConDescendientes(hijos));
                }
            }

            return ids;
        }

        private List<int> ObtenerIdsAncestros(IComponenteAstronomico componente)
        {
            var ids = new List<int>();
            var actual = componente;

            while (actual?.Padre != null)
            {
                ids.Add(actual.Padre.Id);
                actual = actual.Padre;
            }

            return ids;
        }

        private async void Quitar_Elemento_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is not IComponenteAstronomico elementoAQuitar || nodoSeleccionadoAnterior == null)
                return;

            var elementoPadre = nodoSeleccionadoAnterior.Tag as IComponenteAstronomico;
            if (elementoPadre == null)
                return;

            var result = MessageBox.Show(
                $"¿Deseás quitar el permiso \"{elementoAQuitar.Nombre}\" del rol \"{elementoPadre.Nombre}\"?",
                "Confirmar eliminación",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.OK)
            {
                await BLL.EliminarRelacionAsync(elementoPadre.Id, elementoAQuitar.Id);
                await ProcesarSeleccionNodoAsync(nodoSeleccionadoAnterior);
                await CargarTreeView();
            }
        }

        private async void Agregar_Elemento_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem is not IComponenteAstronomico elementoAAgregar || nodoSeleccionadoAnterior == null)
                return;

            var elementoPadre = nodoSeleccionadoAnterior.Tag as IComponenteAstronomico;
            if (elementoPadre == null)
                return;

            var result = MessageBox.Show(
                $"¿Deseás agregar el elemento \"{elementoAAgregar.Nombre}\" al grupo \"{elementoPadre.Nombre}\"?",
                "Confirmar asignación",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.OK)
            {
                await BLL.GuardarRelacionAsync(elementoPadre.Id, elementoAAgregar.Id);
                await ProcesarSeleccionNodoAsync(nodoSeleccionadoAnterior);
                await CargarTreeView();
            }
        }

        private async void Crear_Elemento_Click(object sender, EventArgs e)
        {
            var modificar = new PopUps.Modificar();

            modificar.ElementoModificado += async () => await CargarTreeView();

            modificar.Show();
        }

        private async  void Modificar_Eliminar_Click(object sender, EventArgs e)
        {
            if (_elementoId == 0)
            {
                MessageBox.Show("No se ha seleccionado ningún elemento");
                return;
            }

            var modificar = new PopUps.Modificar(_elementoId);

            modificar.ElementoModificado += async () => await CargarTreeView();

            modificar.Show();
        }

        private async void Elminar_Elemento_Click(object sender, EventArgs e)
        {
            if (_elementoId == 0)
            {
                MessageBox.Show("No se ha seleccionado ningún elemento.");
                return;
            }

            var confirm = MessageBox.Show(
                "¿Está seguro de que desea eliminar este elemento? Esta acción no se puede deshacer.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            var resultado = await BLL.EliminarElementoAsync(_elementoId);

            if (resultado.Codigo == 1)
            {
                MessageBox.Show(resultado.Mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await CargarTreeView();
            }
            else
            {
                MessageBox.Show(resultado.Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                await CargarTreeView();
            }
        }

    }
}
