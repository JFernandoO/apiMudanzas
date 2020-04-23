using BusinessMudanzas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessMudanzas
{
    public class CalculateMovements : ICalculateMovements
    {
        public string GetTotaltravels(IList<WorkDay> lists)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < lists.Count; i++)
            {
                var count = GetTravelsRecursive(lists[i]);
                result.Append($"Case #{(i + 1)}: {count}\n");
            }
            return result.ToString();
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
                int a = items.First();
                //last item
                if (items.Count == 1)
                {
                    if (a >= 50)
                    {
                        items.RemoveAt(0);
                        count++;
                    }
                    return items;
                }

                if (a * iterator >= 50)
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
