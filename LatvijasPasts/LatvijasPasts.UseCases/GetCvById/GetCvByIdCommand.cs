using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LatvijasPasts.UseCases.GetCvById
{
    public class GetCvByIdCommand(int id) : IRequest<IActionResult>
    {
        public int Id { get; set; } = id;
    }
}
