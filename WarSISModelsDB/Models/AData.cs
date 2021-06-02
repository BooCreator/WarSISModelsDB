using System.Collections.Generic;
using System.Data;

using WarSISDataBase.DataBase;

namespace WarSISModelsDB.Models
{
    /// <summary>
    /// Базовый класс для всех данных сущностей БД
    /// реализующий метод интерфейса IDataElement для 
    /// нескольких элементов
    /// </summary>
    /// <typeparam name="T">Класс данных сущности</typeparam>
    public abstract class AData<T> : IDataElement<T> where T : class
    {
        public abstract T GetElement(object[] Data);

        public List<T> GetElements(DataTable Table)
        {
            List<T> Items = new List<T>();
            for (int i = 0; i < Table.Rows.Count; i++)
                Items.Add(GetElement(Table.Rows[i].ItemArray));
            return Items;
        }
    }
}
