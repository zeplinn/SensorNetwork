using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using SensorNetwork.Models.Entities;
using SensorNetwork.Misc;

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
            var connect = Startup._builder["Data:DbConnectDebug"];
            optBuilder.UseNpgsql(connect);
            base.OnConfiguring(optBuilder);
#endif
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            EntityHelper.CreateEntities(
                modelBuilder
                ,"SensorNetwork"
                , "SensorNetwork.Models.Entities"
            );
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
