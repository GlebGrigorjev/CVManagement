using FluentAssertions;
using LatvijasPasts.Controllers;
using LatvijasPasts.UseCases.CreateCv;
using LatvijasPasts.UseCases.DeleteCv;
using LatvijasPasts.UseCases.EditCvData;
using LatvijasPasts.UseCases.GetCvById;
using LatvijasPasts.UseCases.GetFullCvList;
using LatvijasPasts.UseCases.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace LatvijasPasts.Tests.ControllerTests
{
    [TestClass]
    public class CVDataControllerTests
    {
        private Mock<IMediator> _mediatorMock;
        private CVDataController _controller;

        [TestInitialize]
        public void Setup()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new CVDataController(_mediatorMock.Object);
        }

        [TestMethod]
        public async Task GetCvList_ReturnsOkObjectResult()
        {
            var expectedResponse = new List<CvViewModel>();
            _mediatorMock.Setup(x => x.Send(It.IsAny<GetFullCvListCommand>(), CancellationToken.None))
                .ReturnsAsync(new OkObjectResult(expectedResponse));

            var result = await _controller.GetCvList();

            result.Should().BeOfType<OkObjectResult>()
                .Which.Value.Should().BeEquivalentTo(expectedResponse);
        }

        [TestMethod]
        public async Task CreateCv_ReturnsOkObjectResult()
        {
            var newCv = new CvViewModel();
            var createdCv = new CvViewModel();
            _mediatorMock.Setup(x => x.Send(It.IsAny<CreateCvCommand>(), CancellationToken.None))
                .ReturnsAsync(new OkObjectResult(createdCv));

            var result = await _controller.CreateCv(newCv);

            result.Should().BeOfType<OkObjectResult>()
                .Which.Value.Should().BeEquivalentTo(createdCv);
        }

        [TestMethod]
        public async Task GetCv_ReturnsOkObjectResult()
        {
            var id = 1;
            var expectedCv = new CvViewModel();
            _mediatorMock.Setup(x => x.Send(It.IsAny<GetCvByIdCommand>(), CancellationToken.None))
                .ReturnsAsync(new OkObjectResult(expectedCv));

            var result = await _controller.GetCv(id);

            result.Should().BeOfType<OkObjectResult>()
                .Which.Value.Should().BeEquivalentTo(expectedCv);
        }

        [TestMethod]
        public async Task EditCvData_ReturnsOkObjectResult()
        {
            var id = 1;
            var editedData = new CvViewModel();
            var editedCv = new CvViewModel();
            _mediatorMock.Setup(x => x.Send(It.IsAny<EditCvDataCommand>(), CancellationToken.None))
                .ReturnsAsync(new OkObjectResult(editedCv));

            var result = await _controller.EditCvData(id, editedData);

            result.Should().BeOfType<OkObjectResult>()
                .Which.Value.Should().BeEquivalentTo(editedCv);
        }

        [TestMethod]
        public async Task DeleteCv_ReturnsNoContentResult()
        {
            var id = 1;
            _mediatorMock.Setup(x => x.Send(It.IsAny<DeleteCvCommand>(), CancellationToken.None))
                .ReturnsAsync(new NoContentResult());

            var result = await _controller.DeleteCv(id);

            result.Should().BeOfType<NoContentResult>();
        }
    }
}
