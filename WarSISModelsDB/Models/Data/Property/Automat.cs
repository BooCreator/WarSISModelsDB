using System;

using WarSISDataBase.DataBase;

namespace WarSISModelsDB.Models.Data
{
    public class Automat : AData<Automat>, IProperty
    {
        public Int32 ID { get; set; }
        public String Title { get; set; }
        public Int32 Inventary { get; set; }

        public override Automat GetElement(object[] Data) =>
            new Automat()
            {
                ID = Data[0].ToInt32(),
                Title = Data[1].ToString(),
                Inventary = Data[2].ToInt32()
            };
    }
}
