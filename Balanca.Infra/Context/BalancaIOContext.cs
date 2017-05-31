using Balanca.Domain;
using Balanca.Infra.EntidadeConfig;
using Balanca.Infra.Migrations;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Balanca.Infra.Context
{
    public class BalancaIOContext : DbContext
    {
        public static BalancaIOContext Create()
        {
            return new BalancaIOContext();
        }

        public BalancaIOContext()
        : base("BalancaIOConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BalancaIOContext, Configuration>());
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
