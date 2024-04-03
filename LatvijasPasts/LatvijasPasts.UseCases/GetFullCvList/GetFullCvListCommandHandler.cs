using AutoMapper;
using LatvijasPasts.Services.IServices;
using LatvijasPasts.UseCases.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LatvijasPasts.UseCases.GetFullCvList
{
    public class GetFullCvListCommandHandler : IRequestHandler<GetFullCvListCommand, IActionResult>
    {
        private readonly ICvDataService _cvDataService;
        private readonly IMapper _mapper;

        public GetFullCvListCommandHandler(ICvDataService cvDataService,
            IMapper mapper)
        {
            _cvDataService = cvDataService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Handle(GetFullCvListCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var cvList = _cvDataService.GetAllCvData();

                if (cvList == null)
                {
                    return new NotFoundResult();
                }

                var cvViewModelList = _mapper.Map<List<CvViewModel>>(cvList);

                return new OkObjectResult(cvViewModelList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving CV data: {ex.Message}");
                return new StatusCodeResult(500);
            }
        }
    }
}
