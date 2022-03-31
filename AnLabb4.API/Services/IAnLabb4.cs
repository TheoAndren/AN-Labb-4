using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace AnLabb4.API.Services
{
    public interface IAnLabb4<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetSingle(int id);
        Task<T> Add(T newEntity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
        Task<IEnumerable<T>> InterestsPerPerson(int id);
        Task<IEnumerable<T>> WebsitesPerPerson(int id);

        Task<T> AddPersonInterest(T newEntity, int id);
        Task<T> AddPersonWebsite(T newEntity, int personId, int interestId);
    }
}
