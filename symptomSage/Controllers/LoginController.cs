using System;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using symptomSage.BusinessLogic;
using symptomSage.BusinessLogic.Interfaces;
using symptomSage.Models;
using symptomSage.Domain.Entities.User;

namespace symptomSage.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISession _session;

        public LoginController()
        {
            var bl = new BusinessLogic.BussinesLogic();
            _session = bl.GetSessionBl();
        }
        
        [Route("login")]
        public ActionResult Login()
        {
            return View();
        }
        
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
                    HttpCookie cookie = _session.GenCookie(login.Credential);
                    ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                    ModelState.AddModelError("", userLogin.StatusMsg);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", userLogin.StatusMsg);
                    return View("Login");
                }
            }
            return View();
        }
        
    }
}