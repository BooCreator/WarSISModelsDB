
using WarSISDataBase.DataBase;

namespace WarSISModelsDB.Models.Data
{
    public class Carabin : AData<Carabin>, IProperty
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Inventary { get; set; }

        public override Carabin GetElement(object[] Data) =>
            new Carabin()
            {
                ID = Data[0].ToInt32(),
                Title = Data[1].ToString(),
                Inventary = Data[2].ToInt32()
            };
    }
}
