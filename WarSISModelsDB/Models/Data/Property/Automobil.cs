
using WarSISDataBase.DataBase;

namespace WarSISModelsDB.Models.Data
{
    public class Automobil : AData<Automobil>, IProperty
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Inventary { get; set; }
        public int Peoples { get; set; }
        public float Tank { get; set; }
        public string Fuel { get; set; }

        public override Automobil GetElement(object[] Data) =>
            new Automobil()
            {
                ID = Data[0].ToInt32(),
                Title = Data[1].ToString(),
                Inventary = Data[2].ToInt32(),
                Peoples = Data[3].ToInt32(),
                Tank = (float)Data[4].ToDouble(),
                Fuel = Data[5].ToString(),
            };
    }
}
