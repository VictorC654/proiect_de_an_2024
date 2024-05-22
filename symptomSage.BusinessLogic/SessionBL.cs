using symptomSage.Domain.Entities.User;
using System.Web;
using symptomSage.BusinessLogic.Core;
using symptomSage.BusinessLogic.Interfaces;
using symptomSage.Domain.Entities.Doctors;
using symptomSage.Domain.Entities.Medicine;
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

        public MRegisterResp MedicineRegister(MRegisterData data)
        {
            return MRegisterAction(data);
        }

        public MedicineListResp MedicineList()
        {
            return MListAction();
        }

        public DRegisterResp DoctorRegister(DRegisterData data)
        {
            return DRegisterAction(data);   
        }

        public DListResp DoctorList()
        {
            return DListAction();
        }
        public HttpCookie GenCookie(string loginCredential)
        {
            return Cookie(loginCredential);
        }
        public UserMinimal GetUserByCookie(string apiCookieValue)
        {
            return UserCookie(apiCookieValue);
        }

        public SymptomDeleteResp SymptomDelete(int symptomId)
        {
            return SymptomDeleteAction(symptomId);
        }
        
        public SymptomsSearchResp SymptomSearch(SymptomsSearchReg data)
        {
            return SSearchData(data);
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
