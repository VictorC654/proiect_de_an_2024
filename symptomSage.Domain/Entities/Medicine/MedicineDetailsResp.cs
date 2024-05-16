namespace symptomSage.Domain.Entities.Medicine
{
    public class MedicineDetailsResp
    {
        public MedicineDetailsData Medicine { get; set; }
        public bool Status { get; set; }
        public string StatusMsg { get; set; }
    }
}