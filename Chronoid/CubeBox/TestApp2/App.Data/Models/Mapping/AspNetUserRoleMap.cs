using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace App.Data.Models.Mapping
{
    public class AspNetUserRoleMap : EntityTypeConfiguration<AspNetUserRole>
    {
        public AspNetUserRoleMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.UserId)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.RoleId)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("AspNetUserRoles");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.RoleId).HasColumnName("RoleId");
            this.Property(t => t.id).HasColumnName("id");

            // Relationships
            this.HasRequired(t => t.AspNetRole)
                .WithMany(t => t.AspNetUserRoles)
                .HasForeignKey(d => d.RoleId);
            this.HasRequired(t => t.AspNetUser)
                .WithMany(t => t.AspNetUserRoles)
                .HasForeignKey(d => d.UserId);

        }
    }
}
