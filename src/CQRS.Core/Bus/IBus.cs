namespace CQRS.Core.Bus
{
    public interface IBus : ISendCommands, IPublishEvents, ISubmitQueries
    {
        
    }
}