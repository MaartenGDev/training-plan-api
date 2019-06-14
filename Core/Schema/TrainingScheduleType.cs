using System.Collections.Generic;
using System.Linq;
using Core.Services;
using DataContext.Models;
using GraphQL.Types;

namespace Core.Schema
{
    public class TrainingScheduleType : ObjectGraphType<TrainingSchedule>
    {
        public TrainingScheduleType(TrainingScheduleService trainingScheduleService, UserService userService)
        {
            Field(o => o.Id);
            Field(o => o.Name);
            
            Field<ListGraphType<TrainingScheduleExerciseType>, IEnumerable<Exercise>>()  
                .Name("exercises")
                .Resolve(ctx => trainingScheduleService.GetExercisesForTrainingScheduleByIdAsync(ctx.Source.Id)); 
            Field<UserType>("user",
                resolve: context => userService.GetUserByIdAsync(context.Source.UserId));
        }
    }
}