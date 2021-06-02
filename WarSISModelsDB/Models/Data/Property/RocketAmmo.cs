
using WarSISDataBase.DataBase;

namespace WarSISModelsDB.Models.Data
{
    public class RocketAmmo : AData<RocketAmmo>, IProperty
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Inventary { get; set; }
        public string Cannons { get; set; }

        public override RocketAmmo GetElement(object[] Data) =>
            new RocketAmmo()
            {
                ID = Data[0].ToInt32(),
                Title = Data[1].ToString(),
                Inventary = Data[2].ToInt32(),
                Cannons = Data[3].ToString(),
            };
    }
}
