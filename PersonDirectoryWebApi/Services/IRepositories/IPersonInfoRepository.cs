using PersonDirectoryWebApi.Entities;

namespace PersonDirectoryWebApi.Services.IRepositories
{
    public interface IPersonInfoRepository
    {
        Task<IEnumerable<Person>> GetPersonsAsync();
        Task<Person?> GetPersonAsync(int personId);
        Task CreatePersonASync(Person person);
        Task<bool> CheckPersonAsync(int personId);
        Task<bool> SaveChangesAsync();
        void DeletePerson(Person person);
    }
}
