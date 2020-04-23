using BusinessMudanzas.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace BusinessMudanzas
{
    public interface IFiles
    {
        string ReadAsString(IFormFile file);
    }
}
