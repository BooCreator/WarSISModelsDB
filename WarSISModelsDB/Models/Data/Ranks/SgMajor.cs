using System;

namespace WarSISModelsDB.Models.Data
{
    public class SgMajor : AData<SgMajor>, IRank
    {
        public int People { get; set; }
        public String Date { get; set; }

        public override SgMajor GetElement(object[] Data) =>
            new SgMajor()
            {
                People = Data[0].ToInt32(),
                Date = Data[1].ToString(),
            };
    }
}
