using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using symptomSage.BusinessLogic.Interfaces;
using symptomSage.Domain.Entities.Doctors;
using symptomSage.Domain.Entities.Medicine;
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
            
            var symptomsList = _session.SymptomsList(true);
            
            ViewBag.symptomsList = symptomsList.Symptoms;
            return View();
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
                        ViewBag.nrOfSymptoms = symptomsList.nrOfSymptoms;
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
        
        public ActionResult SearchResult()
        {
            List<MedicineListData> medicine = TempData["medicine"] as List<MedicineListData>;
            List<DListData> doctors = TempData["doctors"] as List<DListData>;
            List<string> selectedSymptoms = TempData["selectedSymptoms"] as List<string>;


            if (medicine != null && doctors != null)
            {
                ViewBag.selectedSymptoms = selectedSymptoms;
                ViewBag.medicine = medicine;
                ViewBag.doctors = doctors;
            }
            return View();
        }

        public ActionResult DeleteSymptom(int symptomId)
        {
            var deleteSymptom = _session.SymptomDelete(symptomId);
            if (deleteSymptom.Status)
            {
                return RedirectToAction("SAdminPanel");
            }
            return RedirectToAction("SAdminPanel");
        }
        
        [HttpPost]
        public ActionResult SearchSymptom(SymptomsData model)
        {
            if (ModelState.IsValid)
            {
                List<string> selectedSymptoms = model.selectedSymptoms;
                List<string> ssList = new List<string>();
                foreach (string symptom in selectedSymptoms)
                {
                    ssList.Add(symptom);
                }
                
                SymptomsSearchReg data = new SymptomsSearchReg
                {
                    symptomIds = ssList,
                };
                
                var searchForSymptoms = _session.SymptomSearch(data);
                
                if (searchForSymptoms.Status)
                {
                    TempData["selectedSymptoms"] = data.symptomIds;
                    TempData["medicine"] = searchForSymptoms.Medicine;
                    TempData["doctors"] = searchForSymptoms.Doctors;
                    return RedirectToAction("SearchResult");
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}