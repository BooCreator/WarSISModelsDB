using System;

namespace WarSISModelsDB.Models.Data
{
    public class Ensign : AData<Ensign>, IRank
    {
        public int People { get; set; }
        public String Date { get; set; }

        public override Ensign GetElement(object[] Data) =>
            new Ensign()
            {
                People = Data[0].ToInt32(),
                Date = Data[1].ToString(),
            };
    }
}
