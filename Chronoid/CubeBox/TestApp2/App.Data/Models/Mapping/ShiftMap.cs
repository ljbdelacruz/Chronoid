using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace App.Data.Models.Mapping
{
    public class ShiftMap : EntityTypeConfiguration<Shift>
    {
        public ShiftMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.CompanyID)
                .HasMaxLength(128);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(128);

            this.Property(t => t.UpdatedBy)
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("Shift");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.TimeIn).HasColumnName("TimeIn");
            this.Property(t => t.TimeOut).HasColumnName("TimeOut");
            this.Property(t => t.TotalHoursWorked).HasColumnName("TotalHoursWorked");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.CreatedAt).HasColumnName("CreatedAt");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.UpdatedAt).HasColumnName("UpdatedAt");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            this.Property(t => t.IsArchived).HasColumnName("IsArchived");

            // Relationships
            this.HasOptional(t => t.Company)
                .WithMany(t => t.Shifts)
                .HasForeignKey(d => d.CompanyID);

        }
    }
}
