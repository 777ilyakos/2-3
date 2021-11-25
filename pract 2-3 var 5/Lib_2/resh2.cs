using System;

namespace Lib_2
{
    public class resh2
    {
        public static Int64 productSmaller3(int[] array)
        {
            int product = 1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 3) product *= array[i];
            }
            return product;
        }
    }
}
