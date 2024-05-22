using System.Collections.Generic;

namespace symptomSage.Domain.Entities.Doctors
{
    public class DListResp
    {
        public List<DListData> Doctors { get; set; }
        
        public bool Status { get; set; }
        
        public string StatusMsg { get; set; }
        
        public int nrOfDoctors { get; set; }
    }
}