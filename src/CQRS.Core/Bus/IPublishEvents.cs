using System.Threading.Tasks;

namespace CQRS.Core.Bus
{
    public interface IPublishEvents
    {
        void Publish(IEvent @event);

        Task PublishAsync(IEvent @event);
    }
}
