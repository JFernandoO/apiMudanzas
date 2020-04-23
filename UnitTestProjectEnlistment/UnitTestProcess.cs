using BusinessMudanzas;
using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Repository;
using WebApiMudanzas.Models;

namespace UnitTestProjectEnlistment
{
    [TestClass]
    public class UnitTestProcess
    {
        private ProcessBusiness _ProccesBusiness;
        ProcessBusinessMock _service1;

        private ICalculateMovements _calculateMovementsTest;
        private IFiles _filesTest;
        private IListItems _listItems;
        private IRepositoryDB _repositoryDB;

        [TestMethod]
        public void Test()
        {
            Assert.IsNotNull("Not null");
        }

        [TestMethod]
        public void TestMethodProcess()
        {
            // Arrange
            _service1 = new ProcessBusinessMock();
            _service1.Setup_01();

            Mock<ICalculateMovements> __calculateMovementsMock = _service1._calculateMovements;
            _calculateMovementsTest = __calculateMovementsMock.Object;

            Mock<IFiles> _filesMock = _service1._files;
            _filesTest = _filesMock.Object;

            Mock<IListItems> _listItemsMock = _service1._listItems;
            _listItems = _listItemsMock.Object;

            Mock<IRepositoryDB> _dbMock = _service1._repositoryDB;
            _repositoryDB = _dbMock.Object;

            _ProccesBusiness = new ProcessBusiness(_calculateMovementsTest, _filesTest, _listItems, _repositoryDB);

            // Action
            string result = _ProccesBusiness.GetProcess(new FileUpload() { Name="cedula"});

            // Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual(result, "Ok");
        }
    }
}
