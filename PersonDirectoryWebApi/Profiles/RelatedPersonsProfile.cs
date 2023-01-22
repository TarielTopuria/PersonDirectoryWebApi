using AutoMapper;
using PersonDirectoryWebApi.Entities;
using PersonDirectoryWebApi.Models.RelatedPersons;

namespace PersonDirectoryWebApi.Profiles
{
    public class RelatedPersonsProfile : Profile
    {
        public RelatedPersonsProfile()
        {
            CreateMap<RelatedPerson, RelativePersonsDto>();
            CreateMap<RelatedPersonForCreationDto, RelatedPerson>();
        }
    }
}
