using System;
using System.Collections.Generic;

using WarSISModelsDB.Models.Data;

namespace WarSISModelsDB.Models.DataBase
{
    public class Users : ADataBase<User>
    {
        public override string GetTableName() => TableName;
        public static String TableName => "Пользователи";

        public static String ID => "id";
        public static String Login => "login";
        public static String Password => "password";
        public static String People => "people";
        public static String Role => "role";

        public static Dictionary<String, (Type, Int32)> Fields = new Dictionary<String, (Type, Int32)>()
        {
            { ID, (typeof(Int32), 0) },
            { Login, (typeof(String), 40) },
            { Password, (typeof(String), 40) },
            { Role, (typeof(Int32), 0) },
        };
    }
}
