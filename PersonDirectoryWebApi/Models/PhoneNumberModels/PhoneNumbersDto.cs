using static PersonDirectoryWebApi.Entities.Enums;

namespace PersonDirectoryWebApi.Models.PhoneNumberModels
{
    public class PhoneNumbersDto
    {
        public int Id { get; set; }
        public string PhoneNumbers { get; set; }
        public NumberTypeEnum NumberTypeId { get; set; }
        public string NumberType { get { return NumberTypeId.ToString(); } }
    }
}
