using Gsn_ReclameAli.Models;

namespace Gsn_ReclameAli.Interfaces
{
    public interface IUsuarioRepository
    {
        Task SalvarUsuarioAsync(Usuario usuario);

        Task<Usuario> ObterUsuarioAsync(string email);

        Task<Usuario> ObterUsuarioAsync(int usuarioId);

        Task<List<Usuario>> ListarUsuarioAsync();

        void ExcluirUsuarios(Usuario usuario);
    }
}
