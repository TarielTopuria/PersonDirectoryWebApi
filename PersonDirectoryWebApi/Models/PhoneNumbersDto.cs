using static PersonDirectoryWebApi.Entities.Enums;

namespace PersonDirectoryWebApi.Models
{
    public class PhoneNumbersDto
    {
        public string PhoneNumbers { get; set; }
        public NumberTypeEnum NumberTypeId { get; set; }
        public string NumberType { get { return NumberTypeId.ToString(); } }
    }
}
