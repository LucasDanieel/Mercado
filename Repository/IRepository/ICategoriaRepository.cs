using System.Collections.Generic;
using System.Threading.Tasks;
using Mercado.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mercado.Repository.IRepository
{
    public interface ICategoriaRepository 
    {
        Task<List<Categoria>> Get();
        Task<Categoria> GetById(int id);
        Task Create(Categoria categoria);
        Task Update(Categoria categoria);
        Task Delete(int id);
        bool Find(List<Categoria> categoria);
    }
}