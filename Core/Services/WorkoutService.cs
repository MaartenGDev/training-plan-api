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
    public class WorkoutService
    {
        private readonly TrainingPlanContext _context;

        public WorkoutService(TrainingPlanContext context)
        {
            _context = context;
        }

        public Task<List<Workout>> GetWorkoutsAsync()
        {
            return _context.Workouts
                .Include(x => x.Exercises)
                .ThenInclude(x => x.Exercise)
                .ThenInclude(x => x.Category)
                .ToListAsync();
        }
    }
}