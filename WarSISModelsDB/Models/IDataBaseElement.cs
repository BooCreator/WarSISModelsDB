using System;
using System.Collections.Generic;
using System.Data;

using WarSISDataBase.Args;
using WarSISDataBase.DataBase;

namespace WarSISModelsDB.Models
{
    /// <summary>
    /// Интерфейс для классов сущностей БД
    /// с базовым функционалом каждого класса
    /// </summary>
    public interface IDataBaseElement
    {

        IDataBaseEditor Editor { get; set; }

        String GetTableName();
        String GetLastError();
        DataTable SelectData(String Where = "", List<ISelectArgs> Args = null);
        Boolean Insert(Dictionary<String, Object> Fields);
        Boolean Update(Dictionary<String, Object> Fields, String Where = "");
        Boolean Delete(String Where = "");
        Int32 Count(String Where = "");
        Int32 Max(String Field, String Where = "");
    }

    public interface IDataBaseElement<T>
    {
        List<T> Select(String Where = "", List<ISelectArgs> Args = null);
    }
}
