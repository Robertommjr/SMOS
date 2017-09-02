using SMOS.Domain;
using SMOS.Infra.EntidadeConfig;
using SMOS.Infra.Migrations;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SMOS.Infra.Context
{
    public class SMOSContext : DbContext
    {
        public static SMOSContext Create()
        {
            return new SMOSContext();
        }

        public SMOSContext()
        : base("SMOSContextConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SMOSContext, Configuration>());
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(
                    properties =>
                        properties.ReflectedType != null && properties.Name == properties.ReflectedType.Name + "Id")
                .Configure(properties => properties.IsKey());
            modelBuilder.Properties<string>().Configure(properties => properties.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(properties => properties.HasMaxLength(250));
            modelBuilder.Properties<DateTime>().Configure(properties => properties.HasColumnType("datetime2"));


            modelBuilder.Configurations.Add(new BalancaConfig());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<TB_Balanca> Escola { get; set; }
    }
}
