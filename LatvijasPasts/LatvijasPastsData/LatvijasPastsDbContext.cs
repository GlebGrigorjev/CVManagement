using LatvijasPastsCore.Models;
using Microsoft.EntityFrameworkCore;

namespace LatvijasPastsData
{
    public class LatvijasPastsDbContext : DbContext, ILatvijasPastsDbContext
    {
        public LatvijasPastsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CVData> CVDatas { get; set; }
        public DbSet<AdditionalSkills> AdditionalSkills { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<Languages> Languages { get; set; }
        public DbSet<LivingAddress> LivingAddress { get; set; }
        public DbSet<PreviousWorkExperiences> PreviousWorkExperiences { get; set; }
    }
}
