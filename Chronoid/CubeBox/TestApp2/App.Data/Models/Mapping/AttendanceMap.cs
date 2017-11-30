using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace App.Data.Models.Mapping
{
    public class AttendanceMap : EntityTypeConfiguration<Attendance>
    {
        public AttendanceMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.UserID)
                .HasMaxLength(128);

            this.Property(t => t.AttendanceStatusID)
                .HasMaxLength(128);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(128);

            this.Property(t => t.UpdatedBy)
                .HasMaxLength(128);

            this.Property(t => t.ShiftID)
                .HasMaxLength(128);

            this.Property(t => t.AddOnID)
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("Attendance");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.AttendanceStatusID).HasColumnName("AttendanceStatusID");
            this.Property(t => t.AttendanceDate).HasColumnName("AttendanceDate");
            this.Property(t => t.TimeIn).HasColumnName("TimeIn");
            this.Property(t => t.TimeOut).HasColumnName("TimeOut");
            this.Property(t => t.TimeInImage).HasColumnName("TimeInImage");
            this.Property(t => t.TimeOutImage).HasColumnName("TimeOutImage");
            this.Property(t => t.Remarks).HasColumnName("Remarks");
            this.Property(t => t.HrsWork).HasColumnName("HrsWork");
            this.Property(t => t.ProductiveHrs).HasColumnName("ProductiveHrs");
            this.Property(t => t.TotalBreakTime).HasColumnName("TotalBreakTime");
            this.Property(t => t.TotalLateTime).HasColumnName("TotalLateTime");
            this.Property(t => t.TotalUnderTime).HasColumnName("TotalUnderTime");
            this.Property(t => t.TotalOverBreak).HasColumnName("TotalOverBreak");
            this.Property(t => t.CreatedAt).HasColumnName("CreatedAt");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.UpdatedAt).HasColumnName("UpdatedAt");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            this.Property(t => t.ShiftID).HasColumnName("ShiftID");
            this.Property(t => t.AddOnID).HasColumnName("AddOnID");
            this.Property(t => t.IsArchived).HasColumnName("IsArchived");

            // Relationships
            this.HasOptional(t => t.AddOn)
                .WithMany(t => t.Attendances)
                .HasForeignKey(d => d.AddOnID);
            this.HasOptional(t => t.Shift)
                .WithMany(t => t.Attendances)
                .HasForeignKey(d => d.ShiftID);
            this.HasOptional(t => t.User)
                .WithMany(t => t.Attendances)
                .HasForeignKey(d => d.UserID);

        }
    }
}
