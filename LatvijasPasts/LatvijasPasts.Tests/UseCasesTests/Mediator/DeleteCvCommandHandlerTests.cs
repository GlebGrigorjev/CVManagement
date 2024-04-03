using FluentAssertions;
using LatvijasPasts.Services.IServices;
using LatvijasPasts.UseCases.DeleteCv;
using LatvijasPastsCore.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace LatvijasPasts.Tests.UseCasesTests.Mediator
{
    [TestClass]
    public class DeleteCvCommandHandlerTests
    {
        private Mock<ICvDataService> _mockCvDataService;

        [TestInitialize]
        public void Setup()
        {
            _mockCvDataService = new Mock<ICvDataService>();
        }

        [TestMethod]
        public async Task Handle_ValidRequest_ReturnsNoContentResult()
        {
            var cvDataToDelete = new CVData();
            _mockCvDataService.Setup(x => x.GetById(It.IsAny<int>())).Returns(cvDataToDelete);

            var handler = new DeleteCvCommandHandler(_mockCvDataService.Object);
            var request = new DeleteCvCommand(1);

            var result = await handler.Handle(request, CancellationToken.None) as NoContentResult;

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(204);
        }

        [TestMethod]
        public async Task Handle_CvDataNotFound_ReturnsNotFoundResult()
        {
            _mockCvDataService.Setup(x => x.GetById(It.IsAny<int>())).Returns((CVData)null);

            var handler = new DeleteCvCommandHandler(_mockCvDataService.Object);
            var request = new DeleteCvCommand(1);

            var result = await handler.Handle(request, CancellationToken.None) as NotFoundResult;

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(404);
        }

        [TestMethod]
        public async Task Handle_ExceptionThrown_ReturnsInternalServerError()
        {
            _mockCvDataService.Setup(x => x.GetById(It.IsAny<int>())).Throws(new Exception("Simulated exception"));

            var handler = new DeleteCvCommandHandler(_mockCvDataService.Object);
            var request = new DeleteCvCommand(1);

            var result = await handler.Handle(request, CancellationToken.None) as StatusCodeResult;

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(500);
        }
    }
}
