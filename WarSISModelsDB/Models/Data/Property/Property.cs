using System;

using WarSISDataBase.DataBase;

namespace WarSISModelsDB.Models.Data
{
    public class Property : AData<Property>
    {
        public Int32 ID { get; set; }
        public String Title { get; set; }
        public String Table { get; set; }
        public override Property GetElement(object[] Data) =>
            new Property()
            {
                ID = Data[0].ToInt32(),
                Title = Data[1].ToString(),
                Table = Data[2].ToString()
            };
    }
}
