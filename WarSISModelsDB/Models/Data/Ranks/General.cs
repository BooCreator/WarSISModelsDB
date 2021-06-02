using System;

namespace WarSISModelsDB.Models.Data
{
    public class General : AData<General>, IRank
    {
        public int People { get; set; }
        public String Date { get; set; }

        public override General GetElement(object[] Data) =>
            new General()
            {
                People = Data[0].ToInt32(),
                Date = Data[1].ToString(),
            };
    }
}
