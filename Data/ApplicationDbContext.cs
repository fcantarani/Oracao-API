using Microsoft.EntityFrameworkCore;
using Oracap_App_API.Model;

namespace Oracap_App_API.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }
        public DbSet<PrayerModel>? Prayers {  get; set; }
        public DbSet<CategoryModel>? Categories { get; set; }
        public DbSet<ViewTypeModel>? ViewTypes { get; set; }
        public DbSet<PrayTypeModel>? PrayTypes { get; set; }
    }

}
