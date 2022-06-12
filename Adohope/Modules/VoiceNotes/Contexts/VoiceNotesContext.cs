using Adohope.Modules.VoiceNotes.EntitiesConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Adohope.Modules.VoiceNotes.Contexts
{
    public class VoiceNotesContext : DbContext
    {
        public VoiceNotesContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RecordingConfiguration());
        }
    }
}
