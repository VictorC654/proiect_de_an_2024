using System;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using symptomSage.BussinesLogic;
using symptomSage.BussinesLogic.Interfaces;
using symptomSage.Models;
using symptomSage.Domain.Entities.User;

namespace symptomSage.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISession _session;

        public LoginController()
        {
            var bl = new BussinesLogic.BussinesLogic();
            _session = bl.GetSessionBl();
        }
        
        // GET LOGIN PAGE
        [Route("login")]
        public ActionResult Login()
        {
            return View();
        }
        
        // LOGIN
        [HttpPost]
        [Route("login")]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserLogin login)
        {
            if (ModelState.IsValid)
            {
                ULoginData data = new ULoginData
                {
                    Credential = login.Credential,
                    Password = login.Password,
                    LoginIP = Request.UserHostAddress,
                    LoginDateTime = DateTime.Now,
                };
                
                var userLogin = _session.UserLogin(data);
                
                if (userLogin.Status)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", userLogin.StatusMsg);
                    // return View();
                }
            }
            return View();
        }
        
    }
}