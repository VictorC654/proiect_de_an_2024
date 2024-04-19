using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using symptomSage.Domain.Entities.User;

namespace symptomSage.BussinesLogic.Interfaces
{
    public interface ISession
    {
            ULoginResp UserLogin(ULoginData data);
            URegisterResp UserRegister(URegisterData data);

            HttpCookie GenCookie(string loginCredential);
            UserMinimal GetUserByCookie(string apiCookieValue);
    }
}
