using System;
using System.Collections.Generic;

namespace WarSISModelsDB.Models.DataBase
{
    public class Properties : ADataBase<Data.Property>
    {
        public override string GetTableName() => TableName;
        public static String TableName => "Имущество";

        public static String ID => "id";
        public static String Title => "Название";
        public static String Table => "Таблица";

        public static Dictionary<String, (Type, Int32)> Fields = new Dictionary<String, (Type, Int32)>()
        {
            { ID, (typeof(Int32), 0) },
            { Title, (typeof(String), 50) },
            { Table, (typeof(String), 50) },
        };

    }
}