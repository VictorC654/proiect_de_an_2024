using System.Collections.Generic;
using symptomSage.BusinessLogic.Core;
using symptomSage.Domain.Enums;

namespace symptomSage.Models
{
    public class UserData
    {
        public string Username { get; set; }
        
        public URole Level { get; set; }
    }
}