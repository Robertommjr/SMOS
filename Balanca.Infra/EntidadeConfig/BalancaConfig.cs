using Balanca.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Balanca.Infra.EntidadeConfig
{
    public class BalancaConfig : EntityTypeConfiguration<TB_Balanca>
    {
        public BalancaConfig()
        {
            HasKey(c => c.BalancaId);

            Property(c => c.descricaoBalanca).HasMaxLength(255);

            Property(c => c.NomeBalanca).HasMaxLength(255);

            Property(c => c.pesoAtual).IsRequired();
        }
    }
}
