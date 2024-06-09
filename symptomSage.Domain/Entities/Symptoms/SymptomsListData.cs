﻿using System;

namespace symptomSage.Domain.Entities.Symptoms
{
    public class SymptomsListData
    {
            public int Id { get; set; }
            
            public string Name { get; set; }
        
            public string Category { get; set; }
            
            public string imagePath { get; set; }
            
            public Nullable<DateTime> AddedDate { get; set; }
    }
}
