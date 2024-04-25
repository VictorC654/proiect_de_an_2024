using System;

namespace symptomSage.Domain.Entities.Symptoms
{
    public class SymptomsDetailsData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string Desc { get; set; }
        
        public Nullable<DateTime> AddedDate { get; set; }
    }
    }
