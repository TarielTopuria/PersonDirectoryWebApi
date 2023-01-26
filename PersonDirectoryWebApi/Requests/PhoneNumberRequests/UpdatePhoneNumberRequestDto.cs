using static PersonDirectoryWebApi.Entities.Enums;

namespace PersonDirectoryWebApi.Requests.PhoneNumberRequests
{
    public class UpdatePhoneNumberRequestDto
    {
        public string PhoneNumbers { get; set; }
        public NumberTypeEnum NumberTypeId { get; set; }
    }
}
