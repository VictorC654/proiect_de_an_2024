using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using symptomSage.Domain.Entities.Symptoms;
using symptomSage.Domain.Entities.User;

namespace symptomSage.BusinessLogic.Interfaces
{
    public interface ISession
    {
            ULoginResp UserLogin(ULoginData data);
            URegisterResp UserRegister(URegisterData data);

            HttpCookie GenCookie(string loginCredential);
            UserMinimal GetUserByCookie(string apiCookieValue);

            SRegisterResp SymptomRegister(SRegisterData data);

            SymptomsListResp SymptomsList(bool isAdmin);
            SymptomsDetailsResp SymptomDetails(int symptomId);
    }
}
