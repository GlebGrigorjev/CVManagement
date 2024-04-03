using LatvijasPasts.UseCases.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LatvijasPasts.UseCases.CreateCv
{
    public class CreateCvCommand : IRequest<IActionResult>
    {
        public CvViewModel newCvData { get; set; }
    }
}
