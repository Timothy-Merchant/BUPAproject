namespace MotApp.Models
{
    public class Vehicle
    {
        public string? registration { get; set; }
        public string? make { get; set; }
        public string? model { get; set; }
        public string? firstUsedDate { get; set; }
        public string? fuelType { get; set; }
        public string? primaryColour { get; set; }
        public List<MotTest>? motTests { get; set; }
    }

    public class MotTest
    {
        public DateTime completedDate { get; set; }
        public string? testResult { get; set; }
        public string? expiryDate { get; set; }
        public int odometerValue { get; set; }
        public string? odometerUnit { get; set; }
        public string? motTestNumber { get; set; }
        public List<RfrAndComments>? rfrAndComments { get; set; }

    }

    public class RfrAndComments
    {
        public string? text { get; set; }
        public string? type { get; set; }
    }
}
