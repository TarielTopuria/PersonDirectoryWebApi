using static PersonDirectoryWebApi.Entities.Enums;

namespace PersonDirectoryWebApi.Models.PhoneNumberModels
{
    public class UpdatePhoneNumberDto
    {
        public string PhoneNumbers { get; set; }
        public NumberTypeEnum NumberTypeId { get; set; }
    }
}
