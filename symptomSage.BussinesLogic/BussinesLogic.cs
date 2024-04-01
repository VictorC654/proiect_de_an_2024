using symptomSage.BussinesLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using symptomSage.BussinesLogic;
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
