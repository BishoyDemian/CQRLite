namespace CQRS.Core.Handlers
{
    public interface IHandleEvent<in TEvent> where TEvent : class, IEvent
    {
        void Handle(TEvent @event);
    }
}