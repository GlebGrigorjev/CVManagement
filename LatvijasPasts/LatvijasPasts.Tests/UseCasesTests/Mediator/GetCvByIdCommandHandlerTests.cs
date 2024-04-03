using AutoMapper;
using FluentAssertions;
using LatvijasPasts.Services.IServices;
using LatvijasPasts.UseCases.GetCvById;
using LatvijasPasts.UseCases.Models;
using LatvijasPastsCore.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace LatvijasPasts.Tests.UseCasesTests.Mediator
{
    [TestClass]
    public class GetCvByIdCommandHandlerTests
    {
        private Mock<ICvDataService> _mockCvDataService;
        private Mock<IMapper> _mapperMock;

        [TestInitialize]
        public void Setup()
        {
            _mockCvDataService = new Mock<ICvDataService>();
            _mapperMock = new Mock<IMapper>();
        }

        [TestMethod]
        public async Task Handle_CvDataExists_ReturnsOkObjectResultWithCvViewModel()
        {
            var cvData = new CVData { Id = 1 };
            var cvViewModel = new CvViewModel { Id = 1 };

            _mockCvDataService.Setup(x => x.GetById(It.IsAny<int>())).Returns(cvData);
            _mapperMock.Setup(x => x.Map<CvViewModel>(cvData)).Returns(cvViewModel);

            var handler = new GetCvByIdCommandHandler(
                _mockCvDataService.Object,
                _mapperMock.Object);

            var request = new GetCvByIdCommand(1);

            var result = await handler.Handle(request, CancellationToken.None) as OkObjectResult;

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
            result.Value.Should().BeOfType<CvViewModel>();
            result.Value.Should().BeEquivalentTo(cvViewModel);
        }

        [TestMethod]
        public async Task Handle_CvDataNotFound_ReturnsNotFoundResult()
        {
            _mockCvDataService.Setup(x => x.GetById(It.IsAny<int>())).Returns((CVData)null);

            var handler = new GetCvByIdCommandHandler(
                _mockCvDataService.Object,
                _mapperMock.Object);

            var request = new GetCvByIdCommand(1);

            var result = await handler.Handle(request, CancellationToken.None) as NotFoundResult;

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(404);
        }

        [TestMethod]
        public async Task Handle_ExceptionThrown_ReturnsInternalServerError()
        {
            _mockCvDataService.Setup(x => x.GetById(It.IsAny<int>())).Throws(new Exception("Simulated exception"));

            var handler = new GetCvByIdCommandHandler(
                _mockCvDataService.Object,
                _mapperMock.Object);

            var request = new GetCvByIdCommand(1);

            var result = await handler.Handle(request, CancellationToken.None) as StatusCodeResult;

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(500);
        }
    }
}

