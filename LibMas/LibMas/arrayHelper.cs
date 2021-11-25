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
    public static class arrayHelper
    {
        public static bool Save(int[,] array, string file)
        {
            if (array == null)
            {
                return false;
            }
            StreamWriter write = new StreamWriter(file);
                write.WriteLine(array.GetLength(0));
                write.WriteLine(array.GetLength(1));
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        write.WriteLine(array[i, j]);
                    }
                }
            write.Close();
            return true;
        }
        public static bool Save(int[] array, string file)
        {
            if (array == null)
            {
                return false;
            }
            StreamWriter write = new StreamWriter(file);
            write.WriteLine(array.Length);
            for (int i = 0; i < array.Length; i++)
            {
                write.WriteLine(array[i]); 
            }
            write.Close();
            return true;
        }

        public static bool Open(out int[] array, string file)
        {
            StreamReader read = new StreamReader(file);          
            if (Int32.TryParse(read.ReadLine(), out int lengthMas) && lengthMas > 0)
            {
                array = new int[lengthMas];
                for (int i = 0; i < lengthMas; i++)
                {
                    array[i] = Convert.ToInt32(read.ReadLine());
                }
                read.Close();
                return true;
            }
            else 
            { 
                array = new int[0];
                read.Close();
                return false;
            }
        }
        public static bool Open(out int[,] array, string file)
        {
            StreamReader read = new StreamReader(file);           
            if (Int32.TryParse(read.ReadLine(), out int rowMatr) && rowMatr > 0)
            {
                int columnMatr = Convert.ToInt32(read.ReadLine());
                array = new int[rowMatr, columnMatr];
                for (int i = 0; i < rowMatr; i++)
                {
                    for (int j = 0; j < columnMatr; j++)
                    {
                        array[i, j] = Convert.ToInt32(read.ReadLine());
                    }
                }
                read.Close();
                return true;
            }
            else
            {
                array = new int[0,0];
                read.Close();
                return false;
            }
        }

        public static int[,] Create(int lines, int columns)
        {
            return new int[lines, columns];
        }
        public static int[] Create(int countElements)
        {
            return new int[countElements];
        }

        public static void Fill(int[] array,int maxValue)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(maxValue+1);
            }
        }
        public static void Fill(int[] array, int minValue, int maxValue)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(minValue, maxValue + 1);
            }
        }
        public static void Fill(int[,] array, int maxValue)
        {
            Random random = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(maxValue + 1);
                }
            }
        }
        public static void Fill(int[,] array, int minValue, int maxValue)
        {
            Random random = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(minValue,maxValue + 1);
                }
            }
        }

        public static void Clear(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = default;
                }
            }
        }
        public static void Clear(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = default;
            }
        }
    }
}
