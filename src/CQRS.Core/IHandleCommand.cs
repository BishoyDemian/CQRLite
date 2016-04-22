namespace CQRS.Core
{
    public interface IHandleCommand<in TCommand> where TCommand : class, ICommand
    {
        void Handle(TCommand command);
    }
}