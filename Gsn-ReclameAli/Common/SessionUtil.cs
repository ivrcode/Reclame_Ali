using Gsn_ReclameAli.Models;
using Newtonsoft.Json;
using System.Security.Claims;

namespace Gsn_ReclameAli.Common
{
    public static class SessionUtil
    {
        internal static Usuario GetUsuario(this ClaimsPrincipal principal)
        {
            var claim = principal.Claims.SingleOrDefault(p => p.Type == ClaimTypes.UserData);
            var usuario = default(Usuario);
            if (!string.IsNullOrEmpty(claim?.Value))
                usuario = JsonConvert.DeserializeObject<Usuario>(claim.Value);

            return usuario ?? new Usuario();
        }

        internal static int GetUsuarioId(this ClaimsPrincipal principal)
        {
            var claim = principal.Claims.SingleOrDefault(p => p.Type == ClaimTypes.NameIdentifier);
            return claim != null ? Convert.ToInt32(claim.Value) : default;
        }

        internal static string GetNomeUsuario(this ClaimsPrincipal principal)
        {
            var claim = principal.Claims.SingleOrDefault(p => p.Type == ClaimTypes.Name);
            return claim != null ? claim.Value.ToString() : string.Empty;
        }
    }
}
