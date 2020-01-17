using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Docprocessor.API.Domain.Models;
using Docprocessor.API.Domain.Services;
using Docprocessor.API.Resources;

namespace Docprocessor.API.Controllers
{
    [Route("[api/docs]")]
    [Produces("application/json")]
    [ApiController]
    public class DocsController : ControllerBase
    {
        private readonly IDocService _docService;
        private readonly IMapper _mapper;

        public DocsController(IDocService docService, IMapper mapper)
        {
            _docService = docService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lists all docs.
        /// </summary>
        /// <returns>List os docs.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DocResource>), 200)]
        public async Task<IEnumerable<DocResource>> ListAsync()
        {
            var docs = await _docService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Doc>, IEnumerable<DocResource>>(docs);

            return resources;
        }
    }
}
