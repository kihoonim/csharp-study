using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ValueObject
{
    public class UserName
    {
        private readonly string value;

        public UserName(string value) 
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (value.Length < 3) throw new ArgumentException("User Length Must Bigger Than 3.", nameof(value));

            this.value = value; 
        }
    }
}
