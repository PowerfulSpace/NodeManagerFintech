namespace PS.NodeManagerFintech.Application.DTOs
{
    public class TreeNodeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid TreeId { get; set; }

        public Guid? ParentId { get; set; }
        public List<TreeNodeDto> Children { get; set; } = new();
    }
}
