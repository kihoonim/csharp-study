using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ValueObject
{
    public class UserId
    {
        private readonly string value;

        public UserId(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            this.value = value;
        }
    }
}
