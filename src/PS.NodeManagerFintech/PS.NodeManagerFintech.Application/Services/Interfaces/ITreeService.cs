using PS.NodeManagerFintech.Application.DTOs;

namespace PS.NodeManagerFintech.Application.Services.Interfaces
{
    public interface ITreeService
    {
        Task<TreeDto> CreateTreeAsync(CreateTreeRequest request);
        Task<IEnumerable<TreeDto>> GetAllTreesAsync();
        Task<TreeDto?> GetTreeByIdAsync(Guid id);
        Task<bool> DeleteTreeAsync(Guid id);
    }
}
