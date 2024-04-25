using symptomSage.Domain.Entities.User;
using System.Web;
using symptomSage.BusinessLogic.Core;
using symptomSage.BusinessLogic.Interfaces;
using symptomSage.Domain.Entities.Symptoms;

namespace symptomSage.BusinessLogic
{
    public class SessionBl : UserApi, ISession
    {
        public ULoginResp UserLogin(ULoginData data)
        {
            return ULoginAction(data);
        }
        public URegisterResp UserRegister(URegisterData data)
        {
            return URegisterAction(data);
        }

        public SRegisterResp SymptomRegister(SRegisterData data)
        {
            return SRegisterAction(data);
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
            return SymptomListAction();
        }
        public SymptomsDetailsResp SymptomDetails(int symptomId)
        {
            return SymptomDetailsAction(symptomId);
        }
    }
}
