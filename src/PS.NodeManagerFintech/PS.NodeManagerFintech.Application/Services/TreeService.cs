using Mapster;
using PS.NodeManagerFintech.Application.DTOs;
using PS.NodeManagerFintech.Application.Interfaces;
using PS.NodeManagerFintech.Application.Services.Interfaces;
using PS.NodeManagerFintech.Domain.Entities;

namespace PS.NodeManagerFintech.Application.Services
{
    public class TreeService : ITreeService
    {
        private readonly ITreeRepository _treeRepository;

        public TreeService(ITreeRepository treeRepository)
        {
            _treeRepository = treeRepository;
        }

        public async Task<TreeDto> CreateTreeAsync(CreateTreeRequest request, CancellationToken cancellationToken)
        {
            var tree = new Tree(request.Name);
            await _treeRepository.AddAsync(tree, cancellationToken);
            return tree.Adapt<TreeDto>();
        }

        public async Task<IEnumerable<TreeDto>> GetAllTreesAsync(CancellationToken cancellationToken)
        {
            var trees = await _treeRepository.GetAllAsync(cancellationToken);
            return trees.Adapt<IEnumerable<TreeDto>>();
        }

        public async Task<TreeDto?> GetTreeByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var tree = await _treeRepository.GetByIdAsync(id, cancellationToken, true);
            return tree?.Adapt<TreeDto>();
        }

        public async Task<bool> DeleteTreeAsync(Guid id, CancellationToken cancellationToken)
        {
            var tree = await _treeRepository.GetByIdAsync(id, cancellationToken);
            if (tree is null) return false;

            await _treeRepository.RemoveAsync(tree, cancellationToken);
            return true;
        }
    }
}
