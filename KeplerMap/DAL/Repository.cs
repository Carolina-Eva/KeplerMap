using BE;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class Repository
    {
        private Acceso _acceso = new Acceso();

        public async Task<bool> ValidarUsuario(string usuario, string password)
        {
            var result = await _acceso.ObtenerEscalar("LOGIN_USUARIO", new List<SqlParameter>
            {
                _acceso.CrearParametro("@Usuario", usuario),
                _acceso.CrearParametro("@Password", password)
            });

            return result != null && Convert.ToInt32(result) > 0;
        }

        public async Task<List<IComponenteAstronomico>> Listar()
        {
            string sql = "LISTAR_ELEMENTOS";
            var dataTable = await _acceso.ObtenerData(sql);
            List<IComponenteAstronomico> componentes = new();

            if (dataTable == null || dataTable.Rows.Count == 0)
                return componentes;

            foreach (DataRow row in dataTable.Rows)
            {
                bool esGrupo = Convert.ToBoolean(row["EsGrupo"]);
                TipoAstronomico tipo;
                Enum.TryParse(row["TipoObjeto"].ToString() ?? string.Empty, out tipo);

                var componente = CrearTipo(esGrupo, tipo);
                componente.EsGrupo = esGrupo;
                componente.Id = Convert.ToInt32(row["ElementoId"]);
                componente.PadreId = row.IsNull("id_padre") ? (int?)null : Convert.ToInt32(row["id_padre"]);
                componente.Nombre = row["Nombre"]?.ToString() ?? string.Empty;
                componente.Masa = row.IsNull("Masa") ? 0 : Convert.ToDouble(row["Masa"]);
                componente.Distancia = row.IsNull("Distancia") ? 0 : Convert.ToDouble(row["Distancia"]);

                componentes.Add(componente);
            }

            return componentes
                .GroupBy(e => e.Id)
                .Select(g => g.First())
                .ToList();
        }

        private IComponenteAstronomico CrearTipo(bool esGrupo, TipoAstronomico tipo)
        {
            if (esGrupo)
                return new GrupoAstronomico { TipoObjeto = tipo };
            else
                return new ElementoAstronomico { TipoObjeto = tipo };
        }

        public async Task<int> AgregarElementoAsync(IComponenteAstronomico comp)
        {
            var parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@Nombre", comp.Nombre),
                _acceso.CrearParametro("@Tipo", (object)comp.Tipo ?? DBNull.Value),
                _acceso.CrearParametro("@Masa", (object)comp.Masa ?? DBNull.Value),
                _acceso.CrearParametro("@Distancia", (object)comp.Distancia ?? DBNull.Value),
                _acceso.CrearParametro("@TipoObjetoId", comp.TipoObjeto),
                _acceso.CrearParametro("@EsGrupo", comp.EsGrupo),
                _acceso.CrearParametro("@PadreId", comp.PadreId.HasValue ? (object)comp.PadreId.Value : DBNull.Value)
            };

            try
            {
                int nuevoId = await _acceso.ObtenerEscalar("AGREGAR_ELEMENTO", parametros);
                if (nuevoId <= 0) throw new Exception("Error al insertar el elemento.");
                return nuevoId;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error SQL al agregar elemento: " + ex.Message, ex);
            }
        }

        public async Task<bool> ModificarElementoAsync(IComponenteAstronomico comp)
            {
                var parametros = new List<SqlParameter>
                {
                    _acceso.CrearParametro("@Id", comp.Id),
                    _acceso.CrearParametro("@Nombre", comp.Nombre),
                    _acceso.CrearParametro("@Tipo", (object)comp.Tipo ?? DBNull.Value),
                    _acceso.CrearParametro("@Masa", (object)comp.Masa ?? DBNull.Value),
                    _acceso.CrearParametro("@Distancia", (object)comp.Distancia ?? DBNull.Value),
                    _acceso.CrearParametro("@TipoObjetoId", comp.TipoObjeto),
                    _acceso.CrearParametro("@EsGrupo", comp.EsGrupo),
                    _acceso.CrearParametro("@PadreId", comp.PadreId.HasValue ? (object)comp.PadreId.Value : DBNull.Value)
                };

            try
            {
                int result = await _acceso.Escribir("MODIFICAR_ELEMENTO", parametros);
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error SQL al modificar elemento: " + ex.Message, ex);
            }
        }

        public async Task<bool> BorrarElementoAsync(int id)
        {
            var parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@Id", id)
            };

            try
            {
                int result = await _acceso.Escribir("BORRAR_ELEMENTO", parametros);

                if (result == -1)
                    throw new Exception("Error desconocido al borrar el elemento.");

                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo borrar el elemento: " + ex.Message, ex);
            }
        }

    }
}
