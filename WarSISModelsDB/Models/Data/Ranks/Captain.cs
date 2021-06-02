using System;

namespace WarSISModelsDB.Models.Data
{
    public class Captain : AData<Captain>, IRank
    {
        public int People { get; set; }
        public String Date { get; set; }

        public override Captain GetElement(object[] Data) =>
            new Captain()
            {
                People = Data[0].ToInt32(),
                Date = Data[1].ToString(),
            };
    }
}
