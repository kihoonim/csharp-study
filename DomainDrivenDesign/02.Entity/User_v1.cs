using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Entity
{
    public class User_v1
    {
        private string name;

        public User_v1(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (name.Length < 3) throw new ArgumentException("", nameof(name));

            this.name = name;
        }
    }
}
