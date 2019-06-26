using System.Data.Entity;
using MySql.Data.Entity;

namespace DocumentManagementSystem.Models.Domains.MySQL.Entities
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DMsDbContext : DbContext
    {
        public DMsDbContext() : base("DMsConnectionMySQL")
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