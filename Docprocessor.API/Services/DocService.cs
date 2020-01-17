using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Docprocessor.API.Domain.Models;
using Docprocessor.API.Domain.Repositories;
using Docprocessor.API.Domain.Services;

namespace Docprocessor.API.Services
{
    public class DocService : IDocService
    {
        private readonly IDocRepository _docRepository;
        private readonly IMemoryCache _cache;

        public string ListAsync()
        {
            // Here I try to get the docs list from the memory cache. If there is no data in cache, the anonymous method will be
            // called, setting the cache to expire one minute ahead and returning the Task that lists the docs from the repository.

            return docs;
        }

    }
}
