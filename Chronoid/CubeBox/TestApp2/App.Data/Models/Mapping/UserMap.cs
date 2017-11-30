using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace App.Data.Models.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.Code)
                .HasMaxLength(50);

            this.Property(t => t.LastName)
                .HasMaxLength(100);

            this.Property(t => t.FirstName)
                .HasMaxLength(100);

            this.Property(t => t.MiddleName)
                .HasMaxLength(100);

            this.Property(t => t.ExtensionName)
                .HasMaxLength(20);

            this.Property(t => t.Gender)
                .HasMaxLength(20);

            this.Property(t => t.MaritalStatus)
                .HasMaxLength(50);

            this.Property(t => t.Nationality)
                .HasMaxLength(50);

            this.Property(t => t.Religion)
                .HasMaxLength(50);

            this.Property(t => t.JobTitleID)
                .HasMaxLength(128);

            this.Property(t => t.DepartmentID)
                .HasMaxLength(128);

            this.Property(t => t.Email)
                .HasMaxLength(50);

            this.Property(t => t.Token)
                .HasMaxLength(255);

            this.Property(t => t.ContactNumber)
                .HasMaxLength(50);

            this.Property(t => t.ProfileImage)
                .HasMaxLength(256);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(50);

            this.Property(t => t.UpdatedBy)
                .HasMaxLength(50);

            this.Property(t => t.Address)
                .HasMaxLength(255);

            this.Property(t => t.ContactPerson)
                .HasMaxLength(255);

            this.Property(t => t.ContactPersonNumber)
                .HasMaxLength(25);

            this.Property(t => t.JobStatusID)
                .HasMaxLength(128);

            this.Property(t => t.GoogleEmail)
                .HasMaxLength(50);

            this.Property(t => t.AspNetUserID)
                .HasMaxLength(256);

            this.Property(t => t.OnlineStatus)
                .HasMaxLength(32);

            this.Property(t => t.CompanyID)
                .HasMaxLength(128);

            this.Property(t => t.TimeZone)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("Users");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.MiddleName).HasColumnName("MiddleName");
            this.Property(t => t.ExtensionName).HasColumnName("ExtensionName");
            this.Property(t => t.Gender).HasColumnName("Gender");
            this.Property(t => t.MaritalStatus).HasColumnName("MaritalStatus");
            this.Property(t => t.Nationality).HasColumnName("Nationality");
            this.Property(t => t.Religion).HasColumnName("Religion");
            this.Property(t => t.Birthday).HasColumnName("Birthday");
            this.Property(t => t.JobTitleID).HasColumnName("JobTitleID");
            this.Property(t => t.DepartmentID).HasColumnName("DepartmentID");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.RoleID).HasColumnName("RoleID");
            this.Property(t => t.Token).HasColumnName("Token");
            this.Property(t => t.ContactNumber).HasColumnName("ContactNumber");
            this.Property(t => t.ProfileImage).HasColumnName("ProfileImage");
            this.Property(t => t.CreatedAt).HasColumnName("CreatedAt");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.UpdatedAt).HasColumnName("UpdatedAt");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.ContactPerson).HasColumnName("ContactPerson");
            this.Property(t => t.ContactPersonNumber).HasColumnName("ContactPersonNumber");
            this.Property(t => t.JobStatusID).HasColumnName("JobStatusID");
            this.Property(t => t.GoogleEmail).HasColumnName("GoogleEmail");
            this.Property(t => t.ManagerID).HasColumnName("ManagerID");
            this.Property(t => t.HouseID).HasColumnName("HouseID");
            this.Property(t => t.DateHired).HasColumnName("DateHired");
            this.Property(t => t.AspNetUserID).HasColumnName("AspNetUserID");
            this.Property(t => t.DateEnded).HasColumnName("DateEnded");
            this.Property(t => t.ClientID).HasColumnName("ClientID");
            this.Property(t => t.TrainingStarted).HasColumnName("TrainingStarted");
            this.Property(t => t.TrainingEnded).HasColumnName("TrainingEnded");
            this.Property(t => t.LoginAccount).HasColumnName("LoginAccount");
            this.Property(t => t.OnlineStatus).HasColumnName("OnlineStatus");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.TimeZone).HasColumnName("TimeZone");
            this.Property(t => t.isArchived).HasColumnName("isArchived");

            // Relationships
            this.HasOptional(t => t.AspNetUser)
                .WithMany(t => t.Users)
                .HasForeignKey(d => d.AspNetUserID);
            this.HasOptional(t => t.Company)
                .WithMany(t => t.Users)
                .HasForeignKey(d => d.CompanyID);
            this.HasOptional(t => t.Department)
                .WithMany(t => t.Users)
                .HasForeignKey(d => d.DepartmentID);
            this.HasOptional(t => t.JobStatu)
                .WithMany(t => t.Users)
                .HasForeignKey(d => d.JobStatusID);
            this.HasOptional(t => t.JobTitle)
                .WithMany(t => t.Users)
                .HasForeignKey(d => d.JobTitleID);

        }
    }
}
