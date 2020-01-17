using AutoMapper;
using Docprocessor.API.Domain.Models;
using Docprocessor.API.Resources;

namespace Docprocessor.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveDocResource, Doc>();
        }
    }
}
