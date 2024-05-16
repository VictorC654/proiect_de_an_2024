using System;

namespace symptomSage.Domain.Entities.Medicine
{
    public class MedicineDetailsData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string Desc { get; set; }
        
        public string Category { get; set; }
        public Nullable<DateTime> AddedDate { get; set; }
    }
}