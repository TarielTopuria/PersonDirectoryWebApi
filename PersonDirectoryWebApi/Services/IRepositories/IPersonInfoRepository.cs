using PersonDirectoryWebApi.Entities;
using PersonDirectoryWebApi.Services.Pagination;

namespace PersonDirectoryWebApi.Services.IRepositories
{
    public interface IPersonInfoRepository
    {
        Task<IEnumerable<Person>> GetPersonsAsync();
        Task<(IEnumerable<Person>, PaginationMetadata)> GetPersonsAsync(string? firstName, string? lastName, string? personalNumber, string? searchQuery, int pageNumber, int pageSize);
        Task<Person?> GetPersonAsync(int personId);
        Task CreatePersonASync(Person person);
        Task<bool> CheckPersonAsync(int personId);
        Task<bool> SaveChangesAsync();
        void DeletePerson(Person person);
        Task<int> UpdateAsync(Person person);
    }
}
