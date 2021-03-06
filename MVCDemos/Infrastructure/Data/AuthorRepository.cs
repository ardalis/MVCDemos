﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCDemos.Interfaces;
using MVCDemos.Models;
using Microsoft.EntityFrameworkCore;
using MVCDemos.Data;

namespace MVCDemos.Infrastructure.Data
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AuthorRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            return await _dbContext.Authors.FindAsync(id);
            //return await _dbContext.Authors.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Author>> ListAsync()
        {
            return await _dbContext.Authors.AsNoTracking().ToListAsync();
        }

        public async Task UpdateAsync(Author author)
        {
            _dbContext.Entry(author).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddAsync(Author author)
        {
            if (!_dbContext.Authors.Any())
            {
                author.Id = 1;
            }
            else
            {
                int maxId = _dbContext.Authors.Max(a => a.Id);
                author.Id = maxId + 1;
            }
            _dbContext.Authors.Add(author);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var author = _dbContext.Authors.FirstOrDefault(a => a.Id == id);
            _dbContext.Authors.Remove(author);
            await _dbContext.SaveChangesAsync();
        }
    }
}
