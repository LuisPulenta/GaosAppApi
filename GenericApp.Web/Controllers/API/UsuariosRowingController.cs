using GenericApp.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GenericApp.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosRowingController : ControllerBase
    {
        private readonly DataContextRowing _dataContext;

        public UsuariosRowingController(DataContextRowing dataContext)
        {
            _dataContext = dataContext;
        }
    
        [HttpGet]
        [Route("GetUsuariosRowing")]
        public async Task<IActionResult> GetUsuariosRowing()
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