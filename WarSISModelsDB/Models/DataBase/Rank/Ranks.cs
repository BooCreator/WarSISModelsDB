using System;
using System.Collections.Generic;

namespace WarSISModelsDB.Models.DataBase
{
    public class Ranks : ADataBase<Data.Rank>
    {
        public override string GetTableName() => TableName;
        public static String TableName => "Звания";

        public static String ID => "id";
        public static String Title => "Название";
        public static String Table => "Талица";
        public static String Upper => "Вышестоящая";

        public static Dictionary<String, (Type, Int32)> Fields = new Dictionary<String, (Type, Int32)>()
        {
            { ID, (typeof(Int32), 0) },
            { Title, (typeof(String), 64) },
            { Table, (typeof(String), 50) }, 
            { Upper, (typeof(Int32), 0) }
        };

    }
}
