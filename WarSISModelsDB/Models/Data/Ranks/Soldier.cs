using System;

namespace WarSISModelsDB.Models.Data
{
    public class Soldier : AData<Soldier>, IRank
    {
        public int People { get; set; }
        public String Date { get; set; }

        public override Soldier GetElement(object[] Data) =>
            new Soldier()
            {
                People = Data[0].ToInt32(),
                Date = Data[1].ToString(),
            };
    }
}
