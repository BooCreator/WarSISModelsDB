using System;

namespace WarSISModelsDB.Models.Data
{
    public class Corporal : AData<Corporal>, IRank
    {
        public int People { get; set; }
        public String Date { get; set; }

        public override Corporal GetElement(object[] Data) =>
            new Corporal()
            {
                People = Data[0].ToInt32(),
                Date = Data[1].ToString(),
            };
    }
}
