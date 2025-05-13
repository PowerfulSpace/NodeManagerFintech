using PS.NodeManagerFintech.Application.DTOs;

namespace PS.NodeManagerFintech.Application.Services.Interfaces
{
    public interface ITreeNodeService
    {
        Task<TreeNodeDto> CreateNodeAsync(CreateTreeNodeRequest request);
        Task<bool> DeleteNodeAsync(Guid nodeId);
    }
}
