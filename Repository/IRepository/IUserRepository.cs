using System.Collections.Generic;
using System.Threading.Tasks;
using Mercado.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mercado.Repository.IRepository
{
    public interface IUserRepository 
    {
        Task<List<User>> Get();
        Task<User> GetById(int id);
        Task Create(User user);
        Task Update(User user);
        Task Delete(int id);
        Task<dynamic> Authenticate(User user);
    }
}