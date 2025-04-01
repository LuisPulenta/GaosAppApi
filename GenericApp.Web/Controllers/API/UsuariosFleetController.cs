using GenericApp.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GenericApp.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosFleetController : ControllerBase
    {
        private readonly DataContextFleet _dataContext;

        public UsuariosFleetController(DataContextFleet dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        [Route("GetUsuariosFleet")]
        public async Task<IActionResult> GetUsuariosFleet()
        {
            var usuarios = await _dataContext.Usuarios
           .OrderBy(o => o.Apellido)
           .ToListAsync();
            if (usuarios == null)
            {
                return BadRequest("No hay Usuarios.");
            }
            return Ok(usuarios);
        }
    }
}