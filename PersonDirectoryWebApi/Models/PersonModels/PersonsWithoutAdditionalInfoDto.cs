using static PersonDirectoryWebApi.Entities.Enums;

namespace PersonDirectoryWebApi.Models.PersonModels
{
    public class PersonsWithoutAdditionalInfoDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderTypeEnum GenderId { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ImagePath { get; set; }
    }
}
