using AutoMapper;
using LatvijasPasts.Services.IServices;
using LatvijasPasts.UseCases.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LatvijasPasts.UseCases.GetCvById
{
    public class GetCvByIdCommandHandler : IRequestHandler<GetCvByIdCommand, IActionResult>
    {
        private readonly ICvDataService _cvDataService;
        private readonly IMapper _mapper;

        public GetCvByIdCommandHandler(ICvDataService cvDataService,
            IMapper mapper)
        {
            _cvDataService = cvDataService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Handle(GetCvByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var cvData = _cvDataService.GetById(request.Id);

                if (cvData == null)
                {
                    return new NotFoundResult();
                }

                return new OkObjectResult(_mapper.Map<CvViewModel>(cvData));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching CV data: {ex.Message}");
                return new StatusCodeResult(500);
            }
        }
    }
}
