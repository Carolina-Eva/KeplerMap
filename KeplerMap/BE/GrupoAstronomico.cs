
namespace BE
{
    public class GrupoAstronomico : IComponenteAstronomico
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public double Masa { get; set; }
        public double Distancia { get; set; }
        public IComponenteAstronomico Padre { get; set; }
        public bool EsGrupo { get; set; } = true;
        public int? PadreId { get; set; }
        public TipoAstronomico TipoObjeto { get; set; }

        public List<IComponenteAstronomico> _hijos = new();
        public void Agregar(IComponenteAstronomico componente)
        {
            if (componente == null) return;
            componente.Padre = this;
            _hijos.Add(componente); 
        }
        public void Eliminar(IComponenteAstronomico componente)
        {
            if (_hijos.Contains(componente))
                _hijos.Remove(componente);
        }
        public List<IComponenteAstronomico> ObtenerHijos()
        {
            return _hijos;
        }
        public double ObtenerMasaTotal()
        {
            return Masa + _hijos.Sum(h => h.ObtenerMasaTotal());
        }
    }
}
