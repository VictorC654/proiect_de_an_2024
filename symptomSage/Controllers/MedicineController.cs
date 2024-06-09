using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using symptomSage.BusinessLogic.Interfaces;
using symptomSage.Domain.Entities.Medicine;
using symptomSage.Domain.Enums;
using symptomSage.Extension;
using symptomSage.Models;

using symptomSage.Models;

namespace symptomSage.Controllers
{
    public class MedicineController : Controller
    {
        private readonly ISession _session;

        public MedicineController()
        {
            var bl = new BusinessLogic.BussinesLogic();
            _session = bl.GetSessionBl();
        }

        [Route("madminpanel")]
        public ActionResult MAdminPanel()
        {
            if (System.Web.HttpContext.Current.GetMySessionObject() != null)
            {
                var user = System.Web.HttpContext.Current.GetMySessionObject();
                if (user.Level == URole.Admin || user.Level == URole.Moderator)
                {
                    var medicineList = _session.MedicineList();

                    UserData userData = new UserData()
                    {
                        Username = user.Username,
                        Level = user.Level,
                    };
                    ViewBag.user = userData.Username;
                    ViewBag.medicineList = medicineList.Medicines;
                    ViewBag.nrOfMedicines = medicineList.nrOfMedicines;
                    return View();
                }
            }
            return RedirectToAction("Index","Home");
        }
        
        [HttpPost]
        public ActionResult EditMedicineAction(MedicineEdit medicine)
        {
            MEditData data = new MEditData()
            {
                id = medicine.Id,
                Name = medicine.Name,
                Desc = medicine.Desc,
                Category = medicine.Category
            };
            var medicineEdit = _session.MedicineEdit(data);
            if (medicineEdit.status)
            {
                return RedirectToAction("MAdminPanel", "Medicine");
            }
            return RedirectToAction("MAdminPanel");
        }
        
        
        [Route("editmedicine")]
        public ActionResult EditMedicine(int medicineId)
        {
                var medicine = _session.MedicineDetails(medicineId);
                int Id = medicineId;
                ViewBag.medicine = medicine.Medicine;
                ViewBag.id = Id;
                return View("EditMedicine");
        }
        [HttpPost]
        [Route("registermedicine")]
        public ActionResult RegisterMedicine(MedicineRegister medicine)
        {
            
            if (ModelState.IsValid)
            {
                string image = Path.Combine(Server.MapPath("~/Images"),
                Path.GetFileName(medicine.Image.FileName));
                medicine.Image.SaveAs(image);
                string imagePath = "~/Images/" + medicine.Image.FileName;
                MRegisterData data = new MRegisterData()
                {
                    Name = medicine.Name,
                    Desc = medicine.Desc,
                    Category = medicine.Category,
                    imagePath = imagePath,
                };
                var medicineRegister = _session.MedicineRegister(data);
                if (medicineRegister.Status)
                {
                    return RedirectToAction("MAdminPanel", "Medicine");
                }
            }
            return RedirectToAction("MAdminPanel", "Medicine");
        }
        public ActionResult DeleteMedicine(int medicineId)
        {
            var deleteMedicine = _session.MedicineDelete(medicineId);
            if (deleteMedicine.status)
            {
                return RedirectToAction("MAdminPanel");
            }
            return RedirectToAction("MAdminPanel");
        }


    }
}