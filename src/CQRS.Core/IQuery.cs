namespace CQRS.Core
{
    public interface IQuery<in TAggregate, out TResult> : IMessage
    {
    }
}