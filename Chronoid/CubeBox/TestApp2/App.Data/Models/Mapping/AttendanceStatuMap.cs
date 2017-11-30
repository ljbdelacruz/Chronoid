using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace App.Data.Models.Mapping
{
    public class AttendanceStatuMap : EntityTypeConfiguration<AttendanceStatu>
    {
        public AttendanceStatuMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.CompanyID)
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("AttendanceStatus");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.IsArchived).HasColumnName("IsArchived");

            // Relationships
            this.HasOptional(t => t.Company)
                .WithMany(t => t.AttendanceStatus)
                .HasForeignKey(d => d.CompanyID);

        }
    }
}
