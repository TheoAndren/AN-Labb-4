using AN_Labb_4;
using AnLabb4.API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnLabb4.API.Services
{
    public class PersonRepo : IAnLabb4<Person>
    {
        private readonly AppDbContext _appContext;
        public PersonRepo(AppDbContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<Person> Add(Person newEntity)
        {
            var result = await _appContext.Persons.AddAsync(newEntity);
            await _appContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Person> Delete(int id)
        {
            var result = await _appContext.Persons.FirstOrDefaultAsync(p => p.PersonId == id);
            if (result != null)
            {
                _appContext.Persons.Remove(result);
                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _appContext.Persons.ToListAsync();
        }

        public async Task<Person> GetSingle(int id)
        {
            return await _appContext.Persons.FirstOrDefaultAsync(p => p.PersonId == id);
        }

        public Task<IEnumerable<Person>> InterestsPerPerson(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Person>> WebsitesPerPerson(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Person> Update(Person entity)
        {
            var result = await _appContext.Persons.FirstOrDefaultAsync(p => p.PersonId == entity.PersonId);
            if (result != null)
            {
                result.FirstName = entity.FirstName;
                result.LastName = entity.LastName;
                result.PhoneNumber = entity.PhoneNumber;

                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public Task<Person> AddPersonInterest(Person newEntity, int id)
        {
            throw new NotImplementedException();
        }

        public Task<Person> AddPersonWebsite(Person newEntity, int personId, int interestId)
        {
            throw new NotImplementedException();
        }
    }
}
