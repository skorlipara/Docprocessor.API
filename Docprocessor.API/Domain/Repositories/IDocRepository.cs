using System.Collections.Generic;
using System.Threading.Tasks;
using Docprocessor.API.Domain.Models;

namespace Docprocessor.API.Domain.Repositories
{
    public interface IDocRepository
    {
        Task<IEnumerable<Doc>> ListAsync();
        Task AddAsync(Doc doc);
        Task<Doc> FindByIdAsync(int id);
        void Update(Doc doc);
        void Remove(Doc doc);
    }
}
