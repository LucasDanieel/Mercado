using System.Collections.Generic;
using System.Threading.Tasks;
using Mercado.Data;
using Mercado.Models;
using Mercado.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Mercado.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DataContext _context;

        public ProdutoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Produto>> Get()
        {
            return await _context.Produtos.Include(x => x.Categorias).AsNoTracking().ToListAsync();
        }

        public async Task<Produto> GetById(int id)
        {
            var mc = await _context.Produtos.Include(x => x.Categorias).SingleOrDefaultAsync(p => p.Id == id);
            return mc;
        }
        public async Task Create(Produto produto)
        {
            var prod = new Produto()
            {
                Id = 0,
                Nome = produto.Nome,
                Quantidade = produto.Quantidade,
                CategoriaId = produto.CategoriaId
            };
            _context.Produtos.Add(prod);
            await _context.SaveChangesAsync();
        }


        public async Task Update(Produto produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var mc = await _context.Produtos.FindAsync(id);
            _context.Produtos.Remove(mc);
            await _context.SaveChangesAsync();
        }
    }
}