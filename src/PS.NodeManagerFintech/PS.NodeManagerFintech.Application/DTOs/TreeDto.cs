namespace PS.NodeManagerFintech.Application.DTOs
{
    public class TreeDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public List<TreeNodeDto> Nodes { get; set; } = new();
    }
}
