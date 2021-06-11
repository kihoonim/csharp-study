using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.ValueObject
{
    public class Name
    {
        private readonly string value;

        public Name(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (!Regex.IsMatch(value, @"[a-zA-Z]+$")) throw new ArgumentException("Invalid Character", nameof(value));
            this.value = value;
        }
    }

    public class FullName_v3
    {
        private readonly Name firstName;
        private readonly Name lastName;

        public FullName_v3(Name firstName, Name lastName)
        {
            if (firstName == null) throw new ArgumentNullException(nameof(firstName));
            if (lastName == null) throw new ArgumentNullException(nameof(lastName));

            this.firstName = firstName;
            this.lastName = lastName;
        }
    }
}
