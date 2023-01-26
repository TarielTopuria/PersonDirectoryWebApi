using static PersonDirectoryWebApi.Entities.Enums;

namespace PersonDirectoryWebApi.Requests.PhoneNumberRequests
{
    public class CreatePhoneNumbersRequestDto
    {
        public string PhoneNumbers { get; set; }
        public NumberTypeEnum NumberTypeId { get; set; }
    }
}
