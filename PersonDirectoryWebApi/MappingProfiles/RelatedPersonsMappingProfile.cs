using AutoMapper;
using PersonDirectoryWebApi.Entities;
using PersonDirectoryWebApi.Models.RelatedPersons;
using PersonDirectoryWebApi.Requests.RelatedPersonsRequests;

namespace PersonDirectoryWebApi.Profiles
{
    public class RelatedPersonsMappingProfile : Profile
    {
        public RelatedPersonsMappingProfile()
        {
            CreateMap<RelatedPerson, RelativePersonsDto>();
            CreateMap<CreateRelatedPersonRequestDto, RelatedPerson>();
        }
    }
}
