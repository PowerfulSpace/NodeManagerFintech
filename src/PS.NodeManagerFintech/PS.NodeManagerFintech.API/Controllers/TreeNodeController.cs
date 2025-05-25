using Microsoft.AspNetCore.Mvc;
using PS.NodeManagerFintech.Application.DTOs;
using PS.NodeManagerFintech.Application.Services.Interfaces;

namespace PS.NodeManagerFintech.API.Controllers
{
    [ApiController]
    [Route("api/nodes")]
    public class TreeNodeController : ControllerBase
    {
        private readonly ITreeNodeService _nodeService;

        public TreeNodeController(ITreeNodeService nodeService)
        {
            _nodeService = nodeService;
        }

        [HttpPost]
        public async Task<ActionResult<TreeNodeDto>> Create([FromBody] CreateTreeNodeRequest request, CancellationToken cancellationToken)
        {
            var node = await _nodeService.CreateNodeAsync(request, cancellationToken);
            return Ok(node);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _nodeService.DeleteNodeAsync(id, cancellationToken);
            return NoContent();
        }
    }
}
