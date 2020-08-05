using Microsoft.EntityFrameworkCore;
using TalentoIT.Data.Entities;

namespace TalentoIT.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<CandidatoEntity> Candidato { get; set;}

        public DbSet<EntrevistaEntity> Entrevista { get; set; }
        public DbSet<ReclutadorEntity> Reclutador { get; set; }
        public DbSet<TalentoIT.Data.Entities.TecnologiaEntity> TecnologiaEntity { get; set; }
    }
}
