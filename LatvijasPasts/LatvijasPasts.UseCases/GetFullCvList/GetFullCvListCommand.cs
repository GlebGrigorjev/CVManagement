using LatvijasPastsCore.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LatvijasPasts.UseCases.GetFullCvList
{
    public class GetFullCvListCommand : IRequest<IActionResult>
    {
        public CVData CVData { get; set; }
    }
}
