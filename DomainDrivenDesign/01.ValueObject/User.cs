using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ValueObject
{
    public class User
    {
        public UserId Id { get; set; }
        public UserName Name { get; set; }

        public static User CreateUser(UserName name)
        {
            var user = new User();
            //user.Id = name;
            return user;
        }
    }
}
