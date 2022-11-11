using Gsn_ReclameAli.Interfaces;
using Gsn_ReclameAli.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Gsn_ReclameAli.Controllers
{

    public class ProblemaController : Controller
    {
        private readonly IProblemaService _problemaService;
        public ProblemaController(IProblemaService problemaService)
        {
            _problemaService = problemaService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Salvar(ProblemaModel problema)
        {
            if(problema.ProblemaId > default(int))
            {
                await _problemaService.AtualizarProblemaAsync(problema);
                return View("ListarProblema");
            }
            await _problemaService.SalvarProblemaAsync(problema);
            return View("ListarProblema");
        }


        public async Task<IActionResult> ListarProblema()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> ListarProblemas()
        {
            var problema = await _problemaService.ListarProblemaAsync();
            return Json(problema);
        }


        [HttpGet]
        public async Task<IActionResult>EditarProblema(int problemaId)
        {
            try
            {
                var problema = await _problemaService.ObterProblemaAsync(problemaId);
                return View("Index", problema.Model);
            }
            catch(Exception ex)
            {
                throw;
            }
          
        }
                     

        public async Task<IActionResult> DetletarProblema(int problemaId)
        {
            try
            {
                var problema = await _problemaService.DeletarProblemaAsync(problemaId);
                if(problema.StatusCode == HttpStatusCode.OK)
                {
                    ViewBag.Sucess = problema.Mensagem.ToString();
                    return View("ListarProblema");  
                }
                ViewBag.Erro = problema.Mensagem.ToString();
                return View("ListarProblema");
            }
            catch(Exception)
            {
                throw;
            }
           
        }

    }

}

