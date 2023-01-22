using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;

namespace PersonDirectoryWebApi.Models.RelatedPersons
{
    public class RelationReportDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CountOfRelatives
        {
            get
            {
                return $"Count of All Relationship: {Relatives.Count}; " +
                    $"Count of Colleague: {(int)Relatives.LongCount(x => x.RelationTypeId == Entities.Enums.RelationTypeEnum.Colleague)}; " +
                    $"Count of Acquaintance: {(int)Relatives.LongCount(x => x.RelationTypeId == Entities.Enums.RelationTypeEnum.Acquaintance)}; " +
                    $"Count of Relative: {(int)Relatives.LongCount(x => x.RelationTypeId == Entities.Enums.RelationTypeEnum.Relative)}; " +
                    $"Count of Other: {(int)Relatives.LongCount(x => x.RelationTypeId == Entities.Enums.RelationTypeEnum.Other)}";
            }
        }
        public ICollection<RelativePersonsDto> Relatives { get; set; } = new List<RelativePersonsDto>();
    }
}
