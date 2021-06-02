using System;

namespace WarSISModelsDB.Models.Data
{
    public class State : AData<State>
    {
        public Int32 ID { get; set; }
        public String Title { get; set; }

        public override State GetElement(object[] Data) =>
            new State()
            {
                ID = Data[0].ToInt32(),
                Title = Data[1].ToString(),
            };
    }
}
