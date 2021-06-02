using System;
using System.Collections.Generic;

using WarSISDataBase.Args;

using WarSISModelsDB.Models.Data;

namespace WarSISModelsDB.Models.DataBase.Rank
{
    public class Majors : ADataBase<Major>, IDataBaseElement<IRank>, IDataBaseRanks
    {
        public override string GetTableName() => TableName;
        public static String TableName => "Майоры";

        public string PeopleName => People;
        public string DateName => Date;

        public static String People => "Человек";
        public static String Date => "Назначение";

        public static Dictionary<String, (Type, Int32)> Fields = new Dictionary<String, (Type, Int32)>()
        {
            { People, (typeof(Int32), 0) },
            { Date, (typeof(DateTime), 0) }
        };

        List<IRank> IDataBaseElement<IRank>.Select(string Where, List<ISelectArgs> Args)
        {
            List<IRank> Result = new List<IRank>();
            foreach(var Item in this.Select(Where, Args))
                Result.Add(Item as IRank);
            return Result;
        }
    }
}
