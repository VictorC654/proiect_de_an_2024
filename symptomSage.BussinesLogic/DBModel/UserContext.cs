using System.Data.Entity;
using symptomSage.Domain.Entities.User;

namespace symptomSage.BussinesLogic.DBModel
{
    class UserContext : DbContext
    {
        public void FixEfProviderServicesProblem()
        {
            //The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer'
            //for the 'System.Data.SqlClient' ADO.NET provider could not be loaded. 
            //Make sure the provider assembly is available to the running application. 
            //See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.

            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public UserContext() : base("name=symptomSage") {}

        public virtual DbSet<UDbTable> Users { get; set; }
    }
}