using System;
using System.Collections.Generic;

using WarSISModelsDB.Models.Data;

namespace WarSISModelsDB.Models.DataBase
{
    public class Subdivisions : ADataBase<Data.Subdivision>
    {
        public override string GetTableName() => TableName;
        public static String TableName => "Подразделения";

        public static String ID => "id";
        public static String Title => "Название";
        public static String Table => "Таблица";
        public static String Upper => "Вышестоящая";

        public static Dictionary<String, (Type, Int32)> Fields = new Dictionary<String, (Type, Int32)>()
        {
            { ID, (typeof(Int32), 0) },
            { Title, (typeof(String), 50) },
            { Table, (typeof(String), 50) },
            { Upper, (typeof(String), 50) },
        };
    }
}