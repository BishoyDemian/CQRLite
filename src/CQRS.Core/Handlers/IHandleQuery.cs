namespace CQRS.Core.Handlers
{
    public interface IHandleQuery<in TQuery, in TAggregate, out TResult> where TQuery: class, IQuery<TAggregate, TResult>
    {
        TResult Handle(TQuery query);
    }
}