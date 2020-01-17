using System.Collections.Generic;
using System.Threading.Tasks;
using Docprocessor.API.Domain.Models;

namespace Docprocessor.API.Domain.Services
{
    public interface IDocService
    {
        Task<IEnumerable<Doc>> ListAsync();
    }
}
