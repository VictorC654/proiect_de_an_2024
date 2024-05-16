using System;
using System.Collections.Generic;
using symptomSage.Domain.Entities.Symptoms;

namespace symptomSage.Domain.Entities.Medicine
{
    public class MedicineListResp
    {
        public List<MedicineListData> Medicine { get; set; }
        
        public bool Status { get; set; }
        
        public string StatusMsg { get; set; }
    }
}