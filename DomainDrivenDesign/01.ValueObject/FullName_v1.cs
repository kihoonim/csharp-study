using System;

namespace _01.ValueObject
{
    public class FullName_v1 : IEquatable<FullName_v1>
    {
        public string FirstName { get; }
        public string LastName { get; }

        public FullName_v1(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public bool Equals(FullName_v1 other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(FirstName, other.FirstName) 
                && string.Equals(LastName, other.LastName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((FullName_v1)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((FirstName != null ? FirstName.GetHashCode() : 0) * 397) 
                    ^ (LastName != null ? LastName.GetHashCode() : 0);
            }
        }
    }
}
