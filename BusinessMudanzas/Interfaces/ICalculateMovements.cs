using BusinessMudanzas.Model;
using System;
using System.Collections.Generic;

namespace BusinessMudanzas
{
    public interface ICalculateMovements
    {
        int GetTravelsRecursive(WorkDay workday);
        string GetTotaltravels(IList<WorkDay> lists);
    }
}
