using AutoMapper;
using PersonDirectoryWebApi.Entities;
using PersonDirectoryWebApi.Models.PersonModels;
using PersonDirectoryWebApi.Models.RelatedPersons;
using PersonDirectoryWebApi.Requests.PersonRequests;

namespace PersonDirectoryWebApi.Profiles
{
    public class PersonMappingProfile : Profile
    {
        public PersonMappingProfile()
        {
            CreateMap<Person, PersonWithEverythingDto>();
            CreateMap<Person, PersonDto>();
            CreateMap<Person, RelationReportDto>();
            CreateMap<UpdatePersonRequestDto, Person>();
            CreateMap<CreatePersonRequestDto, Person>();
        }
    }
}
