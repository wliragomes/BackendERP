using Microsoft.AspNetCore.Mvc;
using SharedKernel.Controllers;
using Swashbuckle.AspNetCore.Annotations;
using Application.Interfaces.NFes;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NFeController : PrincipalController
    {
        private readonly INFeService _nfeService;

        public NFeController(INFeService NFeService)
        {
            _nfeService = NFeService;
        }

        [SwaggerOperation(Summary = "Emitir NFe")]
        //[CustomAuthorize(NFeAccessControl.Create)]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Guid idFatura, CancellationToken cancellationToken)
        {
            var responseService = await _nfeService.EmitirNFe(idFatura, cancellationToken);
            return CustomResponse(responseService);
        }
    }
}
