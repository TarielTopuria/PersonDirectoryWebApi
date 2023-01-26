using AutoMapper;
using PersonDirectoryWebApi.Entities;
using PersonDirectoryWebApi.Models.PhoneNumberModels;
using PersonDirectoryWebApi.Requests.PersonRequests;
using PersonDirectoryWebApi.Requests.PhoneNumberRequests;

namespace PersonDirectoryWebApi.Profiles
{
    public class PhoneMappingNumberProfile : Profile
    {
        public PhoneMappingNumberProfile()
        {
            CreateMap<PhoneNumber, PhoneNumbersDto>();
            CreateMap<CreatePersonRequestDto, PhoneNumber>();
            CreateMap<CreatePhoneNumbersRequestDto, PhoneNumber>();
            CreateMap<UpdatePhoneNumberRequestDto, PhoneNumber>();
        }
    }
}
