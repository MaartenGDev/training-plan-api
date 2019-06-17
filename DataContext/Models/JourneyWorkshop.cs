namespace DataContext.Models
{
    public class JourneyWorkshop
    {
        public int JourneyId { get; set; }
        public Journey Journey { get; set; }
        public int WorkshopId { get; set; }
        public Workshop Workshop { get; set; }
    }
}