using LatvijasPastsCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LatvijasPastsData
{
    public interface ILatvijasPastsDbContext
    {
        DbSet<T> Set<T>() where T : class;
        EntityEntry<T> Entry<T>(T entity) where T : class;
        DbSet<CVData> CVDatas { get; set; }
        int SaveChanges();
    }
}
