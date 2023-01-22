using AutoMapper;
using PersonDirectoryWebApi.Models.PersonModels;
using PersonDirectoryWebApi.Models.RelatedPersons;

namespace PersonDirectoryWebApi.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Entities.Person, PersonWithEverythingDto>();
            CreateMap<Entities.Person, PersonDto>();
            CreateMap<Entities.Person, RelationReportDto>();
            CreateMap<UpdatePersonDto, Entities.Person>();
            CreateMap<CreatePersonDto, Entities.Person>();
        }
    }
}
