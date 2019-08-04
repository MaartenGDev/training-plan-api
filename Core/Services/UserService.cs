using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataContext.Data;
using DataContext.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class UserService
    {
        private readonly TrainingPlanContext _context;

        public UserService(TrainingPlanContext context)
        {
            _context = context;
        }

        public Task<User> GetUserByIdAsync(int userId)
        {
            return _context.Users
                .SingleAsync(x => x.Id == userId);
        }
    }
}