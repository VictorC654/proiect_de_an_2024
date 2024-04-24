using System.Collections.Generic;

namespace symptomSage.Domain.Entities.Symptoms
{
    public class SymptomsListResp
    {
        public List<SymptomsListData> Symptoms { get; set; }
        public bool Status { get; set; }
        public string StatusMsg { get; set; }
    }
}