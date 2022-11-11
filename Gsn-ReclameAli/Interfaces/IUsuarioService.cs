using Gsn_ReclameAli.Common;
using Gsn_ReclameAli.Models;

namespace Gsn_ReclameAli.Interfaces
{
    public interface IUsuarioService
    {
        Task<Resultado<Usuario>> SalvarUsuarioAsync(Usuario usuario);

        Task<Resultado<Usuario>> AutenticarUsuarioAsync(string email, string senha);

        Task<Resultado<List<Usuario>>> ListarUsuariosAsync();

        Task<Resultado<Usuario>> ObterUsuarioAsync(int usuarioId);

        Task<Resultado<Usuario>> ExcluirUsuarios(int usuarioId);
    }
}
