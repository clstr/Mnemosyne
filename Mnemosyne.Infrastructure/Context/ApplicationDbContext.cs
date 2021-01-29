using Microsoft.EntityFrameworkCore;
using Mnemosyne.Domain.Entities;
using Mnemosyne.Infrastructure.EF.Mappings.ApplicationContext;
using Mnemosyne.Infrastructure.EF.Mappings.NotesContext;
using Mnemosyne.Infrastructure.Interfaces.Context;

namespace Mnemosyne.Infrastructure.EF.Context
{
    public class ApplicationDbContext : DataContextBase<ApplicationDbContext>, IApplicationContext
    {
        public IRepositoryBase<Roles, int> Roles { get; }
        public IRepositoryBase<Users, int> Users { get; }
        public IRepositoryBase<Categories, int> Categories { get; }
        public IRepositoryBase<Games, int> Games { get; }
        public IRepositoryBase<Notes, int> Notes { get; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Roles = new RepositoryBase<Roles, int>(this);
            Users = new RepositoryBase<Users, int>(this);
            Categories = new RepositoryBase<Categories, int>(this);
            Games = new RepositoryBase<Games, int>(this);
            Notes= new RepositoryBase<Notes, int>(this);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RolesMap());
            modelBuilder.ApplyConfiguration(new UsersMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new GamesMap());
            modelBuilder.ApplyConfiguration(new NotesMap());
        }
    }
}
