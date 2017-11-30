using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace App.Data.Models.Mapping
{
    public class BreakTypeMap : EntityTypeConfiguration<BreakType>
    {
        public BreakTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.Description)
                .HasMaxLength(128);

            this.Property(t => t.CompanyID)
                .HasMaxLength(128);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("BreakType");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.EnableTime).HasColumnName("EnableTime");
            this.Property(t => t.DisableTime).HasColumnName("DisableTime");
            this.Property(t => t.HexColor).HasColumnName("HexColor");
            this.Property(t => t.OrderNumber).HasColumnName("OrderNumber");
            this.Property(t => t.CreatedAt).HasColumnName("CreatedAt");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.TimeLimit).HasColumnName("TimeLimit");
            this.Property(t => t.isArchived).HasColumnName("isArchived");

            // Relationships
            this.HasOptional(t => t.Company)
                .WithMany(t => t.BreakTypes)
                .HasForeignKey(d => d.CompanyID);
            this.HasOptional(t => t.User)
                .WithMany(t => t.BreakTypes)
                .HasForeignKey(d => d.CreatedBy);

        }
    }
}
