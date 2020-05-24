
using EskholFitness.BL.Model;
using System.Data.Entity;

namespace EskholFitness.BL.Controller
{
    class FitnessContext : DbContext
    {
        public FitnessContext() : base("DBConnection"){ }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Eating> Eatings { get; set; }
        public DbSet<Exerсise> Exerсises { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
