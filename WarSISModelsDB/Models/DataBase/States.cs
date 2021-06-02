using System;
using System.Collections.Generic;

using WarSISModelsDB.Models.Data;

namespace WarSISModelsDB.Models.DataBase
{
    public class States : ADataBase<State>
    {
        public override string GetTableName() => TableName;
        public static String TableName => "Состояния";

        public static String ID => "id";
        public static String Title => "Название";

        public static Dictionary<String, (Type, Int32)> Fields = new Dictionary<String, (Type, Int32)>()
        {
            { ID, (typeof(Int32), 0) },
            { Title, (typeof(String), 50) },
        };
    }
}
