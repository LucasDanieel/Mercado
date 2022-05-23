using System.Collections.Generic;
using System.Threading.Tasks;
using Mercado.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mercado.Repository.IRepository
{
    public interface IEnderecoRepository 
    {
        Task<List<Endereco>> Get();
        Task<Endereco> GetById(int id);
        Task Create(Endereco endereco);
        Task Update(Endereco endereco);
        Task Delete(int id);
    }
}