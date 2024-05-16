using System;
using System.Collections.Generic;

namespace symptomSage.Domain.Entities.Symptoms
{
    public class SymptomsListResp
    {
        public List<SymptomsListData> Symptoms { get; set; }
        
        // public List<Array> Categories { get; set; }
        public bool Status { get; set; }
        
        public int nrOfSymptoms;
        public string StatusMsg { get; set; }
    }
}