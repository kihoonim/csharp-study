using book_service.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountController : ControllerBase
    {
        private CountService _countService;
        private ChildCountService _childCountService;

        public CountController(CountService countService, ChildCountService childCountService)
        {
            _countService = countService;
            _childCountService = childCountService;
        }

        [HttpGet("get-count-1")]
        public IActionResult GetCount1()
        {
            return Ok(_countService.Increase());
        }

        [HttpGet("get-count-2")]
        public IActionResult GetCount2()
        {
            return Ok(_countService.Increase());
        }

        [HttpGet("get-child-count-1")]
        public IActionResult GetChildCount1()
        {
            _countService.Increase();

            return Ok(_childCountService.Get());
        }

        [HttpGet("get-child-count-2")]
        public IActionResult GetChildCount2()
        {
            _countService.Increase();

            return Ok(_childCountService.Get());
        }
    }
}
