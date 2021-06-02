
using WarSISDataBase.DataBase;

namespace WarSISModelsDB.Models.Data
{
    public class Division : AData<Division>, ISubdivision
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Commander { get; set; }
        public int Subdivision { get; set; }
        public int SubdivisionID { get; set; }

        public override Division GetElement(object[] Data) =>
            new Division()
            {
                ID = Data[0].ToInt32(),
                Title = Data[1].ToString(),
                Commander = Data[2].ToInt32(),
                Subdivision = Data[3].ToInt32(),
                SubdivisionID = Data[4].ToInt32(),
            };
    }
}
