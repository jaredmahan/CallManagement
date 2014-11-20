using System;
using System.Collections.Generic;

namespace CallManagement.Model.Models
{
    public partial class WorkOrder
    {
        public WorkOrder()
        {
            this.Labors = new List<Labor>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Requestor { get; set; }
        public System.DateTime Created { get; set; }
        public System.DateTime Modified { get; set; }
        public string Comments { get; set; }
        public virtual ICollection<Labor> Labors { get; set; }
    }
}
