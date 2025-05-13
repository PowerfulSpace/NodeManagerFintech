namespace PS.NodeManagerFintech.Application.DTOs
{
    public class CreateTreeNodeRequest
    {
        public string Name { get; set; } = null!;
        public Guid TreeId { get; set; }
        public Guid? ParentId { get; set; }
    }
}
