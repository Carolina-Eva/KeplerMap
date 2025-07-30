namespace BLL
{
    public class UsuarioManager
    {
        public async Task<bool> ValidarUsuarioAsync(string usuario, string password)
        {
            var repository = new DAL.Repository();
            return await repository.ValidarUsuario(usuario, password);
        }
    }
}
