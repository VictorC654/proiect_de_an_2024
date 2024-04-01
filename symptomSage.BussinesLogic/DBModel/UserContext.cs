using System.Data.Entity;

namespace symptomSage.BussinesLogic.DBModel
{
    public class UserContext : DbContext
    {
        public UserContext() : base("name=symptomSage")

        {
            //
        }
        // public virtual DbSet<UDbTable> Users { get; set; }
    }
}