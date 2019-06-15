using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataContext.Data;
using DataContext.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class ExerciseService
    {
        private readonly TrainingPlanContext _context;

        public ExerciseService(TrainingPlanContext context)
        {
            _context = context;
        }

        public Task<Exercise> GetExerciseByIdAsync(int id)
        {
            return _context.Exercises
                .Include(e => e.Category)
                .Include(e => e.Workouts)
                .ThenInclude(e => e.Workout)
                .Include(e => e.Workshops)
                .ThenInclude(e => e.Workshop)
                .SingleAsync(x => x.Id == id);
        }

        public Task<List<Exercise>> GetExercisesAsync()
        {
            return _context.Exercises
                .Include(e => e.Category)
                .Include(e => e.Workouts)
                .ThenInclude(x => x.Workout)
                .Include(e => e.Workshops)
                .ThenInclude(e => e.Workshop)
                .ToListAsync();
        }

        public Task<Exercise> CreateAsync(Exercise exercise)
        {
            _context.Exercises.Add(exercise);
            _context.SaveChangesAsync();

            return Task.FromResult(exercise);
        }
    }
}