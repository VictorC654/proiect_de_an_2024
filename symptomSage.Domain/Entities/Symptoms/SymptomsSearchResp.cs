using System.Collections.Generic;
using symptomSage.Domain.Entities.Medicine;

namespace symptomSage.Domain.Entities.Symptoms
{
    public class SymptomsSearchResp
    {
        public List<MedicineListData> Medicine { get; set; }
        public bool Status { get; set; }
        public string StatusMsg { get; set; }
    }
}