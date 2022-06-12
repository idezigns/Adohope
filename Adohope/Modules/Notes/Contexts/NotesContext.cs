using Adohope.Modules.Notes.EntitiesConfigurations;
using Adohope.Modules.Notes.Models;
using Microsoft.EntityFrameworkCore;

namespace Adohope.Modules.Notes.Contexts
{
    public class NotesContext : DbContext
    {
        public NotesContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NoteConfiguration());
        }
    }
}
