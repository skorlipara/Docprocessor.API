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
        /// <summary>
        /// Saves a new doc.
        /// </summary>
        /// <param name="resource">Doc data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(DocResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 204)]
        public async Task<IActionResult> PostAsync([FromBody] SaveDocResource resource)
        {
            var doc = _mapper.Map<SaveDocResource, Doc>(resource);
            var result = await _docService.SaveAsync(doc);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var docResource = _mapper.Map<Doc, DocResource>(result.Resource);
            return Ok(docResource);
        }

        /// <summary>
        /// Updates an existing doc according to an identifier.
        /// </summary>
        /// <param name="id">Doc identifier.</param>
        /// <param name="resource">Updated doc data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(DocResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 204)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveDocResource resource)
        {
            var doc = _mapper.Map<SaveDocResource, Doc>(resource);
            var result = await _docService.UpdateAsync(id, doc);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var docResource = _mapper.Map<Doc, DocResource>(result.Resource);
            return Ok(docResource);
        }

        /// <summary>
        /// Deletes a given doc according to an identifier.
        /// </summary>
        /// <param name="id">Doc identifier.</param>
        /// <returns>Response for the request.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(DocResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _docService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var docResource = _mapper.Map<Doc, DocResource>(result.Resource);
            return Ok(docResource);
        }
    }
}
