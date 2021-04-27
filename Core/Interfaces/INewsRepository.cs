using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface INewsRepository
    {
        Task<News> GetNewsByIdAsync(int id);
        Task<IReadOnlyList<News>> GetNewsAsync();
    }
}