using bliss_recruitment_api.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace bliss_recruitment_api.DAL
{
    public class ApiContext : DbContext
    {
         
        public ApiContext() : base("name=ApiContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Question> Question { get; set; }
        public DbSet<Choice> Choice { get; set; }
    }
}
