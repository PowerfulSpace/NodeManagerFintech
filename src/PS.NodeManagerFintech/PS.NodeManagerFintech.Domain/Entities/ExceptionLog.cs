namespace PS.NodeManagerFintech.Domain.Entities
{
    public class ExceptionLog
    {
        public Guid Id { get; private set; }
        public DateTime Timestamp { get; private set; }
        public string ExceptionType { get; private set; }
        public string RequestPath { get; private set; }
        public string QueryString { get; private set; }
        public string Body { get; private set; }
        public string StackTrace { get; private set; }

#pragma warning disable CS8618
        protected ExceptionLog() { }
#pragma warning restore CS8618

        public ExceptionLog(
            string exceptionType,
            string requestPath,
            string queryString,
            string body,
            string stackTrace)
        {
            Id = Guid.NewGuid();
            Timestamp = DateTime.UtcNow;
            ExceptionType = exceptionType ?? throw new ArgumentNullException(nameof(exceptionType));
            RequestPath = requestPath ?? throw new ArgumentNullException(nameof(requestPath));
            QueryString = queryString ?? string.Empty;
            Body = body ?? string.Empty;
            StackTrace = stackTrace ?? throw new ArgumentNullException(nameof(stackTrace));
        }
    }
}
