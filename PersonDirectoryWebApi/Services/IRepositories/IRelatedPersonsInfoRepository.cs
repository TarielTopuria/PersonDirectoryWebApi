using PersonDirectoryWebApi.Entities;

namespace PersonDirectoryWebApi.Services.IRepositories
{
    public interface IRelatedPersonsInfoRepository
    {
        Task<bool> CheckPersonAsync(int personId);
        Task<RelatedPerson?> GetRelatedPersonAsync(int personId, int relatedPersonId);
        void DeleteRelation(RelatedPerson relatedPerson);
        Task<bool> SaveChangesAsync();
        Task AddRelatedPerson(int personId, RelatedPerson relatedPerson);
        Task<Person?> GetPersonAsync(int personId);
        Task<IEnumerable<Person>> GetPersonsAsync();
    }
}
