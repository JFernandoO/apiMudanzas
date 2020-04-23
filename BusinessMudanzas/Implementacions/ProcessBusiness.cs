using DataAccess;
using Repository;
using System;
using WebApiMudanzas.Models;

namespace BusinessMudanzas
{
    public class ProcessBusiness : IProcessBusiness
    {
        private readonly ICalculateMovements _calculateMovements;
        private readonly IFiles _files;
        private readonly IListItems _listItems;
        private readonly IRepositoryDB _repositoryDB;

        public ProcessBusiness()
        {
            _calculateMovements = new CalculateMovements();
            _files = new Files();
            _listItems = new ListItems();
            _repositoryDB = new RepositoryDB();
        }

        public ProcessBusiness(ICalculateMovements calculateMovements, IFiles files, IListItems listItems, IRepositoryDB repositoryDB)
        {
            _calculateMovements = calculateMovements;
            _files = files;
            _listItems = listItems;
            _repositoryDB = repositoryDB;
        }

        public string GetProcess(FileUpload fileUpload)
        {
            var stringFile = _files.ReadAsString(fileUpload.File);
            var listWorkDays = _listItems.GetLists(stringFile);
            var result = _calculateMovements.GetTotaltravels(listWorkDays);
            CrearLog(fileUpload.Name, result);
            return result;
        }

        private void CrearLog(string name, string text)
        {
            var reg = new Register()
            {
                Name = name,
                dateRegister = DateTime.Now,
                FileRegister = text
            };
            _repositoryDB.AddLogRegisterDB(reg);
        }
    }
}
