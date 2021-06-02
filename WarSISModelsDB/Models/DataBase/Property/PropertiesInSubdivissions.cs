using System;
using System.Collections.Generic;

using WarSISDataBase.Args;

using WarSISModelsDB.Models.Data;
using WarSISModelsDB.Models.DataBase.Property;

namespace WarSISModelsDB.Models.DataBase
{
    public class PropertiesInSubdivissions : ADataBase<PropertyInSubdivision>
    {
        public override string GetTableName() => TableName;
        public static String TableName => "Имущество в подразделениях";

        public static String Property => "Имущество";
        public static String PropertyID => "ID_имущества";
        public static String Subdivision => "Подразделение";
        public static String SubdivisionID => "ID_подразделения";

        public static Dictionary<String, (Type, Int32)> Fields = new Dictionary<String, (Type, Int32)>()
        {
            { Property, (typeof(Int32), 0) },
            { PropertyID, (typeof(Int32), 0) },
            { Subdivision, (typeof(Int32), 0) },
            { SubdivisionID, (typeof(Int32), 0) },
        };

    }
}