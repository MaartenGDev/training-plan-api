using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataContext.Data;
using DataContext.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class TrainingScheduleService
    {
        private readonly TrainingPlanContext _context;

        public TrainingScheduleService(TrainingPlanContext context)
        {
            _context = context;
        }

        public Task<List<TrainingSchedule>> GetTrainingSchedulesAsync()
        {
            return _context.TrainingSchedules
                .Include(x => x.TrainingScheduleExercises)
                .ThenInclude(x => x.Exercise)
                .ToListAsync();
        }
        
        public IEnumerable<Exercise> GetExercisesForTrainingScheduleByIdAsync(int trainingScheduleId)
        {
            return _context.TrainingSchedules
                .Include(x => x.TrainingScheduleExercises)
                .ThenInclude(x => x.Exercise)
                .Single(e => e.Id == trainingScheduleId)
                .TrainingScheduleExercises.Select(x => x.Exercise)
                .ToList();
        }
        
       

        public Task<TrainingSchedule> CreateAsync(TrainingSchedule trainingSchedule)
        {
            _context.TrainingSchedules.Add(trainingSchedule);
            _context.SaveChangesAsync();

            return Task.FromResult(trainingSchedule);
        }
    }
}