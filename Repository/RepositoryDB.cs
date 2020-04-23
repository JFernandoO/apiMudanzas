using DataAccess;
using System;

namespace Repository
{
    public class RepositoryDB : IRepositoryDB
    {
        public void AddLogRegisterDB(Register register)
        {
            SingletonDataContainer.Instance.AddRegister(register);
        }
    }
}
