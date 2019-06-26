using System.Data.Entity;

namespace DocumentManagementSystem.Models.Domains.Entities
{
    public class DMsDbContext : DbContext
    {
        public DMsDbContext() : base("DMsConnection")
        {

        }

        public DMsDbContext(string connection) : base(connection)
        {

        }





        public virtual DbSet<Document> Documents { get; set; }

        public virtual DbSet<Chapter> Chapters { get; set; }





        public virtual DbSet<Addition> Additions { get; set; }

        public virtual DbSet<AdditionCategory> AdditionCategories { get; set; }
    }
}