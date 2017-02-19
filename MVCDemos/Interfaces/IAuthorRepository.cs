using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MVCDemos.Models;

namespace MVCDemos.Interfaces
{
    public interface IAuthorRepository
    {
        Task<Author> GetByIdAsync(int id);
        Task<List<Author>> ListAsync();
        Task UpdateAsync(Author author);
        Task AddAsync(Author author);
        Task DeleteAsync(int id);
    }
}
