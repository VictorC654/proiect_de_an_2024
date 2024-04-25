using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using symptomSage.BusinessLogic.Interfaces;
using symptomSage.Extension;
using symptomSage.Models;
namespace symptomSage.Controllers
{
    public class SymptomsController : Controller
    {
        private readonly ISession _session;

        public SymptomsController()
        {
            var bl = new BusinessLogic.BussinesLogic();
            _session = bl.GetSessionBl();
        }
        
        [Route("selectsymptoms")]
        public ActionResult Select()
        {
            UserData u = new UserData();
            u.Username = "Victor";
            return View(u);
        }
        // public ActionResult SymptomList()
        // {
        //     bool isAdmin = false;
        //     var user = System.Web.HttpContext.Current.GetMySessionObject();
        //     UserData u = new UserData
        //     {
        //         Username = user.Username,
        //     };
        //
        //     var blogList = _session.SymptomsList(isAdmin);
        //     
        //     
        //     ViewBag.username = u.Username;
        //     ViewBag.blogList = blogList.Symptoms;
        //     
        //     return View("AdminSymptomsList");
        // }
        public ActionResult AdminSymptomsList()
        {
            bool isAdmin = true;
            var user = System.Web.HttpContext.Current.GetMySessionObject();
            UserData u = new UserData
            {
                Username = user.Username,
            };

            var symptomsList = _session.SymptomsList(isAdmin);
            
            
            ViewBag.username = u.Username;
            ViewBag.symptomList = symptomsList.Symptoms;
            
            return View("AdminSymptomsList");
        }

    }
}