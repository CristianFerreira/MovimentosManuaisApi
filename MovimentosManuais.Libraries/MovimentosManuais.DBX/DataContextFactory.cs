namespace MovimentosManuais.Libraries
{
    public class DataContextFactory : IDataContextFactory
    {
        public IDataContext CreateDataContext(string connectionString)
        {
            return new DefaultDataContext(connectionString);
        }
    }
}
