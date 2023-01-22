using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static PersonDirectoryWebApi.Entities.Enums;

namespace PersonDirectoryWebApi.Entities
{
    public class RelatedPerson
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public RelationTypeEnum RelationTypeId { get; set; }

        [ForeignKey("PersonId")]
        public Person? Person { get; set; }
        public int PersonId { get; set; }
        
    }
}
