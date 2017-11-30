using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace App.Data.Models.Mapping
{
    public class AddOnMap : EntityTypeConfiguration<AddOn>
    {
        public AddOnMap()
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
            this.ToTable("AddOns");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");

            // Relationships
            this.HasOptional(t => t.Company)
                .WithMany(t => t.AddOns)
                .HasForeignKey(d => d.CompanyID);

        }
    }
}
