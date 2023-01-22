using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static PersonDirectoryWebApi.Entities.Enums;

namespace PersonDirectoryWebApi.Entities
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderTypeEnum GenderId { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

        [ForeignKey("CityId")]
        public City City { get; set; }
        public int CityId { get; set; }
        public ICollection<PhoneNumber> Numbers { get; set; } = new List<PhoneNumber>();
        public string ImagePath { get; set; }
        public ICollection<RelatedPerson> Relatives { get; set; } = new List<RelatedPerson>();

    }
}
