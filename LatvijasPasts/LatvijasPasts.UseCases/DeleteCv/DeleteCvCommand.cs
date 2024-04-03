using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LatvijasPasts.UseCases.DeleteCv
{
    public class DeleteCvCommand(int id) : IRequest<IActionResult>
    {
        public int Id { get; } = id;
    }
}
