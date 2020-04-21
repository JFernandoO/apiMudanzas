﻿using BusinessMudanzas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessMudanzas
{
    public class CalculateMovements : ICalculateMovements
    {
        public CalculateMovements()
        {

        }

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

        public string GetTotaltravels(IList<WorkDay> lists)
        {
            StringBuilder result = new StringBuilder();
            for (int i= 0; i < lists.Count; i++)
            {
                var count = GetTravelsRecursive(lists[i]);
                result.Append($"Case #{(i + 1)}: {count}\n");
            }
            return result.ToString();
        }


        public int GetTravels(WorkDay workday)
        {
            var wd = workday.Items;
            int count = 0;
            while (wd.Count > 0)
            {
                if (wd.Count == 1)
                {
                    wd.RemoveAt(0);
                    count++;
                    break;
                }

                int a = wd.First();

                if (a >= 50)
                {
                    wd.RemoveAt(0);
                    count++;
                    //if (b >= 50)
                    //{
                    //    wd.RemoveAt(wd.Count - 1);
                    //    count++;
                    //}
                }
                else if (a * 2 >= 50)
                {
                    wd.RemoveAt(0);
                    wd.RemoveAt(wd.Count - 1);
                    count++;
                }
                else if (a * 2 < 50)
                {
                    //sumValue = a; //+ b;
                    wd.RemoveAt(0);
                    wd.RemoveAt(wd.Count - 1);

                    int iterator = 3;
                    if (a * iterator >= 50)
                    {
                        wd.RemoveAt(0);
                    }
                    else
                    {
                        while (wd.Count > 0)
                        {
                            if (a * iterator <= 50 || wd.Count == 0)
                            {
                                wd.RemoveAt(wd.Count - 1);
                                iterator++;
                            }
                            else
                            {
                                wd.RemoveAt(wd.Count - 1);
                                break;
                            }

                        }
                    }
                    count++;
                }
            }
            return count;
        }

        public int GetTravelsRecursive(WorkDay workday)
        {
            int count = 0;
            NextAction(workday.Items, 2, ref count);
            return count;
        }

        private IList<int> NextAction(IList<int> items, int iterator, ref int count)
        {
            if (items.Count > 0)
            {
                if (items.Count == 1)
                {
                    items.RemoveAt(0);
                    count++;
                    return items;
                }

                int a = items.First();
                if (a * iterator > 50)//--
                {
                    if (a < 50)
                    {
                        items.RemoveAt(items.Count - 1);
                    }
                    items.RemoveAt(0);
                    count++;
                    items = NextAction(items, 2, ref count);

                }
                else
                {
                    items.RemoveAt(items.Count - 1);
                    iterator++;
                    items = NextAction(items, iterator, ref count);
                }

            }
            return items;
        }
    }
}
