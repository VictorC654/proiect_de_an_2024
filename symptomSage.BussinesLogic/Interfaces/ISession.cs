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
        Authentication UserLogin(ULoginData data);
    }
}
