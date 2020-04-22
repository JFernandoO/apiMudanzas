using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiMudanzas.Models;

namespace WebApiMudanzas.Controllers
{
    public interface IEnlistmentController
    {
        IActionResult PostUpload([FromForm]FileUpload fileUpload);
    }
}
