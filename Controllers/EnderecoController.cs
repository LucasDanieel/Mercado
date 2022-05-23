using System.Collections.Generic;
using System.Threading.Tasks;
using Mercado.Models;
using Mercado.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

    [Route("Endereco")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoRepository _repository;

        public EnderecoController(IEnderecoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Authorize(Roles = "Funcionario, Gerente")]
        public async Task<ActionResult<List<Endereco>>> Get()
        {
            var en = await _repository.Get();
            if(en == null)
            {
                return NotFound();
            }
            return Ok(en);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Funcionario, Gerente")]
        public async Task<ActionResult<List<Endereco>>> GetById(int id)
        {
            var en = await _repository.GetById(id);
            if(en == null)
            {
                return NotFound();
            }
            return Ok(en);
        }

        [HttpPost]
        [Authorize(Roles = "Funcionario, Gerente")]
        public async Task<ActionResult<IEnumerable<Endereco>>> Create([FromBody] Endereco endereco)
        {
            await _repository.Create(endereco);
            return Ok("Endereço criada");
        }

        [HttpPut]
        [Authorize(Roles = "Funcionario, Gerente")]
        public async Task<ActionResult> Put(int id, [FromBody] Endereco endereco)
        {
            await _repository.Update(endereco);
            return Ok("Endereço atualizada");
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Funcionario, Gerente")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repository.Delete(id);
            return Ok("Endereço deletada");
        }
    }
