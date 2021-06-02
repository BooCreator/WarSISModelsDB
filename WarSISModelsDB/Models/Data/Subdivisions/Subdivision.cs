using System;

using WarSISDataBase.DataBase;

namespace WarSISModelsDB.Models.Data
{
    public class Subdivision : AData<Subdivision>
    {
        public Int32 ID { get; set; }
        public String Title { get; set; }
        public String Table { get; set; }
        public String Upper { get; set; }
        public override Subdivision GetElement(object[] Data) =>
            new Subdivision()
            {
                ID = Data[0].ToInt32(),
                Title = Data[1].ToString(),
                Table = Data[2].ToString(),
                Upper = Data[3].ToString()
            };
    }
}
