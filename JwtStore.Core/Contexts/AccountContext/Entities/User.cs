using JwtStore.Core.Contexts.AccountContext.ValueObjects;
using JwtStore.Core.Contexts.SharedContext.Entities;

namespace JwtStore.Core.Contexts.AccountContext.Entities
{
    public class User : Entity
    {
        public Email Email { get; private set; }

    }
}
