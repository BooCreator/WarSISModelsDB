using System;

namespace WarSISModelsDB.Models.Data
{
    public class LtColonel : AData<LtColonel>, IRank
    {
        public int People { get; set; }
        public String Date { get; set; }

        public override LtColonel GetElement(object[] Data) =>
            new LtColonel()
            {
                People = Data[0].ToInt32(),
                Date = Data[1].ToString(),
            };
    }
}
