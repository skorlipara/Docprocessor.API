using System.Collections.Generic;
using System.Threading.Tasks;
using Docprocessor.API.Domain.Models;

namespace Docprocessor.API.Domain.Repositories
{
    interface IDocRepository
    {
        Task<IEnumerable<Doc>> ListAsync();
    }
}
