namespace symptomSage.Domain.Entities.Symptoms
{
    public class SymptomsDetailsResp
    {
            public SymptomDetailsData Symptom { get; set; }
            public bool Status { get; set; }
            public string StatusMsg { get; set; }
    }
}