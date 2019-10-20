using System.Collections.Generic;

namespace Vesta.Server.Domain
{
    public class FullName : ValueObject
    {
        public FullName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName.ToLower();
            yield return LastName.ToLower();
        }
    }
}
