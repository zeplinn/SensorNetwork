using System.Data.Common;
using Microsoft.Data.Entity;
using SensorNetwork.Models.Entities;

namespace SensorNetwork.Models.DbContexts
{
    public class SensorNetContext : DbContext
    {
        //private IConfigurationRoot _configRoot;

        
        public DbSet<Reading> Readings { get; set; }
        public DbSet<Network> Networks { get; set; }
        public DbSet<Sensor> Sensors { get; set; }

        //public SensorNetContext(IConfigurationRoot configRoot)
        //{
        //    _configRoot = configRoot;
        //    Database.EnsureCreated();
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optBuilder)
        {
#if DEBUG
            //var connect = Startup._builder["Data:DbConnectDebug"];
            optBuilder.UseNpgsql("Host=localhost;Database=Debug;Username=postgres;Password=Z110144ucc");
            base.OnConfiguring(optBuilder);
#endif
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Network>(e =>
            {
                e.ForNpgsqlToTable("Network");
                e.HasKey(key => new { key.NetworkId });
                e.Property(n => n.NetworkId).ValueGeneratedOnAdd();
            });

            builder.Entity<Sensor>(e =>
            {
                e.ForNpgsqlToTable("Sensors");
                e.HasKey(key => new { key.SensorId });
                e.HasOne(s => s.Network).WithMany(n => n.Sensors);
                e.Property(s => s.SensorId).ValueGeneratedOnAdd();
                e.HasIndex(s => s.InFolder);
            });

            builder.Entity<Reading>(e =>
            {
                e.ForNpgsqlToTable("Readings");
                e.Property(r => r.ReadingID).ValueGeneratedOnAdd();
                e.HasOne(r => r.Sensor).WithMany(s => s.Readings);//.HasForeignKey(r => r.SensorId);
            });

            base.OnModelCreating(builder);
        }
    }
}
