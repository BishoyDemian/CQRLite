using System;

namespace CQRS.Core
{
    public interface ICommand
    {
        Guid Id { get; }

        Version Version { get; }
    }
}
