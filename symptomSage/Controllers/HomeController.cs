using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using symptomSage.Domain.Entities.User;
using symptomSage.BusinessLogic.DBModel;
namespace symptomSage.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            SessionStatus();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
                
            return View();
        }
    }
}