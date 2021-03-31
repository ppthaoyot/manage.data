using Microsoft.EntityFrameworkCore;
using ReadExcelFiles.Models;

namespace ReadExcelFiles.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Endorsement> Endorsement { get; set; }
        public DbSet<Motor> Motor { get; set; }
        public DbSet<DBMotor> DBMotor { get; set; }
        public DbSet<Agent> Agent { get; set; }
        public DbSet<Customer> Customer { get; set; }
    }
}