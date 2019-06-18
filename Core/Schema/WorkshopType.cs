using System.Collections.Generic;
using System.Linq;
using Core.Services;
using DataContext.Models;
using DataContext.Models.Dto;
using GraphQL.Types;

namespace Core.Schema
{
    public class WorkshopType : ObjectGraphType<Workshop>
    {
        public WorkshopType(WorkshopService workshopService)
        {
            Field(o => o.Id);
            Field(o => o.Name);
            Field<ListGraphType<ExerciseType>, IEnumerable<Exercise>>()  
                .Name("exercises")
                .Resolve(ctx => workshopService.GetExercisesForWorkshopIdAsync(ctx.Source.Id)); 
        }
    }
}