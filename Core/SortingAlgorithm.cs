//ST10116273
//Kunal Goyal
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeweySystem.Core
{
    class SortingAlgorithm
    {

        public static List<string> SortIt(List<string> arr)
        {
            List<double> arrlist = new List<double>();
            

            foreach (string item in arr)
            {
                string[] num = item.Split('\t');
                arrlist.Add(Convert.ToDouble(num[0]));

            }

            int n = arr.Count;

            for (int i = 1; i < n; ++i)
            {
                string key = arr[i];
                double key1 = arrlist[i];
                int j = i - 1;


                while (j >= 0 && arrlist[j] > key1)
                {
                    arrlist[j + 1] = arrlist[j];
                    arr[j + 1] = arr[j];
                    j = j - 1;

                }
                arrlist[j + 1] = key1;
                arr[j + 1] = key;
            }

            return arr;

        }
    }
}
