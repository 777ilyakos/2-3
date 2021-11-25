using System;
using LibMas;

namespace Lib_3
{
    public class resh3
    {
        public static int task3(in int[,]matrix)
        {
            int numberSimilar=0;
            int[] arrayfirst = new int[101];
            int[] arraycurrent = new int[101];
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                arrayfirst[(matrix[0,j])]++;
            }

            for (int i = 0; i < matrix.GetLength(0); i=i+2)
            {
                bool kay = true;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    arraycurrent[matrix[i, j]]++;
                }
                for (int j = 0; j < 101; j++)
                {
                    if (arrayfirst[j] != arraycurrent[j])
                    {
                        kay = false;
                        break;
                    }
                }
                arrayHelper.Clear(arraycurrent);
                if (kay) numberSimilar++;
            }
            return numberSimilar;
        }
    }
}
