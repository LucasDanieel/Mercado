using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mercado.Data;
using Mercado.Models;
using Mercado.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

    [Route("Categoria")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaController(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Authorize(Roles = "Funcionario, Gerente")]
        public async Task<ActionResult<List<Categoria>>> Get()
        {
            var categoria = await _repository.Get();
            if(_repository.Find(categoria) == false)
            {
                return NotFound();
            }
            return Ok(categoria);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Funcionario, Gerente")]
        public async Task<ActionResult<List<Categoria>>> GetById(int id)
        {
            var categoria = await _repository.GetById(id);
            if(categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);
        }

        [HttpPost]
        [Authorize(Roles = "Funcionario, Gerente")]
        public async Task<ActionResult<IEnumerable<Categoria>>> Create([FromBody] Categoria categoria)
        {
            if(categoria.Nome.Length > 60)
            {
                return BadRequest("Nome muito grande, Maximo de caracteres 60");
            }
            if(categoria.Nome.Length < 3)
            {
                return BadRequest("Nome muito pequeno, Minimo de caracteres 3");
            }
            await _repository.Create(categoria);
            return Ok("Categoria criada");
        }

        [HttpPut]
        [Authorize(Roles = "Funcionario, Gerente")]
        public async Task<ActionResult> Put(int id, [FromBody] Categoria categoria)
        {
            await _repository.Update(categoria);
            return Ok("Categoria atualizada");
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Funcionario, Gerente")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repository.Delete(id);
            return Ok("Categoria deletada");
        }
    }
