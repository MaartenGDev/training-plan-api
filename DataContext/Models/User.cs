using System.ComponentModel.DataAnnotations;

namespace DataContext.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}