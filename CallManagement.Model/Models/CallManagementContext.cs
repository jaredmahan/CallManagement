using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using CallManagement.Model.Models.Mapping;

namespace CallManagement.Model.Models
{
    public partial class CallManagementContext : DbContext
    {
        static CallManagementContext()
        {
            Database.SetInitializer<CallManagementContext>(null);
        }

        public CallManagementContext()
            : base("Name=CallManagementContext")
        {
        }

        public DbSet<Labor> Labors { get; set; }
        public DbSet<WorkOrder> WorkOrders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new LaborMap());
            modelBuilder.Configurations.Add(new WorkOrderMap());
        }
    }
}
