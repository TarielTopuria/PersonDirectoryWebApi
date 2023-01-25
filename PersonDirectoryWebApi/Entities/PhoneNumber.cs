using System.ComponentModel.DataAnnotations.Schema;
using static PersonDirectoryWebApi.Entities.Enums;

namespace PersonDirectoryWebApi.Entities
{
    public class PhoneNumber : BaseEntity
    {
        public string PhoneNumbers { get; set; }
        public NumberTypeEnum NumberTypeId { get; set; }

        [ForeignKey("PersonId")]
        public Person? Person { get; set; }
        public int PersonId { get; set; }
    }
}
