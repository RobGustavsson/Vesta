using System.Collections.Generic;

namespace Vesta.Server.Domain
{
    public class Email : ValueObject
    {
        public Email(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }

        public static implicit operator string(Email email)
        {
            return email.Value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value.ToLower();
        }
    }
}
