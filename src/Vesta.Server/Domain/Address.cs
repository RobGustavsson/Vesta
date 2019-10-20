using System.Collections.Generic;

namespace Vesta.Server.Domain
{
    public class Address : ValueObject
    {
        public Address(string street, string town, string zipCode)
        {
            Street = street;
            Town = town;
            ZipCode = zipCode;
        }

        public string Street { get; private set; }
        public string Town { get; private set; }
        public string ZipCode { get; private set; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street.ToLower();
            yield return Town.ToLower();
            yield return ZipCode.ToLower();
        }
    }
}
