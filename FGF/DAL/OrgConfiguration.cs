using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace FGF.DAL
{
    public class OrgConfiguration : DbConfiguration
    {
        public OrgConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
        }
    }
}