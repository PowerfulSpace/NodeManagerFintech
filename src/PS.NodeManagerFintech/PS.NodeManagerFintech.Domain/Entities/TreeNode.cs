namespace PS.NodeManagerFintech.Domain.Entities
{
    public class TreeNode
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }

        public Guid TreeId { get; private set; }
        public Tree Tree { get; private set; } = null!;

        public Guid? ParentId { get; private set; }
        public TreeNode? Parent { get; private set; }

        private readonly List<TreeNode> _children = new();
        public IReadOnlyCollection<TreeNode> Children => _children.AsReadOnly();

#pragma warning disable CS8618
        protected TreeNode() { }
#pragma warning restore CS8618

        public TreeNode(string name, Guid treeId, Guid? parentId = null)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            TreeId = treeId;
            ParentId = parentId;
        }

        public void AddChild(TreeNode child)
        {
            if (child.TreeId != TreeId)
                throw new InvalidOperationException("Child node must belong to the same tree.");

            _children.Add(child);
        }

    }
}
