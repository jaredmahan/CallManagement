using System;
using System.Collections.Generic;

namespace CallManagement.Model.Models
{
    public partial class Labor
    {
        public int Id { get; set; }
        public int Hours { get; set; }
        public System.DateTime Date { get; set; }
        public string WorkerName { get; set; }
        public int WorkOrderId { get; set; }
        public virtual WorkOrder WorkOrder { get; set; }
    }
}
