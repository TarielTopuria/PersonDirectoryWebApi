using PersonDirectoryWebApi.Entities;

namespace PersonDirectoryWebApi.Repositories.Abstraction.IRepositories
{
    public interface IPhoneNumbersInfoRepository
    {
        Task<bool> CheckPersonAsync(int personId);
        Task<PhoneNumber?> GetPhoneNumberAsync(int personId, int phoneNumberId);
        void DeletePhoneNumber(PhoneNumber phoneNumber);
        Task<bool> SaveChangesAsync();
        Task AddPhoneNumber(int personId, PhoneNumber phoneNumber);
        Task<Person?> GetPersonAsync(int personId);
        Task<IEnumerable<Person>> GetPersonsAsync();
    }
}
