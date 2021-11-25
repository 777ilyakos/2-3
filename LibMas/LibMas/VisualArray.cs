using System;
using System.Collections.Generic;
using Microsoft.Win32;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace LibMas
{
    public static class VisualArray
    {
        public static DataTable ToDataTable<T>(this T[] array)
        {
            var res = new DataTable();
            for (int i = 0; i < array.Length; i++)
            {
                res.Columns.Add("col" + (i + 1), typeof(T));
            }
            var row = res.NewRow();
            for (int i = 0; i < array.Length; i++)
            {
                row[i] = array[i];
            }
            res.Rows.Add(row);
            return res;
        }
        public static DataTable ToDataTable<T>(this T[,] array)
        {
            var res = new DataTable();
            for (int i = 0; i < array.GetLength(1); i++)
            {
                res.Columns.Add("col" + (i + 1), typeof(T));
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                var row = res.NewRow();

                for (int j = 0; j < array.GetLength(1); j++)
                {
                    row[j] = array[i, j];
                }

                res.Rows.Add(row);
            }

            return res;
        }
    }
}
