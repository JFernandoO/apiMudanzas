using BusinessMudanzas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessMudanzas
{
    public class ListItems : IListItems
    {
        public IList<WorkDay> GetLists(string fileString)
        {
            String[] strlist = fileString.Split('\n');
            IList<WorkDay> listWorkDays = new List<WorkDay>();
            int nDays = int.Parse(strlist[0]);
            int i = 1, iDays = 0;
            while (iDays < nDays)
            {
                int nItems = int.Parse(strlist[i]);
                i = i + 1;
                var listItems = NextItems(i, nItems, strlist);
                i += nItems;

                listWorkDays.Add(new WorkDay() { NItems = nItems, Items = listItems });

                iDays++;
            }

            return listWorkDays;
        }

        private List<int> NextItems(int i, int nItems, String[] strlist)
        {
            var listItems = new List<int>();
            int j = i;
            while (j < i + nItems)
            {
                listItems.Add(int.Parse(strlist[j]));
                j++;
            }
            listItems.Sort((a, b) => b.CompareTo(a));
            return listItems;
        }
    }
}
