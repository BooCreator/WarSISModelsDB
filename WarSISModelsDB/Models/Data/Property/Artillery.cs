
using WarSISDataBase.DataBase;

namespace WarSISModelsDB.Models.Data
{
    public class Artillery : AData<Artillery>, IProperty
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Inventary { get; set; }
        public int Caliber { get; set; }
        public string Type { get; set; }

        public override Artillery GetElement(object[] Data) =>
            new Artillery()
            {
                ID = Data[0].ToInt32(),
                Title = Data[1].ToString(),
                Inventary = Data[2].ToInt32(),
                Caliber = Data[3].ToInt32(),
                Type = Data[4].ToString(),
            };
    }
}
