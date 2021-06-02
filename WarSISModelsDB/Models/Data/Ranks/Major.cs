using System;

namespace WarSISModelsDB.Models.Data
{
    public class Major : AData<Major>, IRank
    {
        public int People { get; set; }
        public String Date { get; set; }

        public override Major GetElement(object[] Data) =>
            new Major()
            {
                People = Data[0].ToInt32(),
                Date = Data[1].ToString(),
            };
    }
}
