using System;

namespace CQRS.Core
{
    public interface IMessage : IEquatable<IMessage>, IComparable<IMessage>, IComparable
    {
        Guid Id { get; }

        Version Version { get; }
    }
}
