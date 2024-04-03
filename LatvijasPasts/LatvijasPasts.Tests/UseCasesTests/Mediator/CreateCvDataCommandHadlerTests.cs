using AutoMapper;
using FluentAssertions;
using FluentValidation;
using LatvijasPasts.Services.IServices;
using LatvijasPasts.UseCases.CreateCv;
using LatvijasPasts.UseCases.Models;
using LatvijasPastsCore.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace LatvijasPasts.Tests.UseCasesTests.Mediator
{
    [TestClass]
    public class CreateCvDataCommandHadlerTests
    {
        private Mock<IDbService> _dbServiceMock;
        private Mock<IMapper> _mapperMock;
        private Mock<IValidator<CvViewModel>> _validatorMock;

        [TestInitialize]
        public void Setup()
        {
            _dbServiceMock = new Mock<IDbService>();
            _mapperMock = new Mock<IMapper>();
            _validatorMock = new Mock<IValidator<CvViewModel>>();
        }

        [TestMethod]
        public async Task Handle_ValidRequest_ReturnsOkObjectResult()
        {
            var handler = new CreateCvDataCommandHandler(
                _dbServiceMock.Object,
                _mapperMock.Object,
                _validatorMock.Object);

            var request = new CreateCvCommand { newCvData = new CvViewModel() };
            _validatorMock.Setup(x => x.ValidateAsync(It.IsAny<CvViewModel>(), CancellationToken.None))
                .ReturnsAsync(new FluentValidation.Results.ValidationResult());

            _mapperMock.Setup(x => x.Map<CVData>(It.IsAny<CvViewModel>()))
                .Returns(new CVData());

            var result = await handler.Handle(request, CancellationToken.None) as OkObjectResult;

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
            result.Value.Should().BeOfType<CVData>();
        }

        [TestMethod]
        public async Task Handle_InvalidRequest_ReturnsBadRequestObjectResult()
        {
            var handler = new CreateCvDataCommandHandler(
                _dbServiceMock.Object,
                _mapperMock.Object,
                _validatorMock.Object);

            var request = new CreateCvCommand { newCvData = new CvViewModel() };
            var validationResult = new FluentValidation.Results.ValidationResult();
            validationResult.Errors.Add(new FluentValidation.Results.ValidationFailure("propertyName", "errorMessage"));
            _validatorMock.Setup(x => x.ValidateAsync(It.IsAny<CvViewModel>(), CancellationToken.None))
                .ReturnsAsync(validationResult);

            var result = await handler.Handle(request, CancellationToken.None) as BadRequestObjectResult;

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(400);
            result.Value.Should().BeOfType<string>().Which.Should().Be("errorMessage");
        }

        [TestMethod]
        public async Task Handle_ExceptionThrown_ReturnsInternalServerError()
        {
            var handler = new CreateCvDataCommandHandler(
                _dbServiceMock.Object,
                _mapperMock.Object,
                _validatorMock.Object);

            var request = new CreateCvCommand { newCvData = new CvViewModel() };
            _validatorMock.Setup(x => x.ValidateAsync(It.IsAny<CvViewModel>(), CancellationToken.None))
                .ReturnsAsync(new FluentValidation.Results.ValidationResult());

            _mapperMock.Setup(x => x.Map<CVData>(It.IsAny<CvViewModel>()))
                .Throws(new Exception("Simulated exception"));

            var result = await handler.Handle(request, CancellationToken.None) as StatusCodeResult;

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(500);
        }
    }
}