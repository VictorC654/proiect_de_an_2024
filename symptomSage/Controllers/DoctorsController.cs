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
            if (System.Web.HttpContext.Current.GetMySessionObject() != null)
            {
                var user = System.Web.HttpContext.Current.GetMySessionObject();
                if (user.Level == URole.Admin || user.Level == URole.Moderator)
                {
                    var doctorList = _session.DoctorList();

                    UserData userData = new UserData()
                    {
                        Username = user.Username,
                        Level = user.Level,
                    };
                    ViewBag.user = userData.Username;
                    ViewBag.doctorList = doctorList.Doctors;
                    ViewBag.nrOfDoctors = doctorList.nrOfDoctors;
                    return View();
                }
            }
            return RedirectToAction("Index","Home");
        }

        public ActionResult DoctorEdit(int doctorId)
        {
            var doctor = _session.DoctorDetails(doctorId);
            ViewBag.doctor = doctor.Doctor;
            ViewBag.id = doctorId;
            return View("EditDoctor");
        }
        public ActionResult DoctorEditAction(DoctorEdit data)
        {
            DEditData doctor = new DEditData()
            {
                id = data.id,
                Name = data.Name,
                Desc = data.Desc,
                Category = data.Category
            };
            var doctorEdit = _session.DoctorEdit(doctor);
            if (doctorEdit.status)
            {
                return RedirectToAction("DAdminPanel");
            }
            return RedirectToAction("DAdminPanel");
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
        public ActionResult DeleteDoctor(int doctorId)
        {
            var deleteDoctor = _session.DeleteDoctor(doctorId);
            if (deleteDoctor.status)
            {
                return RedirectToAction("DAdminPanel");
            }
            return RedirectToAction("DAdminPanel");
        }
    }
}