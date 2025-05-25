using PS.NodeManagerFintech.Application.DTOs;

namespace PS.NodeManagerFintech.Application.Services.Interfaces
{
    public interface ITreeNodeService
    {
        Task<TreeNodeDto> CreateNodeAsync(CreateTreeNodeRequest request, CancellationToken cancellationToken);
        Task<bool> DeleteNodeAsync(Guid nodeId, CancellationToken cancellationToken);
    }
}
