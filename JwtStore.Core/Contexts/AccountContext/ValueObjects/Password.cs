using JwtStore.Core.Contexts.SharedContext.ValueObjects;

namespace JwtStore.Core.Contexts.AccountContext.ValueObjects
{
    public class Password : ValueObject
    {
        //normal chars valid to form a password
        private const string Valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        //special chars valid to form a password
        private const string Special = "!@#$%ˆ&*(){}[];Ç";

        public string Hash { get; } = string.Empty;
        public string ResetCode { get; } = Guid.NewGuid().ToString("N")[..8].ToLower();

    }
}
 