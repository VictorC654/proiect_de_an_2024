using symptomSage.BussinesLogic.Interfaces;
namespace symptomSage.BussinesLogic
{
    public class BussinesLogic
    {
        public ISession GetSessionBl()
        {   
            return new SessionBl();
        }
    }
}
