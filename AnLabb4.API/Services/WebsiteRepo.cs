using AN_Labb_4;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AnLabb4.API.Model;
using Microsoft.EntityFrameworkCore;

namespace AnLabb4.API.Services
{
    public class WebsiteRepo : IAnLabb4<Website>
    {
        private readonly AppDbContext _appContext;
        public WebsiteRepo(AppDbContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<Website> Add(Website newEntity)
        {
            var result = await _appContext.Websites.AddAsync(newEntity);
            await _appContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Website> Delete(int id)
        {
            var result = await _appContext.Websites.FirstOrDefaultAsync(p => p.WebsiteId == id);
            if (result != null)
            {
                _appContext.Websites.Remove(result);
                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Website>> GetAll()
        {
            return await _appContext.Websites.ToListAsync();
        }

        public async Task<Website> GetSingle(int id)
        {
            return await _appContext.Websites.FirstOrDefaultAsync(p => p.WebsiteId == id);
        }

        public Task<IEnumerable<Website>> InterestsPerPerson(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Website>> WebsitesPerPerson(int personId)
        {
            var personRes = await (from q in _appContext.PersonInterestLinks
                                      join w in _appContext.Websites on q.WebsiteId equals w.WebsiteId
                                      join p in _appContext.Persons on q.PersonId equals p.PersonId
                                      where q.PersonId == personId
                                      select w).Distinct().ToListAsync();

            if (personRes != null)
            {
                return personRes;
            }

            return null;
        }

        public async Task<Website> Update(Website entity)
        {
            var result = await _appContext.Websites.FirstOrDefaultAsync(p => p.WebsiteId == entity.WebsiteId);
            if (result != null)
            {
                result.Link = entity.Link;

                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public Task<Website> AddPersonInterest(Website newEntity, int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Website> AddPersonWebsite(Website newEntity, int personId, int interestId)
        {
            var resulta = await _appContext.Persons.FirstOrDefaultAsync(p => p.PersonId == personId);
            var resultb = await _appContext.Interests.FirstOrDefaultAsync(i => i.InterestId == interestId);
            if (resulta != null && resultb != null)
            {
                var result = await _appContext.Websites.AddAsync(newEntity);
                await _appContext.SaveChangesAsync();

                await _appContext.PersonInterestLinks.AddAsync(
                    new PersonInterestLink { InterestId = interestId, PersonId = personId, WebsiteId = result.Entity.WebsiteId });
                await _appContext.SaveChangesAsync();

                return result.Entity;
            }
            return null;
        }
    }
}
