using System;

namespace WarSISModelsDB.Models.Data
{
    public class OwnedSpeciality : AData<OwnedSpeciality>
    {
        public Int32 ID { get; set; }
        public Int32 People { get; set; }
        public Int32 Speciality { get; set; }

        public override OwnedSpeciality GetElement(object[] Data) =>
            new OwnedSpeciality()
            {
                ID = Data[0].ToInt32(),
                People = Data[1].ToInt32(),
                Speciality = Data[2].ToInt32()
            };
    }
}
