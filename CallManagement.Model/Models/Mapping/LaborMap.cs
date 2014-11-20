using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CallManagement.Model.Models.Mapping
{
    public class LaborMap : EntityTypeConfiguration<Labor>
    {
        public LaborMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Id, t.Hours, t.Date, t.WorkerName, t.WorkOrderId });

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Hours)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.WorkerName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.WorkOrderId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Labor");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Hours).HasColumnName("Hours");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.WorkerName).HasColumnName("WorkerName");
            this.Property(t => t.WorkOrderId).HasColumnName("WorkOrderId");

            // Relationships
            this.HasRequired(t => t.WorkOrder)
                .WithMany(t => t.Labors)
                .HasForeignKey(d => d.WorkOrderId);

        }
    }
}
