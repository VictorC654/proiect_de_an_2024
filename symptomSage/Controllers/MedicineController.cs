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
            var checkUser = System.Web.HttpContext.Current.GetMySessionObject() != null && System.Web.HttpContext.Current.GetMySessionObject().Level == URole.Admin;
            if (checkUser)
            {
                return View();
            }
            return RedirectToAction("Index","Home");
        }


        [HttpPost]
        [Route("registermedicine")]
        public ActionResult RegisterMedicine(MedicineRegister medicine)
        {
            if (ModelState.IsValid)
            {
                MRegisterData data = new MRegisterData()
                {
                    Name = medicine.Name,
                    Desc = medicine.Desc,
                    Category = medicine.Category,
                };
                var medicineRegister = _session.MedicineRegister(data);
                if (medicineRegister.Status)
                {
                    return RedirectToAction("MAdminPanel", "Medicine");
                }
            }
            return RedirectToAction("MAdminPanel", "Medicine");
        }
    }
}