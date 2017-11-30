using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace App.Data.Models.Mapping
{
    public class ScheduleWeekMap : EntityTypeConfiguration<ScheduleWeek>
    {
        public ScheduleWeekMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.Week_ID)
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("ScheduleWeeks");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Week_ID).HasColumnName("Week_ID");
            this.Property(t => t.Schedule_ID).HasColumnName("Schedule_ID");

            // Relationships
            this.HasOptional(t => t.Week)
                .WithMany(t => t.ScheduleWeeks)
                .HasForeignKey(d => d.Week_ID);

        }
    }
}
