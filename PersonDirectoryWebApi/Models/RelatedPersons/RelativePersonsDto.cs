using static PersonDirectoryWebApi.Entities.Enums;

namespace PersonDirectoryWebApi.Models.RelatedPersons
{
    public class RelativePersonsDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public RelationTypeEnum RelationTypeId { get; set; }
        public string Relationship { get { return RelationTypeId.ToString(); } }
    }
}
