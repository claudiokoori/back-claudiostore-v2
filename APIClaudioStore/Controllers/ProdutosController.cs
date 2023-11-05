using APIClaudioStore.Models;
using APIClaudioStore.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIClaudioStore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> Get()
        {
            var resultado =  await _produtoRepository.PegarTodosProdutosAsync();

            if (resultado is null)
            {
                return NotFound();
            }

            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>>  GetId(int id)
        {
            var resultado = await _produtoRepository.BuscarPorIdAsync(id);

            if (resultado is null)
            {
                return NotFound();
            }

            return Ok(resultado);
        }


        [HttpGet("busca/{search}")]
        public async Task<ActionResult<IEnumerable<Produto>>> Search(string search)
        {
            var resultado = await _produtoRepository.SearchAsync(search);

            if (resultado is null)
            {
                return NotFound();
            }

            return Ok(resultado);
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> ComprarProduto(ComprarProduto comprarProduto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if( comprarProduto.Quantidade > 10)
            {
                return BadRequest();
            }

            var compra = await _produtoRepository.ComprarProdutoAsync(comprarProduto);
            if (compra is null)
            {
                return NotFound();
            }

            return Ok(compra);
        }
    }
}
