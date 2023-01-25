using static PersonDirectoryWebApi.Entities.Enums;

namespace PersonDirectoryWebApi.Models.PhoneNumberModels
{
    public class CreatePhoneNumbersDto
    {
        public string PhoneNumbers { get; set; }
        public NumberTypeEnum NumberTypeId { get; set; }
    }
}
