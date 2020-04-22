using BusinessMudanzas;
using Microsoft.AspNetCore.Mvc;
using WebApiMudanzas.Models;

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

        [HttpPost]
        public ActionResult PostUpload([FromForm]FileUpload fileUpload)
        {
            var enlistmen = new EnlistmentBusiness();
            string nameUser = fileUpload.Name;
            var resultText = enlistmen.StartProcess(fileUpload.File);
            return Ok(new { status = true, message = resultText });
        }
    }
}