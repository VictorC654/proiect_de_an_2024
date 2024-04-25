using symptomSage.BusinessLogic.Interfaces;


namespace symptomSage.BusinessLogic
{
    public class BussinesLogic
    {
        public ISession GetSessionBl()
        {   
            return new SessionBl();
        }
    }
}
