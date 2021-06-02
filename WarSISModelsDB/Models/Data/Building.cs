using System;

namespace WarSISModelsDB.Models.Data
{
    public class Building : AData<Building>
    {
        public Int32 ID { get; set; }
        public String Title { get; set; }
        public String Address { get; set; }
        public Int32 WarChase { get; set; }
        public Int32 WarChaseID { get; set; }
        public override Building GetElement(object[] Data) =>
            new Building()
            {
                ID = Data[0].ToInt32(),
                Title = Data[1].ToString(),
                Address = Data[2].ToString(),
                WarChase = Data[3].ToInt32(),
                WarChaseID = Data[4].ToInt32(),
            };
    }
}
