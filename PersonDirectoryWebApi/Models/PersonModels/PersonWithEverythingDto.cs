using PersonDirectoryWebApi.Models.PhoneNumberModels;
using PersonDirectoryWebApi.Models.RelatedPersons;
using static PersonDirectoryWebApi.Entities.Enums;

namespace PersonDirectoryWebApi.Models.PersonModels
{
    public class PersonWithEverythingDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderTypeEnum GenderId { get; set; }
        public string Gender { get { return GenderId.ToString();  } }
        public string PersonalNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CityId { get; set; }
        public string ImagePath { get; set; }
        public int CountOfRelatives
        {
            get
            {
                return Relatives.Count;
            }
        }
        public ICollection<RelativePersonsDto> Relatives { get; set; } = new List<RelativePersonsDto>();

        public int CountOfNumbers
        {
            get
            {
                return Numbers.Count;
            }
        }
        public ICollection<PhoneNumbersDto> Numbers { get; set; } = new List<PhoneNumbersDto>();
    }
}
