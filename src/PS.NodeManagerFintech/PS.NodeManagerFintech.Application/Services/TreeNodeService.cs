using Mapster;
using PS.NodeManagerFintech.Application.DTOs;
using PS.NodeManagerFintech.Application.Interfaces;
using PS.NodeManagerFintech.Application.Services.Interfaces;
using PS.NodeManagerFintech.Domain.Entities;
using PS.NodeManagerFintech.Domain.Exceptions;

namespace PS.NodeManagerFintech.Application.Services
{
    public class TreeNodeService : ITreeNodeService
    {
        private readonly ITreeNodeRepository _nodeRepository;
        private readonly ITreeRepository _treeRepository;

        public TreeNodeService(ITreeNodeRepository nodeRepository, ITreeRepository treeRepository)
        {
            _nodeRepository = nodeRepository;
            _treeRepository = treeRepository;
        }

        public async Task<TreeNodeDto> CreateNodeAsync(CreateTreeNodeRequest request, CancellationToken cancellationToken)
        {
            var tree = await _treeRepository.GetByIdAsync(request.TreeId, cancellationToken, true);
            if (tree is null) throw new SecureException("Tree not found");

            var node = new TreeNode(request.Name, request.TreeId, request.ParentId);
            await _nodeRepository.AddAsync(node, cancellationToken);

            return node.Adapt<TreeNodeDto>();
        }

        public async Task<bool> DeleteNodeAsync(Guid nodeId, CancellationToken cancellationToken)
        {
            var node = await _nodeRepository.GetByIdAsync(nodeId, cancellationToken);
            if (node is null) return false;

            if (node.Children.Any())
                throw new SecureException("You have to delete all children nodes first");

            _nodeRepository.Remove(node);
            return true;
        }
    }
}
