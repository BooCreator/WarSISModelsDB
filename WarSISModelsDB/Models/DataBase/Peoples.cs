using System;
using System.Collections.Generic;

using WarSISModelsDB.Models.Data;

using static System.Net.Mime.MediaTypeNames;

namespace WarSISModelsDB.Models.DataBase
{
    public class Peoples : ADataBase<People>
    {
        public override string GetTableName() => TableName;
        public static String TableName => "Люди";

        public static String ID => "id";
        public static String Name => "Имя";
        public static String Rank => "Звание";
        public static String Photo => "Фотография";
        public static String Subdivision => "Подразделение";
        public static String SubdivisionID => "ID_Подразделения";
        public static String State => "Состояние";

        public static Dictionary<String, (Type, Int32)> Fields = new Dictionary<String, (Type, Int32)>()
        {
            { ID, (typeof(Int32), 0) },
            { Name, (typeof(String), 50) },
            { Rank, (typeof(Int32), 0) },
            { Photo, (typeof(Image), 0) },
            { Subdivision, (typeof(Int32), 0) },
            { SubdivisionID, (typeof(Int32), 0) },
            { State, (typeof(Int32), 0) },
        };
    }
}