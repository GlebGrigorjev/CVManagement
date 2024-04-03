using AutoMapper;
using FluentValidation;
using LatvijasPasts.Services.IServices;
using LatvijasPasts.UseCases.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LatvijasPasts.UseCases.EditCvData
{
    public class EditCvDataCommandHandler : IRequestHandler<EditCvDataCommand, IActionResult>
    {
        private readonly ICvDataService _cvDataService;
        private readonly IMapper _mapper;
        private readonly IValidator<CvViewModel> _validator;

        public EditCvDataCommandHandler(ICvDataService cvDataService,
            IMapper mapper,
            IValidator<CvViewModel> validator)
        {
            _cvDataService = cvDataService;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<IActionResult> Handle(EditCvDataCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validatorResult = await _validator.ValidateAsync(request.EditedData, cancellationToken);
                var dataToEdit = _cvDataService.GetById(request.Id);

                if (dataToEdit == null) { return new NotFoundResult(); }

                if (!validatorResult.IsValid) { return new BadRequestObjectResult(validatorResult.Errors[0].ErrorMessage); }

                _mapper.Map(request.EditedData, dataToEdit);
                _cvDataService.Save();

                var resultingData = _cvDataService.GetById(request.Id);

                return new OkObjectResult(resultingData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while trying to edit CV data: {ex.Message}");
                return new StatusCodeResult(500);
            }
        }

    }
}
