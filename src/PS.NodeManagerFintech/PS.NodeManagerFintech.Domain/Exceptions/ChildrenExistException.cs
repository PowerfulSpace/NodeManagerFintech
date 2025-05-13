namespace PS.NodeManagerFintech.Domain.Exceptions
{
    public class ChildrenExistException : SecureException
    {
        public ChildrenExistException()
            : base("You have to delete all children nodes first")
        {
        }
    }
}
