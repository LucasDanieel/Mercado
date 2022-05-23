using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema.Services;
using Mercado.Data;
using Mercado.Models;
using Mercado.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Mercado.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<User>> Get()
        {
            return await _context.Users.Include(x => x.Endereco).ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            var mc = await _context.Users.Include(x => x.Endereco).SingleOrDefaultAsync(p => p.Id == id);
            return mc;
        }
        public async Task Create(User user)
        {
            var prod = new User()
            {
                Id = 0,
                Nome = user.Nome,
                Senha = user.Senha,
                Cargo = user.Cargo
            };
            _context.Users.Add(prod);
            await _context.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var mc = await _context.Users.FindAsync(id);
            _context.Users.Remove(mc);
            await _context.SaveChangesAsync();
        }

        public async Task<dynamic> Authenticate(User user)
        {
            var log = await _context.Users.AsNoTracking()
            .Where(x => x.Nome == user.Nome && x.Senha == user.Senha).FirstOrDefaultAsync();

            if(log == null)
            {
                return "Usuario não encontrado";
            }

            var token = TokenService.GenerateToken(log);

            return new {
                log = log,
                token = token
            };
        }
    }
}