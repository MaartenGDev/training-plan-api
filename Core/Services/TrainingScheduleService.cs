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
        
        public IEnumerable<TrainingScheduleExerciseDto> GetExercisesForTrainingScheduleByIdAsync(int trainingScheduleId)
        {
            return _context.TrainingSchedules
                .Include(x => x.TrainingScheduleExercises)
                .ThenInclude(x => x.Exercise)
                .ThenInclude(e => e.Category)
                .Single(e => e.Id == trainingScheduleId)
                .TrainingScheduleExercises.Select(x => new TrainingScheduleExerciseDto(x))
                .ToList();
        }
        
       

        public Task<TrainingSchedule> CreateAsync(TrainingSchedule trainingSchedule)
        {
            _context.TrainingSchedules.Add(trainingSchedule);
            _context.SaveChanges();

            return Task.FromResult(trainingSchedule);
        }
    }
}