using System.Collections.Generic;
using System.Threading.Tasks;
using Mercado.Data;
using Mercado.Models;
using Mercado.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Mercado.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly DataContext _context;

        public EnderecoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Endereco>> Get()
        {
            return await _context.Enderecos.Include(x => x.User).AsNoTracking().ToListAsync();
        }

        public async Task<Endereco> GetById(int id)
        {
            var mc = await _context.Enderecos.Include(x => x.User).SingleOrDefaultAsync(p => p.UserId == id);
            return mc;
        }
        public async Task Create(Endereco endereco)
        {
            var en = new Endereco()
            {
                UserId = endereco.UserId,
                Rua = endereco.Rua,
                NumeroCasa = endereco.NumeroCasa,
                Bairro = endereco.Bairro,
                CEP = endereco.CEP,
                Cidade = endereco.Cidade
            };
            _context.Enderecos.Add(en);
            await _context.SaveChangesAsync();
        }


        public async Task Update(Endereco endereco)
        {
            _context.Entry(endereco).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var mc = await _context.Enderecos.FindAsync(id);
            _context.Enderecos.Remove(mc);
            await _context.SaveChangesAsync();
        }
    }
}