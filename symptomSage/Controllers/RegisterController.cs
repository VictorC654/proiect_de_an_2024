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

        // [Route("register")]
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
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
                var userRegister = _session.UserRegister(data);
                if (userRegister.Status)
                {
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    ModelState.AddModelError("", userRegister.StatusMsg);
                    return View("Register");
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
