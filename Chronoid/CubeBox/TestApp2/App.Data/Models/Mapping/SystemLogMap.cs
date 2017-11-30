using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace App.Data.Models.Mapping
{
    public class SystemLogMap : EntityTypeConfiguration<SystemLog>
    {
        public SystemLogMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.CompanyID)
                .HasMaxLength(128);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("SystemLog");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.LogID).HasColumnName("LogID");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.CreatedAt).HasColumnName("CreatedAt");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");

            // Relationships
            this.HasOptional(t => t.Company)
                .WithMany(t => t.SystemLogs)
                .HasForeignKey(d => d.CompanyID);
            this.HasOptional(t => t.LogDescription)
                .WithMany(t => t.SystemLogs)
                .HasForeignKey(d => d.LogID);
            this.HasOptional(t => t.User)
                .WithMany(t => t.SystemLogs)
                .HasForeignKey(d => d.CreatedBy);

        }
    }
}
