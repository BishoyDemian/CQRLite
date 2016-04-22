using System.Threading.Tasks;

namespace CQRS.Core.Bus
{
    public interface ISendCommands
    {
        void Send(ICommand command);

        Task SendAsync(ICommand command);
    }
}