using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataContext.Models
{
    public class Journey
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<JourneyWorkshop> Workshops { get; set; }
    }
}