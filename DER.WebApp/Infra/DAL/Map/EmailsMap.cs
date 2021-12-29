using DER.WebApp.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace DER.WebApp.Infra.DAL.Map
{
    public class EmailsMap : EntityTypeConfiguration<Emails>
    {
        public EmailsMap()
        {
            ToTable("tab_emails");

            HasKey(c => c.Id);

            Property(p => p.Id)
                .HasColumnName("eml_id");

            Property(p => p.Assunto)
                .HasColumnName("eml_assunto");

            Property(p => p.CorpoEmail)
              .HasColumnName("eml_corpoEmail");

            Property(p => p.Codigo)
              .HasColumnName("eml_codigo");

            Property(p => p.CC)
              .HasColumnName("eml_cc");

            Property(p => p.Destinatario)
                .HasColumnName("eml_destinatario");

            Property(p => p.DataEnvio)
                .HasColumnName("eml_dataEnvio");
        }
    }
}