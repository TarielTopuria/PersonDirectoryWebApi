using AutoMapper;
using PersonDirectoryWebApi.Entities;
using PersonDirectoryWebApi.Models.PersonModels;
using PersonDirectoryWebApi.Models.PhoneNumberModels;

namespace PersonDirectoryWebApi.Profiles
{
    public class PhoneNumberProfile : Profile
    {
        public PhoneNumberProfile()
        {
            CreateMap<PhoneNumber, PhoneNumbersDto>();
            CreateMap<CreatePersonDto, PhoneNumber>();
            CreateMap<CreatePhoneNumbersDto, PhoneNumber>();
            CreateMap<UpdatePhoneNumberDto, PhoneNumber>();
        }
    }
}
