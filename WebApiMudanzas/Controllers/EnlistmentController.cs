using BusinessMudanzas;
using Microsoft.AspNetCore.Mvc;
using WebApiMudanzas.Models;

namespace WebApiMudanzas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnlistmentController : ControllerBase
    {
        /// <summary>
        /// Prueba de la aplicacion
        /// </summary>
        /// <returns>Mensaje de exito</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("It's worked!");
        }

        /// <summary>
        /// Obtener la lista de viajes a partir de un archivo
        /// </summary>
        /// <param name="fileUpload">Archivo con los datos</param>
        /// <returns>Número de viajes por día</returns>
        [HttpPost]
        public IActionResult PostUpload([FromForm]FileUpload fileUpload)
        {
            var enlistmen = new EnlistmentBusiness();
            string nameUser = fileUpload.Name;
            var resultText = enlistmen.StartProcess(fileUpload.File);
            return Ok(new { status = true, message = resultText });
        }
    }
}