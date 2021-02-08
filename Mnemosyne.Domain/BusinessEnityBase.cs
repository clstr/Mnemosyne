using System;

namespace Mnemosyne.Domain
{
    [Serializable]
    public abstract class Entity<TId> : IEntity<TId>
    {
        public TId Id { get; protected internal set; }
    }
}
