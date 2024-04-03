using AutoMapper;
using FluentAssertions;
using LatvijasPasts.Services.IServices;
using LatvijasPasts.UseCases.GetFullCvList;
using LatvijasPasts.UseCases.Models;
using LatvijasPastsCore.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace LatvijasPasts.Tests.UseCasesTests.Mediator
{
    [TestClass]
    public class GetFullCvListCommandHandlerTests
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
        public async Task Handle_CvListExists_ReturnsOkObjectResultWithCvViewModelList()
        {
            var cvList = new List<CVData> { };
            var cvViewModelList = new List<CvViewModel> { };

            _mockCvDataService.Setup(x => x.GetAllCvData()).Returns(cvList);
            _mapperMock.Setup(x => x.Map<List<CvViewModel>>(cvList)).Returns(cvViewModelList);

            var handler = new GetFullCvListCommandHandler(
                _mockCvDataService.Object,
                _mapperMock.Object);

            var request = new GetFullCvListCommand();

            var result = await handler.Handle(request, CancellationToken.None) as OkObjectResult;

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
            result.Value.Should().BeOfType<List<CvViewModel>>();
            result.Value.Should().BeEquivalentTo(cvViewModelList);
        }

        [TestMethod]
        public async Task Handle_CvListNotFound_ReturnsNotFoundResult()
        {
            _mockCvDataService.Setup(x => x.GetAllCvData()).Returns((List<CVData>)null);

            var handler = new GetFullCvListCommandHandler(
                _mockCvDataService.Object,
                _mapperMock.Object);

            var request = new GetFullCvListCommand();

            var result = await handler.Handle(request, CancellationToken.None) as NotFoundResult;

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(404);
        }

        [TestMethod]
        public async Task Handle_ExceptionThrown_ReturnsInternalServerError()
        {
            _mockCvDataService.Setup(x => x.GetAllCvData()).Throws(new Exception("Simulated exception"));

            var handler = new GetFullCvListCommandHandler(
                _mockCvDataService.Object,
                _mapperMock.Object);

            var request = new GetFullCvListCommand();

            var result = await handler.Handle(request, CancellationToken.None) as StatusCodeResult;

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(500);
        }
    }
}
