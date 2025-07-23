using BE;
using System.Data;

namespace DAL
{
    public class Repository
    {
        private Acceso _acceso = new Acceso();

        public async Task<List<IComponenteAstronomico>> Listar()
        {
            string sql = "sp_ListarElementosAstronomicos";
            var dataTable = await _acceso.ObtenerData(sql);
            List<IComponenteAstronomico> componentes = new();

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    bool esGrupo = Convert.ToBoolean(row["EsGrupo"]);
                    TipoAstronomico tipo = (TipoAstronomico)Enum.Parse(typeof(TipoAstronomico), row["TipoObjeto"].ToString());

                    var componente = CrearTipo(esGrupo, tipo);
                    componente.Nombre = row["Nombre"].ToString();
                    componente.Masa = Convert.ToDouble(row["Masa"]);
                    componente.Distancia = Convert.ToDouble(row["Distancia"]);

                    componentes.Add(componente);
                }
            }

            return componentes;
        }

        private IComponenteAstronomico CrearTipo(bool esGrupo, TipoAstronomico tipo)
        {
            if (esGrupo)
                return new GrupoAstronomico { TipoObjeto = tipo };
            else
                return new ElementoAstronomico { TipoObjeto = tipo };
        }   

    }
}
