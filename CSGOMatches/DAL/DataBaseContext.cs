using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("name=DBConnectionString")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataBaseContext>());
        }

        public DbSet<Team> Teams { get; set; }
    }
}
