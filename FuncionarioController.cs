using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;
using WebApi.Model;
using WebApi.Service;
using WebApi.Service.FuncionarioService;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioInterface _funcionarioInterface;
        private readonly ScrapingService _scrapingService;
        public FuncionarioController(IFuncionarioInterface FuncionarioInterface, ScrapingService scrapingService)
        {
            _funcionarioInterface = FuncionarioInterface;
            _scrapingService = scrapingService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> GetFuncionarios()
        {
            return Ok(await _funcionarioInterface.GetFuncionarios());
        }
        [HttpPost("scrape-and-save")]
        public async Task<ActionResult<ServiceResponse<FuncionarioModel>>> ScrapeAndSaveFuncionario()
        {
            string url = "https://www.supermercadosguanabara.com.br/produtos/42";
            
            var (productName, price) = await _scrapingService.GetProductFromSiteAsync(url);  
            if (!string.IsNullOrEmpty(productName))
            {
              
                var novoFuncionario = new FuncionarioModel
                {
                    Item = productName,
                    Preço = price, /
                    SuperMercado = "Guanabara"
                };

                var response = await _funcionarioInterface.CreateFuncionario(novoFuncionario);

                if (response.Sucesso)
                {
                    return Ok(response);
                }
                return BadRequest(response);
            }

        
            return NotFound(new ServiceResponse<FuncionarioModel> { Sucesso = false, Mensagem = "Produto não encontrado" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> DeleteFuncionario(int id)
        {
            var response = await _funcionarioInterface.DeleteFuncionario(id);
            if (!response.Sucesso)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> GetFuncionarioById(int id)
  
        {
            return Ok(await _funcionarioInterface.GetFuncionarioById(id));  
        }
    }
}
