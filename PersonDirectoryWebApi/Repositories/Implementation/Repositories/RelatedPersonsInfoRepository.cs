using Microsoft.EntityFrameworkCore;
using PersonDirectoryWebApi.DbContexts;
using PersonDirectoryWebApi.Entities;
using PersonDirectoryWebApi.Repositories.Abstraction.IRepositories;

namespace PersonDirectoryWebApi.Repositories.Implementation.Repositories
{
    public class RelatedPersonsInfoRepository : IRelatedPersonsInfoRepository
    {
        private readonly PersonApiContext _context;

        public RelatedPersonsInfoRepository(PersonApiContext context)
        {
            _context = context;
        }

        public async Task AddRelatedPerson(int personId, RelatedPerson relatedPerson)
        {
            var person = await GetPersonAsync(personId);
            if (person != null)
            {
                person.Relatives.Add(relatedPerson);
            }
        }

        public async Task<bool> CheckPersonAsync(int personId)
        {
            return await _context.Persons.AnyAsync(p => p.Id == personId);
        }

        public void DeleteRelation(RelatedPerson relatedPerson)
        {
            _context.RelatedPersons.Remove(relatedPerson);
        }

        public async Task<RelatedPerson?> GetRelatedPersonAsync(int personId, int relatedPersonId)
        {
            return await _context.RelatedPersons.Where(p => p.PersonId == personId && p.Id == relatedPersonId).FirstOrDefaultAsync();
        }

        public async Task<Person?> GetPersonAsync(int personId)
        {
            return await _context.Persons.Where(x => x.Id == personId).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

        public async Task<IEnumerable<Person>> GetPersonsAsync()
        {
            return await _context.Persons.Include(p => p.Relatives).Include(i => i.Numbers).ToListAsync();
        }
    }
}
