using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using symptomSage.Domain.Entities.User;
using symptomSage.BusinessLogic.DBModel;
using symptomSage.BusinessLogic.Interfaces;

namespace symptomSage.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ISession _session;
        
        public HomeController()
        {
            var bl = new BusinessLogic.BussinesLogic();
            _session = bl.GetSessionBl();
        }

        public ActionResult Index()
        {
            SessionStatus();
            var nrOfSymptoms = _session.SymptomsList(true).nrOfSymptoms;
            var nrOfMedicines = _session.MedicineList().nrOfMedicines;
            var nrOfDoctors = _session.DoctorList().nrOfDoctors;

            ViewBag.nrOfSymptoms = nrOfSymptoms;
            ViewBag.nrOfMedicines = nrOfMedicines;
            ViewBag.nrOfDoctors = nrOfDoctors;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
                
            return View();
        }
    }
}