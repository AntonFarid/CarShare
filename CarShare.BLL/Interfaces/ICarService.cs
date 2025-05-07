using CarShare.BLL.DTOs.Car;

namespace CarShare.BLL.Interfaces
{
    public interface ICarService
    {
        Task<CarResponseDTO> CreateAsync(CarCreateDTO carDTO, Guid ownerId);
        Task<IEnumerable<CarResponseDTO>> GetAllAvailableAsync();
        Task<CarResponseDTO> GetByIdAsync(Guid carId);
        Task ApproveCarAsync(Guid carId);
    }
}