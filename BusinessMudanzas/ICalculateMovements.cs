﻿using BusinessMudanzas.Model;
using System;
using System.Collections.Generic;

namespace BusinessMudanzas
{
    public interface ICalculateMovements
    {
        IList<WorkDay> GetLists(string fileString);
        int GetTravels(WorkDay workday);
        int GetTravelsRecursive(WorkDay workday);
        string GetTotaltravels(IList<WorkDay> lists);
    }
}
