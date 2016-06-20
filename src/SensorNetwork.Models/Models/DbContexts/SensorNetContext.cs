using System.Data.Common;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using SensorNetwork.Models.Entities;

namespace SensorNetwork.Models.DbContexts
{
    public class SensorNetContext : DbContext
    {
        private IConfigurationRoot _configRoot;

        
        public DbSet<Reading> Readings { get; set; }
        public DbSet<Network> Networks { get; set; }
        public DbSet<Sensor> Sensors { get; set; }

        public SensorNetContext(IConfigurationRoot configRoot)
        {
            _configRoot = configRoot;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optBuilder)
        {
#if DEBUG
            var connect = _configRoot["Data:DbConnectDebug"];
            optBuilder.UseNpgsql(connect);
            base.OnConfiguring(optBuilder);
#elif RELEASE
            var connect = _configRoot["Data:DbConnect"];
            optBuilder.UseNpgsql(connect);
            base.OnConfiguring(optBuilder);
#endif
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Network>(e =>
            {
                e.ForNpgsqlToTable("Network");
                e.HasKey(key => new { key.Id });
                e.Property(n => n.Id).ValueGeneratedOnAdd();
            });

            builder.Entity<Sensor>(e =>
            {
                e.ForNpgsqlToTable("Sensors");
                e.HasKey(key => new { key.Id });
                e.HasOne(s => s.Network).WithMany(n => n.Sensors);
                e.Property(s => s.Id).ValueGeneratedOnAdd();
                
            });

            builder.Entity<Reading>(e =>
            {
                e.ForNpgsqlToTable("Readings");                
                e.HasKey(r => new { r.Time, r.SensorId});
                //e.Property(r => r.ReadingID).ValueGeneratedOnAdd();
                e.HasOne(r => r.Sensor).WithMany(s => s.Readings).HasForeignKey(r => r.SensorId);
            });
            base.OnModelCreating(builder);
        }
    }
}
