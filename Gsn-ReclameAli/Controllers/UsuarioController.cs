using Gsn_ReclameAli.Interfaces;
using Gsn_ReclameAli.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Security.Claims;

namespace Gsn_ReclameAli.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SalvarUsuarioAsync(Usuario usuario)
        {
            try
            {

                var result = await _usuarioService.SalvarUsuarioAsync(usuario);
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    return RedirectToAction("Index", "Problema");
                }
                ViewBag.Usuario = $"{result.Mensagem}";
                return View("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logar(string email, string senha)
        {
            var usuario = await _usuarioService.AutenticarUsuarioAsync(email, senha);
            if (usuario.StatusCode == HttpStatusCode.OK)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, usuario.Model.UsuarioId.ToString()),
                    new Claim(ClaimTypes.Name, usuario.Model.Nome),
                    new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(usuario.Model))
                };
                var identity = new ClaimsIdentity(claims, "BRBViagensAuth");
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync("ReclameAliAuth", principal);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Login = $"{usuario.Mensagem}";
            return View("Index");
        }





        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("ReclameAliAuth");
            return RedirectToAction("Index", "Usuario");
        }



        public async Task<IActionResult> ListarUsuario()
        {

            return View();
        }

        [HttpGet]
        public async Task<JsonResult> ListarUsuarios()
        {
            var usuario = await _usuarioService.ListarUsuariosAsync();
            return Json(usuario);
        }


        public async Task<IActionResult> ExcluirUsuarios(int usuarioId)
        {
            try
            {
                var usuario = await _usuarioService.ExcluirUsuarios(usuarioId);
                if (usuario.StatusCode == HttpStatusCode.OK)
                {
                    ViewBag.Sucess = usuario.Mensagem.ToString();
                    return View("ListarUsuario");
                }
                ViewBag.Erro = usuario.Mensagem.ToString();
                return View("ListarUsuario");
            }
            catch (Exception)
            {
                throw;
            }

        }



    }
}
