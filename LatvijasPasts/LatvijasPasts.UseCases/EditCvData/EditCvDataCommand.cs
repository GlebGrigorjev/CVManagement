using LatvijasPasts.UseCases.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LatvijasPasts.UseCases.EditCvData
{
    public class EditCvDataCommand(int id, CvViewModel editedData) : IRequest<IActionResult>
    {
        public int Id { get; } = id;
        public CvViewModel EditedData { get; } = editedData;
    }
}
