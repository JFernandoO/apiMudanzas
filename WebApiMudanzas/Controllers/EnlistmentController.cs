using BusinessMudanzas;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using WebApiMudanzas.Models;

namespace WebApiMudanzas.Controllers
{
    /// <summary>
    /// Controlador principal
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EnlistmentController : ControllerBase
    {
        /// <summary>
        /// Logica de los calculos y movimientos
        /// </summary>
        private readonly ICalculateMovements _calculateMovements;
        
        /// <summary>
        /// Logia de manejo de archivos
        /// </summary>
        private readonly IFiles _files;
        
        /// <summary>
        /// Logica de listas
        /// </summary>
        private readonly IListItems _listItems;

        /// <summary>
        /// Logica de listas
        /// </summary>
        private readonly IRepository _db;

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
            if (fileUpload.File != null)
            {
                string nameUser = fileUpload.Name;
                var enlistmen = new ProcessBusiness();
                var resultText = enlistmen.GetProcess(fileUpload);
                return Content(resultText);
            }
            else
            {
                throw new Exception("Archivo no encontrado");
            }
        }
    }
}