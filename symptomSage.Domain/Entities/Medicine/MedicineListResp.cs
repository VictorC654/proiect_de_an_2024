using System;
using System.Collections.Generic;
using symptomSage.Domain.Entities.Symptoms;

namespace symptomSage.Domain.Entities.Medicine
{
    public class MedicineListResp
    {
        public List<MedicineListData> Medicines { get; set; }
        
        public bool Status { get; set; }
        
        public string Desc { get; set; }
        
        public int nrOfMedicines { get; set; }
    }
}