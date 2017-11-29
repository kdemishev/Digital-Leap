using System.Data.Entity;
using DigitalLeap.Repositories.EntityModel;

namespace DigitalLeap.Repositories
{
    public class DataContext : DbContext
    {
        static DataContext()
        {
            // this constructor is added to let EF assemplies be copied on site publishing:
            // more information here: https://social.msdn.microsoft.com/Forums/en-US/b348a0c2-94d9-4db5-a041-b81a97e76b3f/entityframeworksqlserver-not-deploying?forum=adodotnetentityframework
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public DataContext() : base("name=DataContext")
        {
            
        }

        public virtual DbSet<ContactInformation> Contacts { get; set; }

    }
}