using GenericApp.Web.Data;
using GenericApp.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GenericApp.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IImageHelper _imageHelper;

        public EmpresasController(DataContext dataContext,IImageHelper imageHelper)
        {
            _dataContext = dataContext;
            _imageHelper = imageHelper;
        }

        [HttpGet("GetEmpresaByIdEmpresa/{idempresa}")]
        public async Task<ActionResult<Data.Entities.Empresa>> GetEmpresaByIdEmpresa(string codigo,int idempresa)
        {
            Data.Entities.Empresa empresa = await _dataContext.Aempresa
                .FirstOrDefaultAsync(o => (o.IDEmpresa == idempresa));

            if (empresa == null)
            {
                return NotFound();
            }
            return empresa;
        }
    }
}