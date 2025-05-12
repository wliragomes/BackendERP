using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Contatos;

namespace Infra.EntitiesConfiguration.Contatos
{
    public class ContatoConfiguration : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.ToTable("TB_CONTATO");
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(p => p.Id)
                .HasColumnName("CD_CONTATO")
                .IsRequired()
                .ValueGeneratedOnAdd(); // Garante que o Id seja gerado automaticamente se não for fornecido

            builder.Property(p => p.IdPessoa)
               .HasColumnName("CD_PESSOA");

            builder.Property(p => p.Nome)
                .HasColumnName("NM_NOME");

            builder.Property(p => p.Apelido)
              .HasColumnName("NM_APELIDO");

            builder.Property(p => p.IdDepartamento)
              .HasColumnName("CD_DEPARTAMENTO");

            builder.Property(p => p.IdCargo)
             .HasColumnName("CD_CARGO");

            builder.Property(p => p.Secretaria)
             .HasColumnName("NM_SECRETARIA");

            builder.Property(p => p.DataAniversario)
             .HasColumnName("DT_ANIVERSARIO");

            builder.Property(p => p.IdEmail)
             .HasColumnName("CD_EMAIL");

            builder.HasOne(e => e.Email)
                .WithMany()
                .HasForeignKey(e => e.IdEmail);

            builder.HasOne(c => c.Departamento)
                .WithMany(e => e.Contatos)
                .HasForeignKey(c => c.IdDepartamento);

            builder.HasOne(c => c.Cargo)
                .WithMany(e => e.Contatos)
                .HasForeignKey(c => c.IdCargo);

            builder.HasOne(dc => dc.Pessoa)
               .WithMany(p => p.Contatos)
               .HasForeignKey(dc => dc.IdPessoa)
               .OnDelete(DeleteBehavior.Cascade);            
        }
    }
}
