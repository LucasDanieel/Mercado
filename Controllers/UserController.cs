using System.Collections.Generic;
using System.Threading.Tasks;
using Mercado.Models;
using Mercado.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

    [Route("User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Authorize(Roles = "Gerente")]
        public async Task<ActionResult<List<User>>> Get()
        {
            var us = await _repository.Get();
            if(us == null)
            {
                return NotFound("Nenhum usuario encontrado");
            }
            return Ok(us);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Gerente")]
        public async Task<ActionResult<List<User>>> GetById(int id)
        {
            var us = await _repository.GetById(id);
            if(us == null)
            {
                return NotFound("Nenhum usuario encontrado");
            }
            return Ok(us);
        }

        [HttpPost]
        [Authorize(Roles = "Gerente")]
        public async Task<ActionResult<IEnumerable<User>>> Create([FromBody] User user)
        {
            await _repository.Create(user);
            return Ok("Usuario criada");
        }
        

        [HttpPut]
        [Authorize(Roles = "Gerente")]
        public async Task<ActionResult> Put(int id, [FromBody] User user)
        {
            await _repository.Update(user);
            return Ok("Usuario atualizada");
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Gerente")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repository.Delete(id);
            return Ok("Usuario deletada");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<dynamic>> Autorizacao([FromBody] User user)
        {
            return await _repository.Authenticate(user);
        }
    }
