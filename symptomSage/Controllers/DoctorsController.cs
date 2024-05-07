using System.Web.Mvc;
using symptomSage.BusinessLogic.Interfaces;
using symptomSage.Domain.Entities.Doctors;
using symptomSage.Domain.Entities.Medicine;
using symptomSage.Domain.Enums;
using symptomSage.Extension;
using symptomSage.Models;

namespace symptomSage.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly ISession _session;

        public DoctorsController()
        {
            var bl = new BusinessLogic.BussinesLogic();
            _session = bl.GetSessionBl();
        }

        [Route("dadminpanel")]
        public ActionResult DAdminPanel()
        {
            var checkUser = System.Web.HttpContext.Current.GetMySessionObject() != null && System.Web.HttpContext.Current.GetMySessionObject().Level == URole.Admin;
            if (checkUser)
            {
                return View();
            }
            return RedirectToAction("Index","Home");
        }


        [HttpPost]
        [Route("registerdoctor")]
        public ActionResult RegisterDoctor(DoctorRegister doctor)
        {
            if (ModelState.IsValid)
            {
                DRegisterData data = new DRegisterData()
                {
                    Name = doctor.Name,
                    Desc = doctor.Desc,
                    Category = doctor.Category,
                };
                var doctorRegister = _session.DoctorRegister(data);
                if (doctorRegister.Status)
                {
                    return RedirectToAction("DAdminPanel", "Doctors");
                }
            }
            return RedirectToAction("DAdminPanel", "Doctors");
        }
    }
}