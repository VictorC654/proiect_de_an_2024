using System;

namespace symptomSage.Domain.Entities.Medicine
{
    public class MedicineListData
    {
        public int Id { get; set; }
            
        public string Name { get; set; }
        
        public string Desc { get; set; }
        
        public string Category { get; set; }
        
        public string imagePath { get; set; }
            
        public Nullable<DateTime> AddedDate { get; set; }
    }
}