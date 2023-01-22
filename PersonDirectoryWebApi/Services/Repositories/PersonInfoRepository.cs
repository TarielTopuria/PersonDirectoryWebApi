using Microsoft.EntityFrameworkCore;
using PersonDirectoryWebApi.DbContexts;
using PersonDirectoryWebApi.Entities;
using PersonDirectoryWebApi.Services.IRepositories;

namespace PersonDirectoryWebApi.Services.Repositories
{
    public class PersonInfoRepository : IPersonInfoRepository
    {
        private readonly PersonApiContext _context;

        public PersonInfoRepository(PersonApiContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> CheckPersonAsync(int personId)
        {
            return await _context.Persons.AnyAsync(p => p.Id == personId);
        }

        public async Task CreatePersonASync(Person person)
        {
            await _context.Persons.AddAsync(person);
        }

        public void DeletePerson(Person person)
        {
            _context.Persons.Remove(person);
        }

        public async Task<Person?> GetPersonAsync(int personId)
        {
            return await _context.Persons.Where(x => x.Id == personId).Include(p => p.Relatives).Include(i => i.Numbers).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Person>> GetPersonsAsync()
        {
            return await _context.Persons.Include(p => p.Relatives).Include(i => i.Numbers).ToListAsync();
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
