using System;

namespace WarSISModelsDB.Models.Data
{
    public class People : AData<People>
    {
        public Int32 ID { get; set; }
        public String Name { get; set; }
        public Int32 Rank { get; set; }
        public Object Photo { get; set; }
        public Int32 Subdivision { get; set; }
        public Int32 SubdivisionID { get; set; }
        public Int32 State { get; set; }

        public override People GetElement(object[] Data) =>
            new People()
            {
                ID = Data[0].ToInt32(),
                Name = Data[1].ToString(),
                Rank = Data[2].ToInt32(),
                Photo = Data[3],
                Subdivision = Data[4].ToInt32(),
                SubdivisionID = Data[5].ToInt32(),
                State = Data[6].ToInt32(),
            };
    }
}
