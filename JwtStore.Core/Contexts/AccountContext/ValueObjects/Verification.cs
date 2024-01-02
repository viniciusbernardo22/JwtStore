using JwtStore.Core.Contexts.SharedContext.ValueObjects;

namespace JwtStore.Core.Contexts.AccountContext.ValueObjects
{
    public class Verification : ValueObject
    {
        public string Code { get; } = Guid.NewGuid().ToString("N")[..6].ToUpper();

        public DateTime? ExpiresAt { get; private set; } = DateTime.UtcNow.AddHours(2);
        public DateTime? VerifiedAt { get; private set; } = null;

        public bool isActive => VerifiedAt != null && ExpiresAt == null;

        public void Verify(string code)
        {
            if (isActive)
                throw new Exception($"Item de id ${code} já foi ativado.");

            if (ExpiresAt < DateTime.UtcNow)
                throw new Exception("Este código já expirou");


            if (!string.Equals(a: code.Trim(), b: Code.Trim(), StringComparison.CurrentCultureIgnoreCase))
                throw new Exception("A verificação está invalida.");

            ExpiresAt = null;

            VerifiedAt = DateTime.UtcNow;

        }
    }
    }
