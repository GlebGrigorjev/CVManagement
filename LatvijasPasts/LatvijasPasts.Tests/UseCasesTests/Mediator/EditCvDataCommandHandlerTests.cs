using AutoMapper;
using FluentAssertions;
using FluentValidation;
using LatvijasPasts.Services.IServices;
using LatvijasPasts.UseCases.EditCvData;
using LatvijasPasts.UseCases.Models;
using LatvijasPastsCore.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace LatvijasPasts.Tests.UseCasesTests.Mediator
{
    [TestClass]
    public class EditCvDataCommandHandlerTests
    {
        private Mock<ICvDataService> _mockCvDataService;
        private Mock<IMapper> _mapperMock;
        private Mock<IValidator<CvViewModel>> _validatorMock;

        [TestInitialize]
        public void Setup()
        {
            _mockCvDataService = new Mock<ICvDataService>();
            _mapperMock = new Mock<IMapper>();
            _validatorMock = new Mock<IValidator<CvViewModel>>();
        }

        [TestMethod]
        public async Task Handle_ValidRequest_ReturnsOkObjectResult()
        {
            var cvDataToEdit = new CVData();
            _mockCvDataService.Setup(x => x.GetById(It.IsAny<int>())).Returns(cvDataToEdit);
            _validatorMock.Setup(x => x.ValidateAsync(It.IsAny<CvViewModel>(), CancellationToken.None))
                .ReturnsAsync(new FluentValidation.Results.ValidationResult());
            _mapperMock.Setup(x => x.Map(It.IsAny<CvViewModel>(), It.IsAny<CVData>()))
                .Callback((CvViewModel vm, CVData data) => { });

            var handler = new EditCvDataCommandHandler(
                _mockCvDataService.Object,
                _mapperMock.Object,
                _validatorMock.Object);

            var request = new EditCvDataCommand(1, new CvViewModel());

            var result = await handler.Handle(request, CancellationToken.None) as OkObjectResult;

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
            result.Value.Should().BeOfType<CVData>();
        }

        [TestMethod]
        public async Task Handle_CvDataNotFound_ReturnsNotFoundResult()
        {
            _mockCvDataService.Setup(x => x.GetById(It.IsAny<int>())).Returns((CVData)null);

            var handler = new EditCvDataCommandHandler(
                _mockCvDataService.Object,
                _mapperMock.Object,
                _validatorMock.Object);

            var request = new EditCvDataCommand(1, new CvViewModel());

            var result = await handler.Handle(request, CancellationToken.None) as NotFoundResult;

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(404);
        }

        [TestMethod]
        public async Task Handle_ValidationFailure_ReturnsBadRequestObjectResultWithErrorMessage()
        {
            _mockCvDataService.Setup(x => x.GetById(It.IsAny<int>())).Returns(new CVData());
            _validatorMock.Setup(x => x.ValidateAsync(It.IsAny<CvViewModel>(), CancellationToken.None))
                .ReturnsAsync(new FluentValidation.Results.ValidationResult
                { Errors = { new FluentValidation.Results.ValidationFailure("propertyName", "errorMessage") } });

            var handler = new EditCvDataCommandHandler(
                _mockCvDataService.Object,
                _mapperMock.Object,
                _validatorMock.Object);

            var request = new EditCvDataCommand(1, new CvViewModel());

            var result = await handler.Handle(request, CancellationToken.None) as BadRequestObjectResult;

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(400);
            result.Value.Should().BeOfType<string>().Which.Should().Be("errorMessage");
        }

        [TestMethod]
        public async Task Handle_SuccessfulEdit_ReturnsOkObjectResultWithEditedData()
        {
            // Arrange
            var cvDataToEdit = new CVData { Id = 1 };
            var editedData = new CvViewModel();

            _mockCvDataService.Setup(x => x.GetById(It.IsAny<int>())).Returns(cvDataToEdit);
            _validatorMock.Setup(x => x.ValidateAsync(It.IsAny<CvViewModel>(), CancellationToken.None))
                .ReturnsAsync(new FluentValidation.Results.ValidationResult()); // Assume validation passes
            _mapperMock.Setup(x => x.Map(It.IsAny<CvViewModel>(), It.IsAny<CVData>()))
                .Callback((CvViewModel vm, CVData data) =>
                { });

            var handler = new EditCvDataCommandHandler(
                _mockCvDataService.Object,
                _mapperMock.Object,
                _validatorMock.Object);

            var request = new EditCvDataCommand(1, editedData);

            var result = await handler.Handle(request, CancellationToken.None) as OkObjectResult;

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
            result.Value.Should().BeOfType<CVData>();

            var editedResult = result.Value as CVData;
            editedResult.Should().NotBeNull();
            editedResult.Id.Should().Be(cvDataToEdit.Id);
        }

        [TestMethod]
        public async Task Handle_ExceptionThrown_ReturnsInternalServerError()
        {
            _mockCvDataService.Setup(x => x.GetById(It.IsAny<int>())).Throws(new Exception("Simulated exception"));

            var handler = new EditCvDataCommandHandler(
                _mockCvDataService.Object,
                _mapperMock.Object,
                _validatorMock.Object);

            var request = new EditCvDataCommand(1, new CvViewModel());

            var result = await handler.Handle(request, CancellationToken.None) as StatusCodeResult;

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(500);
        }
    }
}
