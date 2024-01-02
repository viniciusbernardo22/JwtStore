using JwtStore.Core.Contexts.SharedContext.Extensions;
using JwtStore.Core.Contexts.SharedContext.ValueObjects;
using System.Text.RegularExpressions;

namespace JwtStore.Core.Contexts.AccountContext.ValueObjects
{
    public partial class Email : ValueObject
    {
        private const string Pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

        public Email(string address)
        {
            if(string.IsNullOrEmpty(address)) 
                throw new Exception("E-mail Invalido");

            Address = address.Trim().ToLower();

            if (address.Length < 5)
                throw new Exception($"E-mail tem {Address.Length} caracteres, mas necessita ter pelo menos 5.");

            if (!EmailRegex().IsMatch(address))
                throw new Exception($"Padrão de Regex do e-mail não é compativel com o utilizado, tente novamente.");
        }

        public  string Address { get; set; }

        public string Hash => Address.ToBase64();



        public static implicit operator string(Email email) => email.ToString();

        public static implicit operator Email(string address) => new (address);


        public override string ToString() => Address;

        [GeneratedRegex(Pattern)]
        private static partial Regex EmailRegex();
    }
}
