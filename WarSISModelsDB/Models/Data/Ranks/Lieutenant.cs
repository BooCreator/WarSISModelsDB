﻿using System;

namespace WarSISModelsDB.Models.Data
{
    public class Lieutenant : AData<Lieutenant>, IRank
    {
        public int People { get; set; }
        public String Date { get; set; }

        public override Lieutenant GetElement(object[] Data) =>
            new Lieutenant()
            {
                People = Data[0].ToInt32(),
                Date = Data[1].ToString(),
            };
    }
}
