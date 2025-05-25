using Microsoft.AspNetCore.Mvc;
using PS.NodeManagerFintech.Application.DTOs;
using PS.NodeManagerFintech.Application.Services.Interfaces;

namespace PS.NodeManagerFintech.API.Controllers
{
    [ApiController]
    [Route("api/trees")]
    public class TreeController : ControllerBase
    {
        private readonly ITreeService _treeService;

        public TreeController(ITreeService treeService)
        {
            _treeService = treeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TreeDto>>> GetAll(CancellationToken cancellationToken)
        {
            var trees = await _treeService.GetAllTreesAsync(cancellationToken);
            return Ok(trees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TreeDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var tree = await _treeService.GetTreeByIdAsync(id, cancellationToken);
            if (tree is null) return NotFound();
            return Ok(tree);
        }

        [HttpPost]
        public async Task<ActionResult<TreeDto>> Create([FromBody] CreateTreeRequest request, CancellationToken cancellationToken)
        {
            var createdTree = await _treeService.CreateTreeAsync(request, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = createdTree.Id }, createdTree);
        }
    }
}
