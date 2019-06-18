using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Schema;
using DataContext.Data;
using DataContext.Models;
using DataContext.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class JourneyService
    {
        private readonly TrainingPlanContext _context;

        public JourneyService(TrainingPlanContext context)
        {
            _context = context;
        }

        public Task<List<Journey>> GetJourneysAsync()
        {
            return _context.Journeys
                .Include(x => x.Workshops)
                .ThenInclude(x => x.Workshop)
                .ThenInclude(x => x.Exercises)
                .ThenInclude(x => x.Exercise)
                .ToListAsync();
        }
        
        public Task<Journey> GetJourneyByIdAsync(int id)
        {
            return _context.Journeys
                .Include(x => x.Workshops)
                .ThenInclude(x => x.Workshop)
                .ThenInclude(x => x.Exercises)
                .ThenInclude(x => x.Exercise)
                .SingleAsync(x => x.Id == id);
        }
    }
}