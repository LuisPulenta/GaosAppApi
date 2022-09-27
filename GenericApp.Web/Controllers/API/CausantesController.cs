using GenericApp.Common.Requests;
using GenericApp.Common.Responses;
using GenericApp.Web.Data;
using GenericApp.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GenericApp.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CausantesController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IImageHelper _imageHelper;

        public CausantesController(DataContext dataContext,IImageHelper imageHelper)
        {
            _dataContext = dataContext;
            _imageHelper = imageHelper;
        }

        

        // GET: api/Users/5
        [HttpGet("GetCausanteByCodigo/{codigo}/{idempresa}")]
        public async Task<ActionResult<Data.Entities.Causante>> GetCausante2(string codigo,int idempresa)
        {
            Data.Entities.Causante causante = await _dataContext.Causantes
                .FirstOrDefaultAsync(o => (o.codigo.ToLower() == codigo.ToLower()) && (o.IdEmpresa == idempresa));

            if (causante == null)
            {
                return NotFound();
            }
            return causante;
        }

       


        [HttpPost]
        [Route("GetCausantesByGrupo/{Grupo}")]
        public IActionResult GetCausantesByProyectoModulo(string Grupo)
        {
            return Ok(_dataContext.Causantes
                .Where(o => o.grupo == Grupo && o.estado==true)
                .OrderBy(o => o.nombre)
                );
        }

    }
}