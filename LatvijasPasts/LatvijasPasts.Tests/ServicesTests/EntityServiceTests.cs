using FluentAssertions;
using LatvijasPasts.Services.Services;
using LatvijasPastsCore.Models;
using LatvijasPastsData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;

namespace LatvijasPasts.Tests.ServicesTests
{
    [TestClass]
    public class EntityServiceTests
    {
        private Mock<ILatvijasPastsDbContext> _dbContextMock;
        private EntityService<CVData> _entityService;

        [TestInitialize]
        public void Setup()
        {
            _dbContextMock = new Mock<ILatvijasPastsDbContext>();
            _entityService = new EntityService<CVData>(_dbContextMock.Object);

            var entities = new List<CVData> { new CVData(), new CVData() };
            var dbSetMock = new Mock<DbSet<CVData>>();
            dbSetMock.As<IQueryable<CVData>>().Setup(m => m.Provider).Returns(entities.AsQueryable().Provider);
            dbSetMock.As<IQueryable<CVData>>().Setup(m => m.Expression).Returns(entities.AsQueryable().Expression);
            dbSetMock.As<IQueryable<CVData>>().Setup(m => m.ElementType).Returns(entities.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<CVData>>().Setup(m => m.GetEnumerator()).Returns(entities.AsQueryable().GetEnumerator());
            _dbContextMock.Setup(x => x.Set<CVData>()).Returns(dbSetMock.Object);

            _dbContextMock.Setup(x => x.Entry(It.IsAny<CVData>())).Returns(Mock.Of<EntityEntry<CVData>>);
        }

        [TestMethod]
        public void Create_Calls_DbService_Create_With_Correct_Entity()
        {
            var entity = new CVData();

            _entityService.Create(entity);

            _dbContextMock.Verify(x => x.Set<CVData>().Add(It.IsAny<CVData>()), Times.Once);
            _dbContextMock.Verify(x => x.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void Delete_Calls_DbService_Delete_With_Correct_Entity()
        {
            var entity = new CVData();

            _entityService.Delete(entity);

            _dbContextMock.Verify(x => x.Set<CVData>().Remove(entity), Times.Once);
            _dbContextMock.Verify(x => x.SaveChanges(), Times.Once);
        }


        [TestMethod]
        public void GetAll_Returns_All_Entities()
        {
            var entities = new List<CVData> { new CVData(), new CVData() };

            var dbSetMock = new Mock<DbSet<CVData>>();
            dbSetMock.As<IQueryable<CVData>>().Setup(m => m.Provider).Returns(entities.AsQueryable().Provider);
            dbSetMock.As<IQueryable<CVData>>().Setup(m => m.Expression).Returns(entities.AsQueryable().Expression);
            dbSetMock.As<IQueryable<CVData>>().Setup(m => m.ElementType).Returns(entities.AsQueryable().ElementType);
            dbSetMock.As<IQueryable<CVData>>().Setup(m => m.GetEnumerator()).Returns(entities.AsQueryable().GetEnumerator());

            _dbContextMock.Setup(x => x.Set<CVData>()).Returns(dbSetMock.Object);

            var result = _entityService.GetAll();

            Assert.AreEqual(entities.Count, result.Count());
            CollectionAssert.AreEqual(entities, result.ToList());
        }

        [TestMethod]
        public void GetById_Returns_Entity_With_Correct_Id()
        {
            int id = 1;
            var expectedEntity = new CVData { Id = id };

            _dbContextMock.Setup(x => x.Set<CVData>().Find(id)).Returns(expectedEntity);

            var result = _entityService.GetById(id);

            result.Should().BeEquivalentTo(expectedEntity);
        }

        [TestMethod]
        public void DeleteAll_Calls_DbService_DeleteAll()
        {
            _entityService.DeleteAll();

            _dbContextMock.Verify(x => x.Set<CVData>().RemoveRange(It.IsAny<IEnumerable<CVData>>()), Times.Once);
            _dbContextMock.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
