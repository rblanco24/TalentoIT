using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;
using System.Threading.Tasks;
using TalentoIT.Data.Entities;

namespace TalentoIT.Data
{
    public class SeedDb
    {
        private readonly DataContext _dataContext;

        public SeedDb(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckCandidatoAsync();
        }

        private async Task CheckCandidatoAsync()
        {
            if (_dataContext.Candidato.Any())
            {
                return;
            }
            _dataContext.Candidato.Add(new CandidatoEntity
            { 
             Nombre ="",
             Apellido ="",
             Correo ="",

            
            });
        }

        public void Rest()
        {
            
        }
    }
}
