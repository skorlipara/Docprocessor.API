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
    }
}
