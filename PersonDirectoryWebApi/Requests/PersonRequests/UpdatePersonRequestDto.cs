using static PersonDirectoryWebApi.Entities.Enums;

namespace PersonDirectoryWebApi.Requests.PersonRequests
{
    public class UpdatePersonRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderTypeEnum GenderId { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CityId { get; set; }
    }
}
