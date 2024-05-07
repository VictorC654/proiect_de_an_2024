using System.Data.Entity;
using symptomSage.Domain.Entities.User;

namespace symptomSage.BusinessLogic.DBModel
{
    public class UserContext : DbContext
    {
        public UserContext() : base("name=symptomSage") {}

        public virtual DbSet<UDbTable> Users { get; set; }
    }
}