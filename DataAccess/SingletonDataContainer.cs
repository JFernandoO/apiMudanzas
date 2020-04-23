using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess
{
    public class SingletonDataContainer : IRepository
    {
        private readonly DbContext myContext;

        private SingletonDataContainer()
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseSqlServer(strConnect);
            
            myContext = new MyContext(optionsBuilder.Options);
        }

        public void AddRegister(Register register)
        {
            myContext.Add(register);
            myContext.SaveChanges();
        }

        private static Lazy<SingletonDataContainer> instance = new Lazy<SingletonDataContainer>(() => new SingletonDataContainer());
        public static string strConnect;

        public static SingletonDataContainer Instance => instance.Value;
     
    }
}
