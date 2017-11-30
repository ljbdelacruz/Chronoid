using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace App.Data.Models.Mapping
{
    public class SchedulesAddOnMap : EntityTypeConfiguration<SchedulesAddOn>
    {
        public SchedulesAddOnMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.AddOnType)
                .HasMaxLength(128);

            this.Property(t => t.UserID)
                .HasMaxLength(128);

            this.Property(t => t.AttendanceID)
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("SchedulesAddOns");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.AddOnType).HasColumnName("AddOnType");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.FromDate).HasColumnName("FromDate");
            this.Property(t => t.ToDate).HasColumnName("ToDate");
            this.Property(t => t.Hours).HasColumnName("Hours");
            this.Property(t => t.CreatedAt).HasColumnName("CreatedAt");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.UpdatedAt).HasColumnName("UpdatedAt");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            this.Property(t => t.AttendanceID).HasColumnName("AttendanceID");

            // Relationships
            this.HasOptional(t => t.AddOn)
                .WithMany(t => t.SchedulesAddOns)
                .HasForeignKey(d => d.AddOnType);
            this.HasOptional(t => t.Attendance)
                .WithMany(t => t.SchedulesAddOns)
                .HasForeignKey(d => d.AttendanceID);
            this.HasOptional(t => t.User)
                .WithMany(t => t.SchedulesAddOns)
                .HasForeignKey(d => d.UserID);

        }
    }
}
