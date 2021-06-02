using System;
using System.Collections.Generic;

using WarSISDataBase.Args;

using WarSISModelsDB.Models.Data;

namespace WarSISModelsDB.Models.DataBase.Subdivision
{
    public class Companies : ADataBase<Company>, IDataBaseSubdivisions, IDataBaseElement<ISubdivision>
    {
        public override string GetTableName() => TableName;
        public static String TableName => "Роты";

        public String IdName => ID;
        public String TitleName => Title;
        public String CommanderName => Commander;
        public String SubdivisionTableName => Subdivision;
        public String SubdivisionIDName => SubdivisionID;

        public static String ID => "id";
        public static String Title => "Название";
        public static String Commander => "Командир";
        public static String Subdivision => "Подразделение";
        public static String SubdivisionID => "ID_Подразделения";

        public static Dictionary<String, (Type, Int32)> Fields = new Dictionary<String, (Type, Int32)>()
        {
            { ID, (typeof(Int32), 0) },
            { Title, (typeof(String), 50) },
            { Commander, (typeof(Int32), 0) },
            { Subdivision, (typeof(Int32), 0) },
            { SubdivisionID, (typeof(Int32), 0) },
        };

        List<ISubdivision> IDataBaseElement<ISubdivision>.Select(string Where, List<ISelectArgs> Args)
        {
            List<ISubdivision> Result = new List<ISubdivision>();
            foreach (var Item in this.Select(Where, Args))
                Result.Add(Item as ISubdivision);
            return Result;
        }
    }
}