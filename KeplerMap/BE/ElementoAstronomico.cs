
namespace BE
{
    public class ElementoAstronomico : IComponenteAstronomico
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public double Masa { get; set; }
        public double Distancia { get; set; }
        public bool EsGrupo { get; set; } = false;
        public IComponenteAstronomico Padre { get; set; }
        public TipoAstronomico TipoObjeto { get; set; }
        public int? PadreId { get; set; }

        public void Agregar(IComponenteAstronomico componente)
        {
           
        }

        public void Eliminar(IComponenteAstronomico componente)
        {
           
        }

        public List<IComponenteAstronomico> ObtenerHijos()
        {
            return new List<IComponenteAstronomico>();
        }

        public double ObtenerMasaTotal()
        {
           return Masa;
        }
    }
}
