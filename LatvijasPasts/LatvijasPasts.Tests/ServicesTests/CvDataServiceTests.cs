using FluentAssertions;
using LatvijasPasts.Services.IServices;
using LatvijasPasts.Services.Services;
using LatvijasPastsCore.Models;
using LatvijasPastsData;
using Microsoft.EntityFrameworkCore;
using Moq;


namespace LatvijasPasts.Tests.ServicesTests
{
    [TestClass]
    public class CvDataServiceTests
    {
        private Mock<ILatvijasPastsDbContext>? _dbContextMock;
        private ICvDataService? _cvDataService;

        [TestInitialize]
        public void Setup()
        {
            var cvDataList = new List<CVData>();
            var cvDataQueryable = cvDataList.AsQueryable();

            var dbSetMock = new Mock<DbSet<CVData>>();
            dbSetMock.As<IQueryable<CVData>>().Setup(m => m.Provider).Returns(cvDataQueryable.Provider);
            dbSetMock.As<IQueryable<CVData>>().Setup(m => m.Expression).Returns(cvDataQueryable.Expression);
            dbSetMock.As<IQueryable<CVData>>().Setup(m => m.ElementType).Returns(cvDataQueryable.ElementType);
            dbSetMock.As<IQueryable<CVData>>().Setup(m => m.GetEnumerator()).Returns(cvDataQueryable.GetEnumerator());

            _dbContextMock = new Mock<ILatvijasPastsDbContext>();
            _dbContextMock.Setup(x => x.CVDatas).Returns(dbSetMock.Object);

            _cvDataService = new CvDataService(_dbContextMock.Object);
        }

        [TestMethod]
        public void CheckForDuplicates_ReturnsTrue_WhenDuplicateExists()
        {
            var cvData = new CVData
            {
                AvatarUrl = "avatar-url",
                ColourUrl = "colour-url",
                DateOfBirth = "2022-02-22",
                EMail = "test@example.com",
                Name = "John",
                PhoneNumber = "123456789",
                Surname = "Doe"
            };

            var cvDataList = new List<CVData> { cvData };

            var dbSetMock = new Mock<DbSet<CVData>>();
            dbSetMock.As<IQueryable<CVData>>().Setup(m => m.Provider).Returns(cvDataList.AsQueryable().Provider);
            dbSetMock.As<IQueryable<CVData>>().Setup(m => m.Expression).Returns(cvDataList.AsQueryable().Expression);
            dbSetMock.As<IQueryable<CVData>>().Setup(m => m.ElementType).Returns(cvDataList.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<CVData>>().Setup(m => m.GetEnumerator()).Returns(cvDataList.GetEnumerator());

            _dbContextMock.Setup(x => x.CVDatas).Returns(dbSetMock.Object);

            var result = _cvDataService.CheckForDuplicates(cvData);

            result.Should().BeTrue();
        }

        [TestMethod]
        public void CheckForDuplicates_ReturnsFalse_WhenNoDuplicateExists()
        {
            var cvData = new CVData
            {
                AvatarUrl = "avatar-url",
                ColourUrl = "colour-url",
                DateOfBirth = "22-02-2022",
                EMail = "test@example.com",
                Name = "John",
                PhoneNumber = "123456789",
                Surname = "Doe"
            };

            var options = new DbContextOptionsBuilder<LatvijasPastsDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            using (var context = new LatvijasPastsDbContext(options))
            {
                context.CVDatas.Add(cvData);
                context.SaveChanges();

                var result = _cvDataService.CheckForDuplicates(cvData);

                result.Should().BeFalse();
            }
        }

        [TestMethod]
        public void GetAllCvData_ReturnsAllCVData()
        {
            var expectedData = new List<CVData>
            {
                new CVData { Id = 1, Name = "John" },
                new CVData { Id = 2, Name = "Alice" },
            };
            var dbSetMock = new Mock<DbSet<CVData>>();
            dbSetMock.As<IQueryable<CVData>>().Setup(m => m.Provider).Returns(expectedData.AsQueryable().Provider);
            dbSetMock.As<IQueryable<CVData>>().Setup(m => m.Expression).Returns(expectedData.AsQueryable().Expression);
            dbSetMock.As<IQueryable<CVData>>().Setup(m => m.ElementType).Returns(expectedData.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<CVData>>().Setup(m => m.GetEnumerator()).Returns(expectedData.GetEnumerator());
            _dbContextMock.Setup(x => x.CVDatas).Returns(dbSetMock.Object);

            var result = _cvDataService.GetAllCvData();

            result.Should().BeEquivalentTo(expectedData);
        }


        [TestMethod]
        public void Save_ReturnsTrue_WhenSaveChangesIsSuccessful()
        {
            _dbContextMock.Setup(x => x.SaveChanges()).Returns(1);

            var result = _cvDataService.Save();

            result.Should().BeTrue();
        }

        [TestMethod]
        public void Save_ReturnsFalse_WhenSaveChangesFails()
        {
            _dbContextMock.Setup(x => x.SaveChanges()).Returns(0);

            var result = _cvDataService.Save();

            result.Should().BeFalse();
        }
    }
}