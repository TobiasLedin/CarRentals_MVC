namespace FribergCarRentals.Models
{
    public enum FuelType
    {
        petrol,
        diesel,
        CNG,
        hydrogen,
        electricity
    }

    public class Vehicle

    {
        public int VehicleId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public  FuelType FuelType { get; set; }
        public int Milage { get; set; }
        public double DailyRate { get; set; }
        public bool InService { get; set; }
        public bool Retired { get; set; }
    }
}
