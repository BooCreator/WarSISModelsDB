using System;
using System.Collections.Generic;

using WarSISModelsDB.Models.Data;

namespace WarSISModelsDB.Models.DataBase
{
    public class Roles : ADataBase<Role>
    {
        public override string GetTableName() => TableName;
        public static String TableName => "Роли";

        public static String ID => "id";
        public static String Title => "title";

        public static Dictionary<String, (Type, Int32)> Fields = new Dictionary<String, (Type, Int32)>()
        {
            { ID, (typeof(Int32), 0) },
            { Title, (typeof(String), 25) },
        };
    }
}
