using System;
using System.Collections.Generic;

namespace WarSISModelsDB.Models
{
    /// <summary>
    /// Интерфейс для классов данных сущностей БД
    /// </summary>
    /// <typeparam name="T">Как правило класс ссылающийся на сам себя</typeparam>
    public interface IDataElement<T> where T : class
    {
        /// <summary>
        /// Метод создания класса из данных БД
        /// </summary>
        /// <param name="Data">Данные из БД</param>
        /// <returns></returns>
        T GetElement(Object[] Data);
        List<T> GetElements(System.Data.DataTable Table);
    }
}
