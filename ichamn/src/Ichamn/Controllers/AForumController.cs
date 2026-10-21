using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using Ichamn.Models;

namespace Ichamn.Controllers
{
    [SessionState(SessionStateBehavior.Disabled)]
    [NoAsyncTimeout]
    public class AForumController : AsyncController
    {
        [HttpPost]
        public void GetInformationAsync()
        {
            var sessionId = Guid.Parse(HttpContext.Request.Form[0]);
            AsyncManager.OutstandingOperations.Increment();
            var task = Task.Factory.StartNew(() =>
                                             GetInformationFromWarehouse(sessionId));
            task.ContinueWith(p_t =>
            {
                AsyncManager.Parameters["p_result"] = p_t.Result;
                AsyncManager.OutstandingOperations.Decrement();
            });
        }

        public JsonResult GetInformationCompleted(string p_result)
        {
            return Json(new object[] { p_result });
        }

        private string GetInformationFromWarehouse(Guid p_sessionId)
        {
            return OForum.GetWarehouseInstance().GetAitems(p_sessionId);
        }
    }
}
