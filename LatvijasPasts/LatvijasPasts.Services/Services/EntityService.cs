using LatvijasPasts.Services.IServices;
using LatvijasPastsCore.Models;
using LatvijasPastsData;

namespace LatvijasPasts.Services.Services
{
    public class EntityService<T> : DbService, IEntityService<T> where T : Entity
    {
        public EntityService(ILatvijasPastsDbContext dbContext) : base(dbContext)
        {
        }

        public void Create(T entity)
        {
            Create<T>(entity);
        }

        public void Delete(T entity)
        {
            Delete<T>(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return GetAll<T>();
        }

        public T GetById(int id)
        {
            return GetById<T>(id);
        }

        public void Update(T entity)
        {
            Update<T>(entity);
        }

        public void DeleteAll()
        {
            DeleteAll<T>();
        }

    }
}
