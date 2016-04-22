namespace CQRS.Core.Handlers
{
    public interface IHandleCommand<in TCommand> where TCommand : class, ICommand
    {
        void Handle(TCommand command);
    }
}