using BusinessMudanzas;
using BusinessMudanzas.Model;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Moq;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProjectEnlistment
{
    public class ProcessBusinessMock
    {
        public Mock<ICalculateMovements> _calculateMovements { get; set; }
        public Mock<IFiles> _files { get; set; }
        public Mock<IListItems> _listItems { get; set; }
        public Mock<IRepositoryDB> _repositoryDB { get; set; }


        public ProcessBusinessMock()
        {
            _calculateMovements = new Mock<ICalculateMovements>();
            _files = new Mock<IFiles>();
            _listItems = new Mock<IListItems>();
            _repositoryDB = new Mock<IRepositoryDB>();
        }

        public void Setup_01()
        {
            _files.Setup((x) => x.ReadAsString(It.IsAny<IFormFile>())).Returns(string.Empty);
            _listItems.Setup((x) => x.GetLists(It.IsAny<string>())).Returns(new List<WorkDay>());
            _calculateMovements.Setup((x) => x.GetTotaltravels(It.IsAny<IList<WorkDay>>())).Returns(string.Empty);
            _repositoryDB.Setup((x) => x.AddLogRegisterDB(It.IsAny<Register>()));
        }

        
    }
}
