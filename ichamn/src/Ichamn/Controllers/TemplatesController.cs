using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcForum.Controllers
{
    public class TemplatesController : Controller
    {
        //
        // GET: /Templates/

        public ActionResult Select(int? id)
        {
            if (id == 0)
            {
                if (Request.ApplicationPath != null &&
                    Request.ApplicationPath[Request.ApplicationPath.Length - 1] == '/')
                {
                    return File(Url.Content("/Templates/JQueryTemplate.htm"), "text/html");
                }
                return File(Url.Content(Request.ApplicationPath + "/Templates/JQueryTemplate.htm"), "text/html");
            } 
            
            if (Request.ApplicationPath != null &&
            Request.ApplicationPath[Request.ApplicationPath.Length - 1] == '/')
            {
                return File(Url.Content("/Templates/embedTemplates.htm"), "text/html");
            }
            return File(Url.Content(Request.ApplicationPath + "/Templates/embedTemplates.htm"), "text/html");
        }

    }
}
