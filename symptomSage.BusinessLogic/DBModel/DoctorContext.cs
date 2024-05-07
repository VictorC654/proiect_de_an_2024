using System.Data.Entity;
using symptomSage.Domain.Entities.Doctors;
using symptomSage.Domain.Entities.Medicine;

namespace symptomSage.BusinessLogic.DBModel
{
    public class DoctorContext : DbContext
    {
        public DoctorContext() : base("name=symptomSage")
        {
        }
        public virtual DbSet<DDbTable> Doctors { get; set; }
    }
}