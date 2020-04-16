using Microsoft.EntityFrameworkCore;
using Mnemosyne.Domain.Entities;
using Mnemosyne.Infrastructure.EntityFramework.Mappings.NotesContext;
using Mnemosyne.Infrastructure.Interfaces.Context;
using Mnemosyne.Infrastructure.Interfaces.Context.Notes;

namespace Mnemosyne.Infrastructure.EntityFramework.Context
{
    public class NotesDbContext : DataContextBase<NotesDbContext>, INotesDataContext
    {
        public IRepositoryBase<Roles, int> Roles { get; }

        public NotesDbContext(DbContextOptions<NotesDbContext> options) : base(options)
        {
            Roles = new RepositoryBase<Roles, int>(this);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RolesMap());
        }
    }
}