using System;

namespace WarSISModelsDB.Models.Data
{
    public class Colonel : AData<Colonel>, IRank
    {
        public int People { get; set; }
        public String Date { get; set; }

        public override Colonel GetElement(object[] Data) =>
            new Colonel()
            {
                People = Data[0].ToInt32(),
                Date = Data[1].ToString(),
            };
    }
}
