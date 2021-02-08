using MovimentosManuais.Core.Processors;

namespace MovimentosManuais.Core.Factories
{
    public interface IDateLaunchNumberFactory
    {
        IDateLaunchNumberProcessor CreateProcessor();
    }
}
