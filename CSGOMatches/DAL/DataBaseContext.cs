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
        public DbSet<Match> Matches { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<PickedMVP> PickedMvps { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerInTeam> PlayerInTeams { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<MapInMatch> MapInMatches { get; set; }
    }
}
