using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace App.Data.Models.Mapping
{
    public class DepartmentMap : EntityTypeConfiguration<Department>
    {
        public DepartmentMap()
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
            this.ToTable("Department");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.CreatedAt).HasColumnName("CreatedAt");
            this.Property(t => t.UpdatedAt).HasColumnName("UpdatedAt");
            this.Property(t => t.isArchived).HasColumnName("isArchived");

            // Relationships
            this.HasOptional(t => t.Company)
                .WithMany(t => t.Departments)
                .HasForeignKey(d => d.CompanyID);

        }
    }
}
