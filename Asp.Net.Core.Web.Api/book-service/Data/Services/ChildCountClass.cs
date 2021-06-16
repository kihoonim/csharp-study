using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_service.Data.Services
{
    public class ChildCountService
    {
        private CountService _countService;

        public ChildCountService(CountService countService)
        {
            _countService = countService;
        }

        public int Get()
        {
            return _countService.Get();
        }
    }
}
