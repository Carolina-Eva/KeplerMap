
namespace BE
{
    public class ElementoAstronomico : IComponenteAstronomico
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public double Masa { get; set; }
        public double Distancia { get; set; }
        public IComponenteAstronomico Padre { get; set; }
        public TipoAstronomico TipoObjeto { get; set; }

        public void Agregar(IComponenteAstronomico componente)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(IComponenteAstronomico componente)
        {
            throw new NotImplementedException();
        }

        public List<IComponenteAstronomico> ObtenerHijos()
        {
            throw new NotImplementedException();
        }

        public double ObtenerMasaTotal()
        {
            throw new NotImplementedException();
        }
    }
}
