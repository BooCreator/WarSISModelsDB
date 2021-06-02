using System;
using System.Collections.Generic;

namespace WarSISModelsDB
{
    /// <summary>
    /// Расширения для Object предназначенное для более удобной
    /// конвертации типов при получении из БД
    /// </summary>
    public static class ObjectConvertExtension
    {
        public static Int32 ToInt32(this Object Value)
        {
            int result = -1;
            if (Int32.TryParse(Value.ToString(), out int res))
                result = res;
            return result;
        }

        public static Double ToDouble(this Object Value)
        {
            double result = -1;
            if (Double.TryParse(Value.ToString(), out double res))
                result = res;
            else if (Double.TryParse(Value.ToString().Replace(".", ","), out res))
            {
                result = res;
            }
            else if (Double.TryParse(Value.ToString().Replace(",", "."), out res))
            {
                result = res;
            }
            return result;
        }

        public static DateTime ToDateTime(this Object Value)
        {
            DateTime result = DateTime.Now;
            if (DateTime.TryParse(Value.ToString(), out DateTime res))
            {
                result = res;
            }
            return result;
        }

        public static List<String> ToList(this Object Value)
        {
            var result = new List<String>();
            foreach (String Item in Value.ToString().Split(','))
            {
                if (Item.Length > 0)
                    result.Add(Item);
            }
            return result;
        }
        public static List<Int32> ToListInt(this Object Value)
        {
            var result = new List<Int32>();
            foreach (String Item in Value.ToString().Split(','))
            {
                if (Int32.TryParse(Item, out int res))
                    result.Add(res);
                else
                    return new List<Int32>();
            }
            return result;
        }

    }
}
