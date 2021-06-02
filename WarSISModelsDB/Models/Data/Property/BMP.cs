
using WarSISDataBase.DataBase;

namespace WarSISModelsDB.Models.Data
{
    public class BMP : AData<BMP>, IProperty
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Inventary { get; set; }
        public string Shassie { get; set; }
        public int Peoples { get; set; }
        public float Tank { get; set; }
        public string Fuel { get; set; }

        public override BMP GetElement(object[] Data) =>
            new BMP()
            {
                ID = Data[0].ToInt32(),
                Title = Data[1].ToString(),
                Inventary = Data[2].ToInt32(),
                Shassie = Data[3].ToString(),
                Peoples = Data[4].ToInt32(),
                Tank = (float)Data[5].ToDouble(),
                Fuel = Data[6].ToString(),
            };
    }
}
