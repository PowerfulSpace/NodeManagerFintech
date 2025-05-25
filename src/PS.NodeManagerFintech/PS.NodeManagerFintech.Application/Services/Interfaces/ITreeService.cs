using PS.NodeManagerFintech.Application.DTOs;

namespace PS.NodeManagerFintech.Application.Services.Interfaces
{
    public interface ITreeService
    {
        Task<TreeDto> CreateTreeAsync(CreateTreeRequest request, CancellationToken cancellationToken);
        Task<IEnumerable<TreeDto>> GetAllTreesAsync(CancellationToken cancellationToken);
        Task<TreeDto?> GetTreeByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<bool> DeleteTreeAsync(Guid id, CancellationToken cancellationToken);
    }
}
