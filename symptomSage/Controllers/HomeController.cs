using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using symptomSage.Domain.Entities.User;
using symptomSage.BussinesLogic.DBModel;
namespace symptomSage.Controllers
{
    public class HomeController : Controller
    {
        public readonly UserContext _userContext;
        public HomeController()
        {
        }
        public ActionResult Index()
        {   
            // var userId = (int)Session["Id"];
            var user = _userContext.Users.Find(1);
            
            return View(user);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
                
            return View();
        }
    }
}