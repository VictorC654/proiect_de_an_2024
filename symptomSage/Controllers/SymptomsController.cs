using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using symptomSage.Models;

namespace symptomSage.Controllers
{
    public class SymptomsController : Controller
    {
        // GET: Symptoms
        [Route("selectsymptoms")]
        public ActionResult Select()
        {
            UserData u = new UserData();
            u.Username = "Victor";
            return View(u);
        }
    }
}