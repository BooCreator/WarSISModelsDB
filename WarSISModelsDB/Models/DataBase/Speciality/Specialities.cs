using System;
using System.Collections.Generic;

namespace WarSISModelsDB.Models.DataBase
{
    public class Specialities : ADataBase<Data.Speciality>
    {
        public override string GetTableName() => TableName;
        public static String TableName => "Специальности";

        public static String ID => "id";
        public static String Title => "Название";

        public static Dictionary<String, (Type, Int32)> Fields = new Dictionary<String, (Type, Int32)>()
        {
            { ID, (typeof(Int32), 0) },
            { Title, (typeof(String), 50) },
        };
    }
}
