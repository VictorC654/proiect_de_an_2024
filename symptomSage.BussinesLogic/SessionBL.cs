using symptomSage.BussinesLogic.Core;
using symptomSage.BussinesLogic.Interfaces;
using symptomSage.Domain.Entities.User;
using System.Web;


namespace symptomSage.BussinesLogic
{
    public class SessionBl : UserApi,ISession
    {
        public ULoginResp UserLogin(ULoginData data)
        {
            return ULoginAction(data);
        }
        public URegisterResp UserRegister(URegisterData data)
        {
            return URegisterAction(data);
        }
        public HttpCookie GenCookie(string loginCredential)
        {
            return Cookie(loginCredential);
        }
        public UserMinimal GetUserByCookie(string apiCookieValue)
        {
            return UserCookie(apiCookieValue);
        }
    }
}
