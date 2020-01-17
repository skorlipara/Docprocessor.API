using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Docprocessor.API.Domain.Models;
using Docprocessor.API.Domain.Repositories;
using Docprocessor.API.Persistence.Contexts;

namespace Docprocessor.API.Persistence.Repositories
{
    public class DocRepository : BaseRepository, IDocRepository
    {
        public DocRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Doc>> ListAsync()
        {
            return await _context.Docs
                                 .AsNoTracking()
                                 .ToListAsync();
        }
        public async Task AddAsync(Doc doc)
        {
            await _context.Docs.AddAsync(doc);
        }

        public async Task<Doc> FindByIdAsync(int id)
        {
            return await _context.Docs.FindAsync(id);
        }

        public void Update(Doc doc)
        {
            _context.Docs.Update(doc);
        }

        public void Remove(Doc doc)
        {
            _context.Docs.Remove(doc);
        }
    }
}
