using System.Collections.Generic;
using System.Threading.Tasks;
using Mercado.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mercado.Repository.IRepository
{
    public interface IProdutoRepository 
    {
        Task<List<Produto>> Get();
        Task<Produto> GetById(int id);
        Task Create(Produto produto);
        Task Update(Produto produto);
        Task Delete(int id);
    }
}