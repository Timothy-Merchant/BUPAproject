namespace MotApp.Models
{
    public class VehicleDTO
    {
        public string? Make { get; set; }
        public string? Model { get; set; }
        public string? Colour { get; set; }
        public string? MOTexpiryDate { get; set; }
        public string? MileageAtLastMOT { get; set; }
        public bool notFound { get; set; }
    }
}
