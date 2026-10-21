using System;
using System.Web.Mvc;
using Ichamn.Helpers;
using Ichamn.Models;
using System.Web.SessionState;

namespace MvcForum.Controllers
{
    [SessionState(SessionStateBehavior.Disabled)]
    public class ForumController : Controller
    {
        [HttpPost]
        public JsonResult AddSubscription()
        {
            try
            {
                var sessionId = Guid.Parse(HttpContext.Request.Form[0]);
                var myOfficeId = Guid.Parse(HttpContext.Request.Form[1]);
                var secuence = int.Parse(HttpContext.Request.Form[2]);
                var oTopic = ForumIndex.GetTopic(myOfficeId);
                oTopic.AddSubscriptor(new Subscriptor(sessionId,secuence));
                return Json(new { officeId = myOfficeId, title = oTopic.Title });
            }
            catch (Exception ex)
            {
                return Json(new object[] { "Error", ex.Message + ex.StackTrace });
            }
        }

        [HttpPost]
        public JsonResult RemoveSubscription()
        {
            try
            {
                var sessionId = Guid.Parse(HttpContext.Request.Form[0]);
                var myOfficeId = Guid.Parse(HttpContext.Request.Form[1]);
                var oTopic = ForumIndex.GetTopic(myOfficeId);
                oTopic.RemoveSubscriptor(sessionId);
                return Json(new { officeId = myOfficeId, title = oTopic.Title });
            }
            catch (Exception ex)
            {
                return Json(new object[] { "Error", ex.Message + ex.StackTrace });
            }
        }
        [HttpPost]
        public JsonResult AddInitialSubscription()
        {
            try
            {
                var sessionId = Guid.Parse(HttpContext.Request.Form[0]);
                OForum.GetWarehouseInstance().AddSession(sessionId);
                OForum.GetInstance().AddSubscriptor(new Subscriptor(sessionId, 0));
                return Json(new object[] { "Ok" });
            }
            catch (Exception ex)
            {
                return Json(new object[] { "Error",ex.Message + ex.StackTrace });
            }
        }

        [HttpPost][ValidateInput(false)]
        public JsonResult SendTopic()
        {
            try
            {
                var author = HttpContext.Request.Form[0];
                var title = HttpContext.Request.Form[1];
                var message = HttpContext.Request.Form[2];
                var topicId = Guid.NewGuid();
                if (!HtmValidationHelper.Validate(message))
                {
                    throw new Exception("El mensaje contiene HTML no valido");
                }
                OForum.GetInstance().Add(new OTopicLight(OForum.GetInstance().Id, topicId, title, author));
                ForumIndex.GetTopic(topicId).Add(new OMessage(topicId, author, message));
                return Json( new object[] { "Ok" } );
            }
            catch ( Exception ex )
            {
                return Json(new object[] { "Error", ex.Message + ex.StackTrace });
            }
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SendMessage()
        {
            try
            {
                var topicId = Guid.Parse(HttpContext.Request.Form[0]);
                var author = HttpContext.Request.Form[1];
                var message = HttpContext.Request.Form[2];
                if (!HtmValidationHelper.Validate(message))
                {
                    throw new Exception("El mensaje contiene HTML no valido");
                }
                ForumIndex.GetTopic(topicId).Add(new OMessage(topicId,author,message));
                return Json( new object[] { "Ok" } );
            }
            catch ( Exception ex )
            {
                return Json(new object[] { "Error", ex.Message + ex.StackTrace });
            }
        }

         [HttpPost]
         public JsonResult CleanSession()
         {
             try{
                 var sessionIdStr = HttpContext.Request.Form[0];
                 Guid sessionId;
                 if (Guid.TryParse(sessionIdStr,out sessionId))
                 {
                     OForum.GetInstance().RemoveSubscriptor(sessionId);
                     ForumIndex.DeleteSubscriptor(sessionId);
                     OForum.GetWarehouseInstance().CleanSession(sessionId);
                 }
                 return Json( "OK" );
             }catch (Exception ex)
             {
                 return Json(new object[] { "Error", ex.Message + ex.StackTrace });
             }
         }
    }
}
