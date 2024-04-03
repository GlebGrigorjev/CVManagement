using FluentAssertions;
using LatvijasPasts.Services.Services;
using LatvijasPastsCore.Models;
using LatvijasPastsData;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace LatvijasPasts.Tests.ServicesTests
{
    [TestClass]
    public class DbServiceTests
    {
        private Mock<ILatvijasPastsDbContext> _dbContextMock;
        private DbService _dbService;

        [TestInitialize]
        public void Setup()
        {
            _dbContextMock = new Mock<ILatvijasPastsDbContext>();
            _dbService = new DbService(_dbContextMock.Object);

            var entities = new List<CVData> { new CVData(), new CVData() };

            var dbSetMock = new Mock<DbSet<CVData>>();
            dbSetMock.As<IQueryable<CVData>>().Setup(m => m.Provider).Returns(entities.AsQueryable().Provider);
            dbSetMock.As<IQueryable<CVData>>().Setup(m => m.Expression).Returns(entities.AsQueryable().Expression);
            dbSetMock.As<IQueryable<CVData>>().Setup(m => m.ElementType).Returns(entities.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<CVData>>().Setup(m => m.GetEnumerator()).Returns(entities.AsQueryable().GetEnumerator());

            _dbContextMock.Setup(x => x.Set<CVData>()).Returns(dbSetMock.Object);
        }

        [TestMethod]
        public void GetById_ReturnsEntity_WhenIdExists()
        {
            int entityId = 1;
            var expectedEntity = new CVData { Id = entityId };

            var dbSetMock = new Mock<DbSet<CVData>>();
            dbSetMock.Setup(x => x.Find(entityId)).Returns(expectedEntity);

            _dbContextMock.Setup(x => x.Set<CVData>()).Returns(dbSetMock.Object);

            var entity = _dbService.GetById<CVData>(entityId);

            entity.Should().NotBeNull();
            entity.Should().BeEquivalentTo(expectedEntity);
        }

        [TestMethod]
        public void Create_AddsEntity()
        {
            var entity = new CVData();

            _dbService.Create(entity);

            _dbContextMock.Verify(x => x.Set<CVData>().Add(entity), Times.Once);
            _dbContextMock.Verify(x => x.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void Delete_RemovesEntity()
        {
            var entity = new CVData();

            _dbService.Delete(entity);

            _dbContextMock.Verify(x => x.Set<CVData>().Remove(entity), Times.Once);
            _dbContextMock.Verify(x => x.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void DeleteAll_RemovesAllEntities()
        {
            var entities = new List<CVData> { new CVData(), new CVData() };

            _dbService.DeleteAll<CVData>();

            _dbContextMock.Verify(x => x.Set<CVData>().RemoveRange(It.IsAny<IEnumerable<CVData>>()), Times.Once);
            _dbContextMock.Verify(x => x.SaveChanges(), Times.Once);
        }


        [TestMethod]
        public void GetAll_ReturnsAllEntities()
        {
            var entities = new List<CVData> { new CVData(), new CVData() };

            var dbSetMock = new Mock<DbSet<CVData>>();
            dbSetMock.As<IQueryable<CVData>>().Setup(m => m.Provider).Returns(entities.AsQueryable().Provider);
            dbSetMock.As<IQueryable<CVData>>().Setup(m => m.Expression).Returns(entities.AsQueryable().Expression);
            dbSetMock.As<IQueryable<CVData>>().Setup(m => m.ElementType).Returns(entities.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<CVData>>().Setup(m => m.GetEnumerator()).Returns(entities.AsQueryable().GetEnumerator());

            _dbContextMock.Setup(x => x.Set<CVData>()).Returns(dbSetMock.Object);

            var result = _dbService.GetAll<CVData>();

            result.Should().HaveCount(entities.Count);
            result.Should().BeEquivalentTo(entities);
        }
    }
}
