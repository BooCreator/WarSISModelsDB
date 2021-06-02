using System;
using System.Collections.Generic;

namespace WarSISModelsDB.Models.DataBase
{
    public class OwnedSpecialities : ADataBase<Data.OwnedSpeciality>
    {
        public override string GetTableName() => TableName;
        public static String TableName => "Владеемые специальности";

        public static String ID => "id";
        public static String People => "Человек";
        public static String Speciality => "Специальность";

        public static Dictionary<String, (Type, Int32)> Fields = new Dictionary<String, (Type, Int32)>()
        {
            { ID, (typeof(Int32), 0) },
            { People, (typeof(Int32), 0) },
            { Speciality, (typeof(Int32), 0) },
        };
    }
}
