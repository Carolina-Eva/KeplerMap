namespace BE
{
    public interface IComponenteAstronomico
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public double Masa { get; set; }
        public double Distancia { get; set; }
        public bool EsGrupo { get; set; }
        public TipoAstronomico TipoObjeto { get; set; }
        public IComponenteAstronomico Padre { get; set; }
        int? PadreId { get; set; }

        public abstract double ObtenerMasaTotal();
        public abstract void Agregar(IComponenteAstronomico componente);
        public abstract void Eliminar(IComponenteAstronomico componente);
        public abstract List<IComponenteAstronomico> ObtenerHijos();
    }
}
