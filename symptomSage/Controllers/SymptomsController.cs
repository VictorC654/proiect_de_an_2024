using System.Web;
using System.Web.Mvc;
using symptomSage.BusinessLogic.Interfaces;
using symptomSage.Domain.Entities.Symptoms;
using symptomSage.Domain.Enums;
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

        
        [Route("sadminpanel")]
        public ActionResult SAdminPanel()
        {
            bool isAdmin = true;

            // if (System.Web.HttpContext.Current.GetMySessionObject() != null)
            // {
            
                var user = System.Web.HttpContext.Current.GetMySessionObject();
                if (user.Level == URole.Admin)
                {
                    var symptomsList = _session.SymptomsList(isAdmin);

                    ViewBag.symptomsList = symptomsList.Symptoms;
                    return View();
                }
            // }
            return RedirectToAction("Index", "Home");
        }
        
        [Route("registersymptom")]
        public ActionResult RegisterSymptom()
        {
            return View();
        }
        
        [HttpPost]
        [Route("registersymptom")]
        public ActionResult RegisterSymptom(SymptomRegister symptom)
        {
            if (ModelState.IsValid)
            {
                SRegisterData data = new SRegisterData
                {
                    Name = symptom.Name,
                    Category = symptom.Category,
                };
                var symptomRegister = _session.SymptomRegister(data);
                
                if (symptomRegister.Status)
                {
                    return RedirectToAction("SAdminPanel", "Symptoms");
                }

            }
            return RedirectToAction("Index", "Home");
        }
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