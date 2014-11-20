using CallManagement.Model.Models;
using CallManagement.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace CallManagement.Client.Controllers.api
{
    public class WorkOrderController : ApiController
    {
        public IHttpActionResult Get()
        {
            var context = new CallManagementContext();
            var repo = new Repository<WorkOrder>(context);
            return Ok(repo.GetAll());
        }
        public IHttpActionResult Delete(int id)
        {
            if (id < 1) return NotFound();

            var context = new CallManagementContext();
            var repo = new Repository<WorkOrder>(context);
            var workOrder = repo.Get(id);

            if (workOrder == null) return NotFound();
            repo.Delete(workOrder);

            return Ok();

        }
        public IHttpActionResult Post(WorkOrder vm)
        {
            var context = new CallManagementContext();
            var repo = new Repository<WorkOrder>(context);
            WorkOrder result;
            try {
                if (vm.Id > 0)
                    result = repo.Update(vm, vm.Id);
                else {
                    result = repo.Add(vm);
                }
                return Ok(result);
            }
            catch (Exception ex) {
                return new ExceptionResult(ex, this);
            }
        }
    }
}
