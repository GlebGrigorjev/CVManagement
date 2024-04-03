using LatvijasPasts.Services.IServices;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LatvijasPasts.UseCases.DeleteCv
{
    public class DeleteCvCommandHandler : IRequestHandler<DeleteCvCommand, IActionResult>
    {
        private readonly ICvDataService _cvService;

        public DeleteCvCommandHandler(ICvDataService cvService)
        {
            _cvService = cvService;
        }

        public async Task<IActionResult> Handle(DeleteCvCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var flightToDelete = _cvService.GetById(request.Id);

                if (flightToDelete == null)
                {
                    return new NotFoundResult();
                }

                _cvService.Delete(flightToDelete);
                _cvService.Save();

                return new NoContentResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting CV data: {ex.Message}");
                return new StatusCodeResult(500);
            }
        }
    }
}
