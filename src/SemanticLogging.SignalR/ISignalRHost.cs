namespace SemanticLogging.SignalR
{
    public interface ISignalRHost
    {
        void ShutDown();
        void Start();
    }
}