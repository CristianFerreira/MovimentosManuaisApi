namespace MovimentosManuais.Libraries
{
    public interface IDataContext
    {
        string ConnectionString { get; }

        IConnectionContext AcquireConnection();
    }
}
