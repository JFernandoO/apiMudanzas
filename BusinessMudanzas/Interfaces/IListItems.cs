using BusinessMudanzas.Model;
using System;
using System.Collections.Generic;

namespace BusinessMudanzas
{
    public interface IListItems
    {
        IList<WorkDay> GetLists(string fileString);
    }
}
