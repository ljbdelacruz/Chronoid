using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace App.Data.Models.Mapping
{
    public class SystemSettingMap : EntityTypeConfiguration<SystemSetting>
    {
        public SystemSettingMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.companyID)
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("SystemSettings");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.language).HasColumnName("language");
            this.Property(t => t.timezone).HasColumnName("timezone");
            this.Property(t => t.companyID).HasColumnName("companyID");

            // Relationships
            this.HasOptional(t => t.Company)
                .WithMany(t => t.SystemSettings)
                .HasForeignKey(d => d.companyID);

        }
    }
}
