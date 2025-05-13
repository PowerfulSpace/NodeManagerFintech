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

        public async Task<TreeDto> CreateTreeAsync(CreateTreeRequest request)
        {
            var tree = new Tree(request.Name);
            await _treeRepository.AddAsync(tree);
            return tree.Adapt<TreeDto>();
        }

        public async Task<IEnumerable<TreeDto>> GetAllTreesAsync()
        {
            var trees = await _treeRepository.GetAllAsync();
            return trees.Adapt<IEnumerable<TreeDto>>();
        }

        public async Task<TreeDto?> GetTreeByIdAsync(Guid id)
        {
            var tree = await _treeRepository.GetByIdAsync(id, true);
            return tree?.Adapt<TreeDto>();
        }

        public async Task<bool> DeleteTreeAsync(Guid id)
        {
            var tree = await _treeRepository.GetByIdAsync(id);
            if (tree is null) return false;

            await _treeRepository.RemoveAsync(tree);
            return true;
        }
    }
}
