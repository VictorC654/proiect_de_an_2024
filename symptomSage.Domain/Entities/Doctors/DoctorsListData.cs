﻿using System;

namespace symptomSage.Domain.Entities.Doctors
{
    public class DoctorsListData
    {
        public int Id { get; set; }
            
        public string Name { get; set; }
        
        public string Desc { get; set; }
        
        public string Category { get; set; }
    }
}