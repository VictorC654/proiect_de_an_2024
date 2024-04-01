using symptomSage.BussinesLogic.Core;
using symptomSage.BussinesLogic.Interfaces;
using symptomSage.Domain.Entities.User;

namespace symptomSage.BussinesLogic
{
    public class SessionBl : UserApi,ISession
    {
        public Authentication UserLogin(ULoginData data)
        {
            return new Authentication("Success", true);
        }
    }
}
