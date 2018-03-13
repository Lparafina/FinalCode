using FGF.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FGF.DAL
{
    public class OrgContext : DbContext
    {

        public OrgContext() : base("OrgContext")
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Register> Registers { get; set; }
        public DbSet<Event> Event { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
