using System.Threading.Tasks;
using Docprocessor.API.Domain.Repositories;
using Docprocessor.API.Persistence.Contexts;

namespace Docprocessor.API.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
