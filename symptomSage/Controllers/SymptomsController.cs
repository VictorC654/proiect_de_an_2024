using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace symptomSage.Controllers
{
    public class SymptomsController : Controller
    {
        // GET: Symptoms
        [Route("selectsymptoms")]
        public ActionResult select()
        {
            return View();
        }
    }
}