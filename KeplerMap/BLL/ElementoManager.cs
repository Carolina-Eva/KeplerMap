using BE;

namespace BLL
{
    public class ElementoManager
    {
        private readonly DAL.Repository _repository;
        public ElementoManager()
        {
            _repository = new DAL.Repository();
        }
        public async Task<List<IComponenteAstronomico>> ListarElementosAsync()
        {
            var listaPlana = await _repository.Listar();

            if (listaPlana == null || listaPlana.Count == 0)
                return new List<IComponenteAstronomico>();

            listaPlana = listaPlana.GroupBy(e => e.Id).Select(g => g.First()).ToList();
            var raices = listaPlana.Where(e => !e.PadreId.HasValue).ToList();

            foreach (var raiz in raices)
                ConstruirHijos(raiz, listaPlana);

            return raices;
        }

        private void ConstruirHijos(IComponenteAstronomico padre, List<IComponenteAstronomico> lista)
        {
            var hijos = lista.Where(e => e.PadreId == padre.Id).ToList();

            foreach (var hijo in hijos)
            {
                (padre as GrupoAstronomico)?.Agregar(hijo);
                ConstruirHijos(hijo, lista);
            }
        }

        public async Task<int> AgregarElementoAsync(IComponenteAstronomico elemento)
        {
            var nuevoId = await _repository.AgregarElementoAsync(elemento);
            return nuevoId; 
        }
        public async Task<bool> modificarElementoAsync(IComponenteAstronomico elemento)
        {
            var result = await _repository.ModificarElementoAsync(elemento);
            return result;
        }
        public async Task<bool> EliminarElementoAsync(int id)
        {
            var result = await _repository.BorrarElementoAsync(id);
            return result;
        }
    }
}
