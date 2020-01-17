using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Docprocessor.API.Domain.Models;
using Docprocessor.API.Domain.Repositories;
using Docprocessor.API.Domain.Services;
using Docprocessor.API.Domain.Services.Communication;
using Docprocessor.API.Infrastructure;

namespace Docprocessor.API.Services
{
    public class DocService : IDocService
    {
        private readonly IDocRepository _docRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _cache;

        public DocService(IDocRepository docRepository, IUnitOfWork unitOfWork, IMemoryCache cache)
        {
            _docRepository = docRepository;
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<IEnumerable<Doc>> ListAsync()
        {
            var docs = await _cache.GetOrCreateAsync(CacheKeys.DocsList, (entry) => {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
                return _docRepository.ListAsync();
            });

            return docs;
        }

        public async Task<DocResponse> SaveAsync(Doc doc)
        {
            try
            {
                await _docRepository.AddAsync(doc);
                await _unitOfWork.CompleteAsync();

                return new DocResponse(doc);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new DocResponse($"An error occurred when saving the doc: {ex.Message}");
            }
        }

        public async Task<DocResponse> UpdateAsync(int id, Doc doc)
        {
            var existingDoc = await _docRepository.FindByIdAsync(id);

            if (existingDoc == null)
                return new DocResponse("Doc not found.");

            existingDoc.Name = doc.Name;

            try
            {
                _docRepository.Update(existingDoc);
                await _unitOfWork.CompleteAsync();

                return new DocResponse(existingDoc);
            }
            catch (Exception ex)
            {
                return new DocResponse($"An error occurred when updating the doc: {ex.Message}");
            }
        }

        public async Task<DocResponse> DeleteAsync(int id)
        {
            var existingDoc = await _docRepository.FindByIdAsync(id);

            if (existingDoc == null)
                return new DocResponse("Doc not found.");

            try
            {
                _docRepository.Remove(existingDoc);
                await _unitOfWork.CompleteAsync();

                return new DocResponse(existingDoc);
            }
            catch (Exception ex)
            {
                return new DocResponse($"An error occurred when deleting the doc: {ex.Message}");
            }
        }
    }
}
