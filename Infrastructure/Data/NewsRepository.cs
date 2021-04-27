using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class NewsRepository : INewsRepository
    {
       

        private readonly StoreContext _context;
        public NewsRepository(StoreContext context)
        {
            _context = context;

        }
         public async Task<News> GetNewsByIdAsync(int id)
        {
            return await _context.News.FindAsync(id);
        }
        public async Task<IReadOnlyList<News>> GetNewsAsync()
        {
            return await _context.News.ToListAsync();
        }
    }
}