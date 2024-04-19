using System.Web.Mvc;
using symptomSage.BussinesLogic.Interfaces;
using symptomSage.Domain.Entities.User;
using symptomSage.Models;

namespace symptomSage.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ISession _session;

        public RegisterController()
        {
            var bl = new BussinesLogic.BussinesLogic();
            _session = bl.GetSessionBl();
        }

        [Route("register")]
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(UserRegister register)
        {
            if (ModelState.IsValid)
            {
                URegisterData data = new URegisterData
                {
                    Username = register.Username,
                    Email = register.Email,
                    Password = register.Password,
                    
                };
                var userRegiser = _session.UserRegister(data);
                if (userRegiser.Status)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    ModelState.AddModelError("", userRegiser.StatusMsg);
                    return View("Register");
                }
            }
            return View("Register");
        }
    }
}
