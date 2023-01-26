using Microsoft.EntityFrameworkCore;
using PersonDirectoryWebApi.DbContexts;
using PersonDirectoryWebApi.Entities;
using PersonDirectoryWebApi.Repositories.Abstraction.IRepositories;

namespace PersonDirectoryWebApi.Repositories.Implementation.Repositories
{
    public class PhoneNumbersInfoRepository : IPhoneNumbersInfoRepository
    {
        private readonly PersonApiContext _context;

        public PhoneNumbersInfoRepository(PersonApiContext context)
        {
            _context = context;
        }
        public async Task AddPhoneNumber(int personId, PhoneNumber phoneNumber)
        {
            var person = await GetPersonAsync(personId);
            if (person != null)
            {
                person.Numbers.Add(phoneNumber);
            }
        }

        public async Task<bool> CheckPersonAsync(int personId)
        {
            return await _context.Persons.AnyAsync(p => p.Id == personId);
        }

        public void DeletePhoneNumber(PhoneNumber phoneNumber)
        {
            _context.PhoneNumbers.Remove(phoneNumber);
        }

        public async Task<Person?> GetPersonAsync(int personId)
        {
            return await _context.Persons.Where(x => x.Id == personId).FirstOrDefaultAsync();
        }

        public async Task<PhoneNumber?> GetPhoneNumberAsync(int personId, int phoneNumberId)
        {
            return await _context.PhoneNumbers.Where(x => x.PersonId == personId && x.Id == phoneNumberId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Person>> GetPersonsAsync()
        {
            return await _context.Persons.Include(p => p.Relatives).Include(i => i.Numbers).ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
