using System;

namespace WarSISModelsDB.Models.Data
{
    /// <summary>
    /// Класс данных сущности БД - Звания
    /// </summary>
    public class Rank : AData<Rank>
    {
        public Int32 ID { get; set; }
        public String Title { get; set; }
        public String Table { get; set; }
        public Int32 Upper { get; set; }

        public override Rank GetElement(object[] Data) =>
            new Rank()
            {
                ID = Data[0].ToInt32(),
                Title = Data[1].ToString(),
                Table = Data[2].ToString(),
                Upper = Data[3].ToInt32(),
            };
    }
}
