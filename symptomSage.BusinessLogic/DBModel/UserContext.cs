using System.Data.Entity;
using symptomSage.Domain.Entities.User;

namespace symptomSage.BusinessLogic.DBModel
{
    public class UserContext : DbContext
    {
        // public void FixEfProviderServicesProblem()
        // {
        //     var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        // }
        public UserContext() : base("name=symptomSage") {}

        public virtual DbSet<UDbTable> Users { get; set; }
    }
}