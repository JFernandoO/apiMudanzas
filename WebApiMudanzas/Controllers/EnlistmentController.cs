using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiMudanzas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnlistmentController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(true);
        }
    }
}