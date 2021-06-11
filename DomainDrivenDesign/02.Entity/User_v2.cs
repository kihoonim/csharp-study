using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Entity
{
    public class UserId
    {
        private string value;

        public UserId(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            this.value = value;
        }
    }

    public class User_v2
    {

        private string name;

        public User_v2(string name)
        {
            ChangeName(name);
        }

        public void ChangeName(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (name.Length < 3) throw new ArgumentException("", nameof(name));

            this.name = name;
        }
    }
}
