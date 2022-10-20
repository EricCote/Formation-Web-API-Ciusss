using Ciusss.Services;
using Microsoft.EntityFrameworkCore;

namespace Ciusss.Models
{
    public class CoursDbContext: DbContext
    {
        public CoursDbContext(DbContextOptions<CoursDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // TODO: custom code here
        }

        //public DbSet<Participant> Participants { get; set; }
        public DbSet<Participant> Participants => Set<Participant>();
    }
}
