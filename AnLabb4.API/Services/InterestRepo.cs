using AN_Labb_4;
using AnLabb4.API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace AnLabb4.API.Services

{
    public class InterestRepo : IAnLabb4<Interest>
    {
        private readonly AppDbContext _appContext;
        public InterestRepo(AppDbContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<Interest> Add(Interest newEntity)
        {
            var result = await _appContext.Interests.AddAsync(newEntity);
            await _appContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Interest> Delete(int id)
        {
            var result = await _appContext.Interests.FirstOrDefaultAsync(p => p.InterestId == id);
            if (result != null)
            {
                _appContext.Interests.Remove(result);
                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Interest>> GetAll()
        {
            return await _appContext.Interests.ToListAsync();
        }

        public async Task<Interest> GetSingle(int id)
        {
            return await _appContext.Interests.FirstOrDefaultAsync(p => p.InterestId == id);
        }

        public async Task<IEnumerable<Interest>> InterestsPerPerson(int personId)
        {
            var result = await (from q in _appContext.PersonInterestLinks
                                      join i in _appContext.Interests on q.InterestId equals i.InterestId
                                      join p in _appContext.Persons on q.PersonId equals p.PersonId
                                      where q.PersonId == personId
                                      select i).Distinct().ToListAsync();
            if (result != null)
            {
                return result;
            }

            return null;
        }

        public Task<IEnumerable<Interest>> WebsitesPerPerson(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Interest> Update(Interest entity)
        {
            var result = await _appContext.Interests.FirstOrDefaultAsync(p => p.InterestId == entity.InterestId);
            if (result != null)
            {
                result.InterestTitle = entity.InterestTitle;
                result.Description = entity.Description;

                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Interest> AddPersonInterest(Interest newEntity, int id)
        {
            var resultP = await _appContext.Persons.FirstOrDefaultAsync(p => p.PersonId == id);
            if (resultP != null)
            {
                var result = await _appContext.Interests.AddAsync(newEntity);
                await _appContext.SaveChangesAsync();

                await _appContext.PersonInterestLinks.AddAsync(new PersonInterestLink { InterestId = result.Entity.InterestId, PersonId = id });
                await _appContext.SaveChangesAsync();

                return result.Entity;
            }
            return null;
        }

        public Task<Interest> AddPersonWebsite(Interest newEntity, int personId, int interestId)
        {
            throw new NotImplementedException();
        }
    }
}
