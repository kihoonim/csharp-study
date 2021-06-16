using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_service.Data.Services
{
    public class CountService
    {
        private int _value = 0;

        public int Get()
        {
            return _value;
        }

        public int Increase(int value = 1)
        {
            return _value += value;
        }
    }
}
