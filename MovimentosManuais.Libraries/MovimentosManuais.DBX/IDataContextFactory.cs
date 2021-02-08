namespace MovimentosManuais.Libraries
{
    public interface IDataContextFactory
    {
        IDataContext CreateDataContext(string connectionString);
    }
}
