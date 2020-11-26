using System;
using ReviewPeliculas.Azure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReviewPeliculas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        // GET: api/<UsuarioController>
        [HttpGet ("all")]
        public JsonResult ObtenerUsuarios()
        {
            var usuariosRecibidos = UsuarioAzure.ObtenerUsuarios();
            return new JsonResult(usuariosRecibidos);

        }
    }
}
