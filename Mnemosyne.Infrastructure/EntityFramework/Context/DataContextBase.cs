using Microsoft.EntityFrameworkCore;
using Mnemosyne.Infrastructure.EntityFramework.Mappings;
using Mnemosyne.Infrastructure.Interfaces.Context;
using System.Linq;
using System.Threading.Tasks;

namespace Mnemosyne.Infrastructure.EntityFramework.Context
{
    public abstract class DataContextBase<TContext> : DbContext, IDataContext where TContext : DbContext
    {
        public DataContextBase(DbContextOptions<TContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var type = typeof(IEntityMap<>);
            var nameSpace = "CommunicationPortal.Infrastructure.EF.Mappings.PortalContext";

            var classes = assembly.GetTypes().Where(p =>
                p.Namespace == nameSpace
            ).ToList();

            base.OnModelCreating(modelBuilder);
        }

        public int Commit() => this.SaveChanges();
        public Task<int> CommitAsync() => this.SaveChangesAsync();
    }
}