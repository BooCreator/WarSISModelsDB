using System;
using System.Collections.Generic;

using WarSISDataBase.Args;

using WarSISModelsDB.Models.Data;

namespace WarSISModelsDB.Models.DataBase.Property
{
    public class BMPs : ADataBase<BMP>, IDataBaseProperties, IDataBaseElement<IProperty>
    {
        public override string GetTableName() => TableName;
        public static String TableName => "БМП";

        public string IdName => ID;
        public string TitleName => Title;
        public string InventaryName => Inventary;

        public static String ID => "id";
        public static String Title => "Название";
        public static String Inventary => "Инв.номер";
        public static String Shassie => "Шасси";
        public static String Peoples => "Места";
        public static String Tank => "Литраж";
        public static String Fuel => "Топливо";

        public static Dictionary<String, (Type, Int32)> Fields = new Dictionary<String, (Type, Int32)>()
        {
            { ID, (typeof(Int32), 0) },
            { Title, (typeof(String), 50) },
            { Inventary, (typeof(Int32), 0) },
            { Shassie, (typeof(Int32), 0) },
            { Peoples, (typeof(Int32), 0) },
            { Tank, (typeof(Single), 0) },
            { Fuel, (typeof(String), 255) },
        };

        List<IProperty> IDataBaseElement<IProperty>.Select(string Where, List<ISelectArgs> Args)
        {
            List<IProperty> Result = new List<IProperty>();
            foreach(var Item in this.Select(Where, Args))
                Result.Add(Item as IProperty);
            return Result;
        }
    }
}