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
        
        [Route("sadminpanel")]
        public ActionResult SAdminPanel()
        {
            bool isAdmin = true;
            // middleware
                if(System.Web.HttpContext.Current.GetMySessionObject() != null ) 
                {
                    var user = System.Web.HttpContext.Current.GetMySessionObject();
                    if (user.Level == URole.Admin || user.Level == URole.Moderator)
                    {
                        var symptomsList = _session.SymptomsList(isAdmin);
                        UserData userData = new UserData()
                        {
                            Username = user.Username,
                            Level = user.Level,
                        };
                        ViewBag.user = userData.Username;
                        ViewBag.symptomsList = symptomsList.Symptoms;
                        return View();
                    }
                }
            return RedirectToAction("Index", "Home");
        }
        
        [Route("registersymptom")]
        public ActionResult RegisterSymptom()
        {
            // middleware
            var checkUser = System.Web.HttpContext.Current.GetMySessionObject() != null && System.Web.HttpContext.Current.GetMySessionObject().Level == URole.Admin;
            if (checkUser)
            {
                return View();
            }
            return RedirectToAction("Index","Home");
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
    }
}