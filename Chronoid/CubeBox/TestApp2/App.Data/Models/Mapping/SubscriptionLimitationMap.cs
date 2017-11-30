using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace App.Data.Models.Mapping
{
    public class SubscriptionLimitationMap : EntityTypeConfiguration<SubscriptionLimitation>
    {
        public SubscriptionLimitationMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.SubscriptionID)
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("SubscriptionLimitation");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Admins).HasColumnName("Admins");
            this.Property(t => t.Users).HasColumnName("Users");
            this.Property(t => t.SubscriptionID).HasColumnName("SubscriptionID");

            // Relationships
            this.HasOptional(t => t.SubscriptionType)
                .WithMany(t => t.SubscriptionLimitations)
                .HasForeignKey(d => d.SubscriptionID);

        }
    }
}
