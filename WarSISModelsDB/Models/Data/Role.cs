using System;

namespace WarSISModelsDB.Models.Data
{
    public class Role : AData<Role>
    {
        public Int32 ID { get; set; }
        public String Title { get; set; }

        public override Role GetElement(object[] Data) =>
            new Role()
            {
                ID = Data[0].ToInt32(),
                Title = Data[1].ToString(),
            };
    }
}
