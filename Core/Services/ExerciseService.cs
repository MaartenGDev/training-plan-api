using System.Collections.Generic;
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

        public Task<Exercise> GetExercisesByIdAsync(int id)
        {
            return _context.Exercises.SingleAsync(x => x.Id == id);
        }

        public Task<List<Exercise>> GetExercisesAsync()
        {
            return _context.Exercises.Include(e => e.Category).ToListAsync();
        }

        public Task<Exercise> CreateAsync(Exercise exercise)
        {
            _context.Exercises.Add(exercise);
            _context.SaveChangesAsync();

            return Task.FromResult(exercise);
        }
    }
}