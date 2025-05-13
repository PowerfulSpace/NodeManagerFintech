namespace PS.NodeManagerFintech.Domain.Entities
{
    public class Tree
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string? Name { get; private set; }

        private readonly List<TreeNode> _nodes = new();
        public IReadOnlyCollection<TreeNode> Nodes => _nodes.AsReadOnly();

        protected Tree() { }
        public Tree(string? name = null)
        {
            Name = name;
        }

        public void AddNode(TreeNode node)
        {
            if (node.TreeId != Id)
                throw new InvalidOperationException("Node belongs to another tree.");

            _nodes.Add(node);
        }

        public bool TryRemoveNode(TreeNode node)
        {
            if (node.Children.Any()) return false;
            _nodes.Remove(node);
            return true;
        }
    }
}
