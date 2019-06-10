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
    public class WorkshopService
    {
        private readonly TrainingPlanContext _context;

        public WorkshopService(TrainingPlanContext context)
        {
            _context = context;
        }

        public Task<List<Workshop>> GetWorkshopsAsync()
        {
            return _context.Workshops
                .Include(x => x.Exercises)
                .ThenInclude(x => x.Exercise)
                .ThenInclude(x => x.Category)
                .ToListAsync();
        }
    }
}