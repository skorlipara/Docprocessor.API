using AutoMapper;
using Docprocessor.API.Domain.Models;
using Docprocessor.API.Resources;

namespace Docprocessor.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Doc, DocResource>();
        }
    }
}
