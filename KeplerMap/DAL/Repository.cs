using BE;
using Microsoft.Data.SqlClient;
using System.ComponentModel;
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

        public async Task <List<IComponenteAstronomico>> ListarElementosPorId(int ElementoId)
        {
            string sql = "LISTAR_ELEMENTOS_HIJOS";
            var parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@ElementoId",ElementoId)
            };
            var dataTable = await _acceso.ObtenerData(sql, parametros);
            List<IComponenteAstronomico> componentes = new();
            if (dataTable == null || dataTable.Rows.Count == 0)
                return componentes;
            foreach (DataRow row in dataTable.Rows)
            {
                bool esGrupo = Convert.ToBoolean(row["EsGrupo"]);
                
                var componente = CrearTipo(esGrupo);
                componente.EsGrupo = esGrupo;
                componente.Id = Convert.ToInt32(row["ElementoId"]);
                componente.PadreId = row.IsNull("id_padre") ? (int?)null : Convert.ToInt32(row["id_padre"]);
                componente.Tipo = row["Tipo"]?.ToString() ?? string.Empty;
                componente.Nombre = row["Nombre"]?.ToString() ?? string.Empty;
                componente.Masa = row.IsNull("Masa") ? 0 : Convert.ToDouble(row["Masa"]);
                componente.Distancia = row.IsNull("Distancia") ? 0 : Convert.ToDouble(row["Distancia"]);
                componentes.Add(componente);
            }
            return componentes;
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
                var componente = CrearTipo(esGrupo);
                componente.EsGrupo = esGrupo;
                componente.Id = Convert.ToInt32(row["ElementoId"]);
                componente.PadreId = row.IsNull("id_padre") ? (int?)null : Convert.ToInt32(row["id_padre"]);
                componente.Nombre = row["Nombre"]?.ToString() ?? string.Empty;
                componente.Tipo = row["Tipo"]?.ToString() ?? string.Empty;
                componente.Masa = row.IsNull("Masa") ? 0 : Convert.ToDouble(row["Masa"]);
                componente.Distancia = row.IsNull("Distancia") ? 0 : Convert.ToDouble(row["Distancia"]);

                componentes.Add(componente);
            }

            return componentes
                .GroupBy(e => e.Id)
                .Select(g => g.First())
                .ToList();
        }

        private IComponenteAstronomico CrearTipo(bool esGrupo)
        {
            if (esGrupo)
                return new GrupoAstronomico();
            else
                return new ElementoAstronomico();
        }

        public async Task<bool> GuardarRelacion(int idGroup, int idElemento)
        {
            string sql = "AGREGAR_RELACION_ELEMENTO";
            var parameters = new List<SqlParameter>
            {
                _acceso.CrearParametro("@IdGrupo", idGroup),
                _acceso.CrearParametro("@IdHijo", idElemento)
            };

            int result = await _acceso.Escribir(sql, parameters);
            return result > 0;
        }

        public async Task<bool> EliminarRelacion(int idGroup, int idElemento)
        {
            string sql = "ELIMINAR_RELACION_ELEMENTO";
            var parameters = new List<SqlParameter>
            {
                _acceso.CrearParametro("@IdGrupo", idGroup),
                _acceso.CrearParametro("@IdHijo", idElemento)
            };

            int result = await _acceso.Escribir(sql, parameters);
            return result > 0;
        }

        public async Task<List<TipoAstronomicoDTO>> ObtenerTipoAstronomico()
        {
            string sql = "LISTAR_TIPO_OBJETO";
            List<TipoAstronomicoDTO> tipos = new List<TipoAstronomicoDTO>();
            var dataTable = await _acceso.ObtenerData(sql);

            if (dataTable == null || dataTable.Rows.Count == 0)
                return tipos;

            foreach (DataRow row in dataTable.Rows)
            {
                int id = Convert.ToInt32(row["Id"]);
                string nombre = row["tipoObjeto"]?.ToString() ?? string.Empty;

                tipos.Add(new TipoAstronomicoDTO { Id = id, Tipo = nombre });
                
            }
            return tipos;
        }


        public async Task<int> AgregarElementoAsync(IComponenteAstronomico comp)
        {
            string sql = "AGREGAR_ELEMENTO";
            var parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@Nombre", comp.Nombre),
                _acceso.CrearParametro("@Tipo", (object)comp.Tipo ?? DBNull.Value),
                _acceso.CrearParametro("@Masa", (object)comp.Masa ?? DBNull.Value),
                _acceso.CrearParametro("@Distancia", (object)comp.Distancia ?? DBNull.Value),
                _acceso.CrearParametro("@EsGrupo", comp.EsGrupo),
                _acceso.CrearParametro("@PadreId", comp.PadreId.HasValue ? (object)comp.PadreId.Value : DBNull.Value)
            };

            try
            {
                int nuevoId = await _acceso.ObtenerEscalar(sql, parametros);
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
                string sql = "MODIFICAR_ELEMENTO";
                var parametros = new List<SqlParameter>
                {
                    _acceso.CrearParametro("@Id", comp.Id),
                    _acceso.CrearParametro("@Nombre", comp.Nombre),
                    _acceso.CrearParametro("@Tipo", (object)comp.Tipo ?? DBNull.Value),
                    _acceso.CrearParametro("@Masa", (object)comp.Masa ?? DBNull.Value),
                    _acceso.CrearParametro("@Distancia", (object)comp.Distancia ?? DBNull.Value),
                    _acceso.CrearParametro("@EsGrupo", comp.EsGrupo)
                };

            try
            {
                int result = await _acceso.Escribir(sql, parametros);
                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error SQL al modificar elemento: " + ex.Message, ex);
            }
        }

        public async Task<IComponenteAstronomico?> ObtenerElementoPorIdAsync(int id)
        {
            string sql  = "OBTENER_ELEMENTO_PORID";
            var parametros = new List<SqlParameter>
            {
                _acceso.CrearParametro("@ElementoId", id)
            };
            var data = await _acceso.ObtenerData(sql, parametros);
            if (data == null || data.Rows.Count == 0)
                return null;
            DataRow row = data.Rows[0];
            bool esGrupo = Convert.ToBoolean(row["EsGrupo"]);

                var componente = CrearTipo(esGrupo);
                componente.Id = Convert.ToInt32(row["Id"]);
                componente.Nombre = row["Nombre"]?.ToString() ?? string.Empty;
                componente.Tipo = row["Tipo"]?.ToString() ?? string.Empty;
                componente.Masa = row.IsNull("Masa") ? 0 : Convert.ToDouble(row["Masa"]);
                componente.Distancia = row.IsNull("Distancia") ? 0 : Convert.ToDouble(row["Distancia"]);
            return componente;
        }

        public async Task<(int Codigo, string Mensaje)> BorrarElementoSeguroAsync(int id)
        {
            string sql = "BORRAR_ELEMENTO";
            var parameters = new List<SqlParameter>
            {
                _acceso.CrearParametro("@Id", id)
            };

            try
            {
                var result = await _acceso.EscribirConMensajes(sql, parameters);
                return (result.Codigo, result.Mensaje);
            }
            catch (SqlException ex)
            {
                return (-1, ex.Message); 
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

                return result > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception("No se pudo borrar el elemento: " + ex.Message, ex);
            }
        }

    }
}
