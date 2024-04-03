using AutoMapper;
using FluentValidation;
using LatvijasPasts.Services.IServices;
using LatvijasPasts.UseCases.Models;
using LatvijasPastsCore.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LatvijasPasts.UseCases.CreateCv
{
    public class CreateCvDataCommandHandler : IRequestHandler<CreateCvCommand, IActionResult>
    {
        private readonly IDbService _dbService;
        private readonly IMapper _mapper;
        private readonly IValidator<CvViewModel> _validator;

        public CreateCvDataCommandHandler(IDbService dbService,
            IMapper mapper,
            IValidator<CvViewModel> validator)
        {
            _dbService = dbService;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<IActionResult> Handle(CreateCvCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validatorResult = await _validator.ValidateAsync(request.newCvData, cancellationToken);

                if (!validatorResult.IsValid)
                {
                    return new BadRequestObjectResult(validatorResult.Errors[0].ErrorMessage);
                }

                var cvRequest = _mapper.Map<CVData>(request.newCvData);

                _dbService.Create(cvRequest);

                return new OkObjectResult(_mapper.Map<CVData>(request.newCvData));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving CV data: {ex.Message}");
                return new StatusCodeResult(500);
            }
        }
    }
}
