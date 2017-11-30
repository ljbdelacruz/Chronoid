using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace App.Data.Models.Mapping
{
    public class HolidayMap : EntityTypeConfiguration<Holiday>
    {
        public HolidayMap()
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
            this.ToTable("Holiday");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");

            // Relationships
            this.HasOptional(t => t.Company)
                .WithMany(t => t.Holidays)
                .HasForeignKey(d => d.CompanyID);

        }
    }
}
