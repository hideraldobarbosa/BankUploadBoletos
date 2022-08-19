using Bank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bank.Infra.Data.EntityConfiguration
{
    public class CarteiraAtivosClientesConfiguration : IEntityTypeConfiguration<CarteiraAtivosPorCliente>
    {
        public void Configure(EntityTypeBuilder<CarteiraAtivosPorCliente> builder)
        {
            builder.Property(p => p.DataOperacao).IsRequired();
            builder.Property(p => p.CodigoClienteCarteira).IsRequired().HasMaxLength(100);
            builder.Property(p => p.TipoOperacao).IsRequired().HasMaxLength(20);
            builder.Property(p => p.IdBolsa).IsRequired().HasMaxLength(10);
            builder.Property(p => p.CodigoAtivo).IsRequired().HasMaxLength(10);
            builder.Property(p => p.Corretora).IsRequired().HasMaxLength(20);
            builder.Property(p => p.Quantidade).IsRequired();
            builder.Property(p => p.PrecoUnitario).IsRequired().HasPrecision(12, 6);

            builder.Property(p => p.StatusBoleto).HasMaxLength(10);
            builder.Property(p => p.MensagemValidacaoErro);
            builder.Property(p => p.ValorFinanceiroOperacao).HasPrecision(18, 6);
            builder.Property(p => p.ValorDescontoOperacao).HasPrecision(12, 6);

        }
    }
}
