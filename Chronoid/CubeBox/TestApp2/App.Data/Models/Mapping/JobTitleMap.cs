using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace App.Data.Models.Mapping
{
    public class JobTitleMap : EntityTypeConfiguration<JobTitle>
    {
        public JobTitleMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.Description)
                .HasMaxLength(50);

            this.Property(t => t.CompanyID)
                .HasMaxLength(128);

            this.Property(t => t.DepartmentID)
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("JobTitles");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.DepartmentID).HasColumnName("DepartmentID");
            this.Property(t => t.isArchived).HasColumnName("isArchived");

            // Relationships
            this.HasOptional(t => t.Company)
                .WithMany(t => t.JobTitles)
                .HasForeignKey(d => d.CompanyID);
            this.HasOptional(t => t.Department)
                .WithMany(t => t.JobTitles)
                .HasForeignKey(d => d.DepartmentID);

        }
    }
}
