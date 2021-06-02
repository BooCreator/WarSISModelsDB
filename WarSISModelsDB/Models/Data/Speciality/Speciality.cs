using System;

using WarSISDataBase.DataBase;

namespace WarSISModelsDB.Models.Data
{
    public class Speciality : AData<Speciality>
    {
        public Int32 ID { get; set; }
        public String Title { get; set; }

        public override Speciality GetElement(object[] Data) =>
            new Speciality()
            {
                ID = Data[0].ToInt32(),
                Title = Data[1].ToString(),
            };
    }
}
