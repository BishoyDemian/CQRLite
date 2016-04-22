using System.Threading.Tasks;

namespace CQRS.Core.Bus
{
    public interface ISubmitQueries
    {
        TResult Query<TAggregate, TResult>(IQuery<TAggregate, TResult> query);

        Task<TResult> QueryAsync<TAggregate, TResult>(IQuery<TAggregate, TResult> query);
    }
}