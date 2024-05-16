﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using symptomSage.BusinessLogic.Interfaces;
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
            // string medicine = TempData["medicine"] as string;
            if (medicine != null)
            {
                ViewBag.medicine = medicine;
            }
            return View();
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
                    TempData["medicine"] = searchForSymptoms.Medicine;
                    return RedirectToAction("SearchResult");
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}