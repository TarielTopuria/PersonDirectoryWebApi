using AutoMapper;
using PersonDirectoryWebApi.Models.PersonModels;

namespace PersonDirectoryWebApi.Profiles
{
    public class PhoneNumberProfile : Profile
    {
        public PhoneNumberProfile()
        {
            CreateMap<Entities.PhoneNumber, Models.PhoneNumbersDto>();
            CreateMap<CreatePersonDto, Entities.PhoneNumber>();
        }
    }
}
