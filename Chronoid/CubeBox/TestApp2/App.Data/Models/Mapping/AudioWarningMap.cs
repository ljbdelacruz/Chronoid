using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace App.Data.Models.Mapping
{
    public class AudioWarningMap : EntityTypeConfiguration<AudioWarning>
    {
        public AudioWarningMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.name)
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("AudioWarnings");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.audiopath).HasColumnName("audiopath");
        }
    }
}
