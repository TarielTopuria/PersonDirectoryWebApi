using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static PersonDirectoryWebApi.Entities.Enums;

namespace PersonDirectoryWebApi.Entities
{
    public class PhoneNumber
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string PhoneNumbers { get; set; }
        public NumberTypeEnum NumberTypeId { get; set; }

        [ForeignKey("PersonId")]
        public Person? Person { get; set; }
        public int PersonId { get; set; }
    }
}
