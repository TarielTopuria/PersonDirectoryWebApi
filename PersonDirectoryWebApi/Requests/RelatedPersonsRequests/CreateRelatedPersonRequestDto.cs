using static PersonDirectoryWebApi.Entities.Enums;

namespace PersonDirectoryWebApi.Requests.RelatedPersonsRequests
{
    public class CreateRelatedPersonRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public RelationTypeEnum RelationTypeId { get; set; }
    }
}
