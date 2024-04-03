using LatvijasPasts.UseCases.CreateCv;
using LatvijasPasts.UseCases.DeleteCv;
using LatvijasPasts.UseCases.EditCvData;
using LatvijasPasts.UseCases.GetCvById;
using LatvijasPasts.UseCases.GetFullCvList;
using LatvijasPasts.UseCases.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LatvijasPasts.Controllers
{
    [Route("api")]
    [ApiController]
    public class CVDataController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CVDataController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("get-list")]
        public async Task<IActionResult> GetCvList()
        {
            return await _mediator.Send(new GetFullCvListCommand());
        }

        [HttpPut]
        [Route("create-new")]
        public async Task<IActionResult> CreateCv(CvViewModel newCV)
        {
            return await _mediator.Send(new CreateCvCommand { newCvData = newCV });
        }

        [HttpGet]
        [Route("get-cv/{id}")]
        public async Task<IActionResult> GetCv(int id)
        {
            return await _mediator.Send(new GetCvByIdCommand(id));
        }

        [HttpPut("edit-cv/{id}")]
        public async Task<IActionResult> EditCvData(int id, CvViewModel editedData)
        {
            return await _mediator.Send(new EditCvDataCommand(id, editedData));
        }

        [HttpDelete("delete-cv/{id}")]
        public async Task<IActionResult> DeleteCv(int id)
        {
            return await _mediator.Send(new DeleteCvCommand(id));
        }
    }
}
