
using WarSISDataBase.DataBase;

namespace WarSISModelsDB.Models.Data
{
    public class Tractor : AData<Tractor>, IProperty
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Inventary { get; set; }
        public float Weight { get; set; }
        public string Shassie { get; set; }
        public float Tank { get; set; }
        public string Fuel { get; set; }

        public override Tractor GetElement(object[] Data) =>
            new Tractor()
            {
                ID = Data[0].ToInt32(),
                Title = Data[1].ToString(),
                Inventary = Data[2].ToInt32(),
                Weight = (float)Data[3].ToDouble(),
                Shassie = Data[4].ToString(),
                Tank = (float)Data[5].ToDouble(),
                Fuel = Data[6].ToString(),
            };
    }
}
