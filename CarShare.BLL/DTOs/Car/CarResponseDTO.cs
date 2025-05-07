namespace CarShare.BLL.DTOs.Car
{
    public class CarResponseDTO
    {
        public Guid CarId { get; set; }
        public string Title { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal PricePerDay { get; set; }
        public string Location { get; set; }
        public string OwnerName { get; set; }
        public List<string> ImageUrls { get; set; } = new();
    }
}