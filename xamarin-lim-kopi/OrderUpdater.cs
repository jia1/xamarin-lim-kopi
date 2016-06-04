using System.Text;
using System;

namespace Core
{
    public static class OrderUpdater
    {
        public static string generateOrder(int index, string newOrderPart, ref string[] array)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
                if (i == index)
                    array[i] = newOrderPart;
                builder.Append(" " + array[i]);
            }
            return builder.ToString();
        }
    }
}