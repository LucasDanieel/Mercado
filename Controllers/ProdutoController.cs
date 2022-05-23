using System.Collections.Generic;
using System.Threading.Tasks;
using Mercado.Models;
using Mercado.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

    [Route("Produto")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _repository;

        public ProdutoController(IProdutoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Authorize(Roles = "Funcionario, Gerente")]
        public async Task<ActionResult<List<Produto>>> Get()
        {
            var produto = await _repository.Get();
            if(produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Funcionario, Gerente")]
        public async Task<ActionResult<List<Produto>>> GetById(int id)
        {
            var produto = await _repository.GetById(id);
            if(produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpPost]
        [Authorize(Roles = "Funcionario, Gerente")]
        public async Task<ActionResult<IEnumerable<Produto>>> Create([FromBody] Produto produto)
        {
            await _repository.Create(produto);
            return Ok("Produto criada");
        }

        [HttpPut]
        [Authorize(Roles = "Funcionario, Gerente")]
        public async Task<ActionResult> Put(int id, [FromBody] Produto produto)
        {
            await _repository.Update(produto);
            return Ok("Produto atualizada");
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Funcionario, Gerente")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repository.Delete(id);
            return Ok("Produto deletada");
        }
    }
