using BE;
using BLL;

namespace UI
{
    public partial class treeView : Form
    {
        private readonly ElementoManager BLL = new ElementoManager();
        public treeView()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarTreeView();
        }

        private async void CargarTreeView()
        {
            treeView1.Nodes.Clear();
            var arbol = await BLL.ListarElementosAsync();

            foreach (var raiz in arbol)
                treeView1.Nodes.Add(CrearNodo(raiz));

            treeView1.ExpandAll();
        }

        private TreeNode CrearNodo(IComponenteAstronomico comp)
        {
            var nodo = new TreeNode($"{comp.Nombre} ({comp.TipoObjeto})") { Tag = comp };

            foreach (var hijo in comp.ObtenerHijos())
                nodo.Nodes.Add(CrearNodo(hijo));

            return nodo;
        }

    }
}
