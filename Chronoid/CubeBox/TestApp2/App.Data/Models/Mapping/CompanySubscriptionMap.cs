using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace App.Data.Models.Mapping
{
    public class CompanySubscriptionMap : EntityTypeConfiguration<CompanySubscription>
    {
        public CompanySubscriptionMap()
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
            this.ToTable("CompanySubscription");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.subscriptionID).HasColumnName("subscriptionID");
            this.Property(t => t.companyID).HasColumnName("companyID");
            this.Property(t => t.dateStarted).HasColumnName("dateStarted");
            this.Property(t => t.dateCreated).HasColumnName("dateCreated");
            this.Property(t => t.isActiveSubscription).HasColumnName("isActiveSubscription");
        }
    }
}
