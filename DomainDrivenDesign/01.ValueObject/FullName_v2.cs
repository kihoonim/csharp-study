using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.ValueObject
{
    public class FirstName
    {
        private readonly string value;

        public FirstName(string value)
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentException("value Cannot Null or Empty", nameof(value));
            this.value = value;
        }
    }

    public class LastName
    {
        private readonly string value;

        public LastName(string value)
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentException("value Cannot Null or Empty", nameof(value));
            this.value = value;
        }
    }

    public class FullName_v2 : IEquatable<FullName_v2>
    {
        private readonly FirstName firstName;
        private readonly LastName lastName;

        public FullName_v2(string firstName, string lastName)
        {
            if (firstName == null) throw new ArgumentNullException(nameof(firstName));
            if (lastName == null) throw new ArgumentNullException(nameof(lastName));
            if (!ValidateName(firstName)) throw new ArgumentException("Invalid Character", nameof(firstName));
            if (!ValidateName(lastName)) throw new ArgumentException("Invalid Character", nameof(lastName));

            this.firstName = new FirstName(firstName);
            this.lastName = new LastName(lastName);
        }

        public bool Equals(FullName_v2 other)
        {
            throw new NotImplementedException();
        }

        private bool ValidateName(string value)
        {
            return Regex.IsMatch(value, @"^[a-zA-Z]+$");
        }

    }
}
