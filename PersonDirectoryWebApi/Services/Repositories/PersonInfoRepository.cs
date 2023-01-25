using Microsoft.EntityFrameworkCore;
using PersonDirectoryWebApi.DbContexts;
using PersonDirectoryWebApi.Entities;
using PersonDirectoryWebApi.Services.IRepositories;
using PersonDirectoryWebApi.Services.Pagination;

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

        public async Task<(IEnumerable<Person>, PaginationMetadata)> GetPersonsAsync(string? firstName, string? lastName, string? personalNumber, string? searchQuery, int pageNumber, int pageSize)
        {
            var collection = _context.Persons.Include(p => p.Relatives).Include(i => i.Numbers) as IQueryable<Person>;

            if (!string.IsNullOrEmpty(firstName))
            {
                firstName = firstName.Trim();
                collection = collection.Where(x => x.FirstName == firstName);
            }

            if (!string.IsNullOrWhiteSpace(lastName))
            {
                lastName = lastName.Trim();
                collection = collection.Where(x => x.LastName == lastName);
            }

            if (!string.IsNullOrWhiteSpace(personalNumber))
            {
                personalNumber = personalNumber.Trim();
                collection = collection.Where(x => x.PersonalNumber == personalNumber);
            }

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim();
                collection = collection.Where(a => a.FirstName.Contains(searchQuery)
                    || (a.LastName != null && a.LastName.Contains(searchQuery)));
            }

            var totalItemCount = await collection.CountAsync();

            var paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);

            var collectionToReturn = await collection.OrderBy(c => c.Id).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync();

            return (collectionToReturn, paginationMetadata);
        }

        public async Task<IEnumerable<Person>> GetPersonsAsync()
        {
            return await _context.Persons.Include(p => p.Relatives).Include(i => i.Numbers).ToListAsync();
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public async Task<int> UpdateAsync (Person person)
        {
            _context.Update(person);
            return await _context.SaveChangesAsync();
        }
    }
}
