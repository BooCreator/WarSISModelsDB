using System;
using System.Collections.Generic;

using WarSISModelsDB.Models.Data;

namespace WarSISModelsDB.Models.DataBase
{
    public class Buildings : ADataBase<Building>
    {
        public override string GetTableName() => TableName;
        public static String TableName => "Сооружения";

        public static String ID => "id";
        public static String Title => "Название";
        public static String Address => "Адрес";
        public static String WarChase => "Военная часть";
        public static String WarChaseID => "ID_Военной части";

        public static Dictionary<String, (Type, Int32)> Fields = new Dictionary<String, (Type, Int32)>()
        {
            { ID, (typeof(Int32), 0) },
            { Title, (typeof(String), 50) },
            { Address, (typeof(String), 255) },
            { WarChase, (typeof(Int32), 0) },
            { WarChaseID, (typeof(Int32), 0) },
        };
    }
}