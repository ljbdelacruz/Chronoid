using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace App.Data.Models.Mapping
{
    public class UserBreakTimeMap : EntityTypeConfiguration<UserBreakTime>
    {
        public UserBreakTimeMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.UserID)
                .HasMaxLength(128);

            this.Property(t => t.Type)
                .HasMaxLength(128);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(128);

            this.Property(t => t.UpdatedBy)
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("UserBreakTime");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.StartDateTime).HasColumnName("StartDateTime");
            this.Property(t => t.EndDateTime).HasColumnName("EndDateTime");
            this.Property(t => t.WorkDateTime).HasColumnName("WorkDateTime");
            this.Property(t => t.TotalTime).HasColumnName("TotalTime");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.AttendanceID).HasColumnName("AttendanceID");
            this.Property(t => t.IsFinishedBreak).HasColumnName("IsFinishedBreak");
            this.Property(t => t.Remarks).HasColumnName("Remarks");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedAt).HasColumnName("CreatedAt");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            this.Property(t => t.UpdatedAt).HasColumnName("UpdatedAt");

            // Relationships
            this.HasOptional(t => t.BreakType)
                .WithMany(t => t.UserBreakTimes)
                .HasForeignKey(d => d.Type);
            this.HasOptional(t => t.User)
                .WithMany(t => t.UserBreakTimes)
                .HasForeignKey(d => d.UserID);

        }
    }
}
