using System.Data.Entity;
using symptomSage.Domain.Entities.Medicine;

namespace symptomSage.BusinessLogic.DBModel
{
    public class MedicineContext : DbContext
    {
            public MedicineContext() : base("name=symptomSage")
            {
            }
            public virtual DbSet<MDbTable> Medicine { get; set; }
        
    }
}