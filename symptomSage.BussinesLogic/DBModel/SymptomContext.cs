﻿using System.Data.Entity;
using symptomSage.Domain.Entities.Symptoms;

namespace symptomSage.BussinesLogic.DBModel
{
    public class SymptomContext  : DbContext
    {
        public SymptomContext() : base("name=symptomSage") {}


        public virtual DbSet<SDbTable> Symptoms { get; set; }
    }
}
