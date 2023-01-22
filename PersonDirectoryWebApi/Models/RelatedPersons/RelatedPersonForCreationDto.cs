using static PersonDirectoryWebApi.Entities.Enums;

namespace PersonDirectoryWebApi.Models.RelatedPersons
{
    public class RelatedPersonForCreationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public RelationTypeEnum RelationTypeId { get; set; }
    }
}
