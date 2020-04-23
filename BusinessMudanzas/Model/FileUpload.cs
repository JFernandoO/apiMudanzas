using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiMudanzas.Models
{
    public class FileUpload
    {
        public string Name { get; set; }
        public IFormFile File { get; set; }
    }
}
