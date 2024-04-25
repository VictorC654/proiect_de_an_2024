using System.Data.Entity;
using symptomSage.Domain.Entities.User;

namespace symptomSage.BusinessLogic.DBModel
{
    public class SessionContext : DbContext
    {
        public SessionContext() : base("name=symptomSage")
        {
        }

        public virtual DbSet<Session> Sessions { get; set; }
        
    }
}