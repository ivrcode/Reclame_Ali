using Gsn_ReclameAli.Common;
using Gsn_ReclameAli.Interfaces;
using Gsn_ReclameAli.Models;

namespace Gsn_ReclameAli.Services
{
    public class ProblemaService : IProblemaService
    {
        private readonly IProblemaRepository _problemaRepository;

        public ProblemaService(IProblemaRepository problemaRepository)
        {
            _problemaRepository = problemaRepository;

        }

        public async Task SalvarProblemaAsync(ProblemaModel problema)
        {
            try
            {
                await _problemaRepository.SalvarProblemaAsync(problema);

            }
            catch (Exception ex)
            {
            }
        }

        public async Task<Resultado<ProblemaModel>> AtualizarProblemaAsync(ProblemaModel problema)
        {
            try
            {
                _problemaRepository.AtualizarProblemaAsync(problema);
                return Resultado<ProblemaModel>.SucessoMensagem("Usuário atualizado com sucesso!");

            }
            catch (Exception ex)
            {
                return Resultado<ProblemaModel>.ErroMensagem($"Erro ao atualizar o Problema {ex.Message}!");
            }
        }

        public async Task<Resultado<List<ProblemaModel>>> ListarProblemaAsync()
        {
            try
            {
                var lstproblema = await _problemaRepository.ListarProblemaAsync();
                var resultado = new Resultado<List<ProblemaModel>>()
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Model = lstproblema
                };
                return resultado;
            }
            catch (Exception ex)
            {
                return new Resultado<List<ProblemaModel>>()
                {
                    Mensagem = $"Erro ao Listar Problemas{ex.Message}!",
                    StatusCode = System.Net.HttpStatusCode.OK
                };
            }
        }

        public async Task<Resultado<ProblemaModel>> ObterProblemaAsync(int problemaId)
        {
            try
            {
                var problemaModel = await _problemaRepository.ObterProblemaAsync(problemaId);
                var resultado = new Resultado<ProblemaModel>()
                {
                    Mensagem = "Problema obtido com sucesso!",
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Model = problemaModel
                };

                return resultado;
            }
            catch (Exception ex)
            {
                return Resultado<ProblemaModel>.ErroMensagem($"Erro ao obter o problema {ex.Message}!");
            }
        }

        public async Task<Resultado<ProblemaModel>> DeletarProblemaAsync(int problemaid)
        {
            try
            {
                var problemaModel = await ObterProblemaAsync(problemaid);
                _problemaRepository.DeletarProblemaAsync(problemaModel.Model);
                return Resultado<ProblemaModel>.SucessoMensagem("Problema deletado com sucesso!");


            }
            catch (Exception ex)
            {
                return Resultado<ProblemaModel>.ErroMensagem($"Erro ao deletar o problema {ex.Message}!");
            }
        }
    }
}
