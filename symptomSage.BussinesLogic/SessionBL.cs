using symptomSage.BussinesLogic.Core;
using symptomSage.BussinesLogic.Interfaces;
using symptomSage.Domain.Entities.User;
using System.Web;
using symptomSage.Domain.Entities.Symptoms;
using symptomSage.BussinesLogic.Core;

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
        public SymptomsListResp SymptomsList(bool isAdmin)
        {
            return SymptomsListAction(isAdmin);
        }
        public SymptomsDetailsResp SymptomDetails(int symptomId)
        {
            return SymptomsDetailsAction(symptomId);
        }
    }
}
