using AutoMapper;
using PersonDirectoryWebApi.Entities;
using PersonDirectoryWebApi.Models.PersonModels;
using PersonDirectoryWebApi.Models.RelatedPersons;

namespace PersonDirectoryWebApi.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonWithEverythingDto>();
            CreateMap<Person, PersonDto>();
            CreateMap<Person, RelationReportDto>();
            CreateMap<UpdatePersonDto, Person>();
            CreateMap<CreatePersonDto, Person>();
        }
    }
}
