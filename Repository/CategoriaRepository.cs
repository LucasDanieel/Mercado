using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Mercado.Data;
using Mercado.Models;
using Mercado.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mercado.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly DataContext _context;

        public CategoriaRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Categoria>> Get()
        {
            return await _context.Categorias.Include(x => x.Produtos).AsNoTracking().ToListAsync();
        }

        public async Task<Categoria> GetById(int id)
        {
            var mc = await _context.Categorias.Include(x => x.Produtos).SingleOrDefaultAsync(p => p.Id == id);
            return mc;
        }
        public async Task Create(Categoria categoria)
        {
            var category = new Categoria
                {
                    Id = 0,
                    Nome = categoria.Nome
                };
                await _context.Categorias.AddAsync(category);
                await _context.SaveChangesAsync();
        }


        public async Task Update(Categoria categoria)
        {
            _context.Entry(categoria).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var mc = await _context.Categorias.FindAsync(id);
            _context.Categorias.Remove(mc);
            await _context.SaveChangesAsync();
        }

        public bool Find(List<Categoria> categoria)
        {
            var _categoria = _context.Categorias.FirstOrDefault();
            if(_categoria == null)
            {
                return false;
            }
            return true;
        }

        // public bool FindId(int id)
        // {
        //     var categoria = _context.Categorias.FindAsync(id);
        //     if(categoria == null)
        //     {
        //         return false;
        //     }
        //     return true;
        // }
    }
}