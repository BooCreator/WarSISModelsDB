using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

using WarSISDataBase.Args;
using WarSISDataBase.DataBase;

namespace WarSISModelsDB.Models
{
    /// <summary>
    /// Базовый класс для всех классов сущностей БД
    /// Реализует базовый функционал всех методов интерфейса IDataBaseElement
    /// </summary>
    /// <typeparam name="T">Класс данных сущностей БД</typeparam>
    public abstract class ADataBase<T> : IDataBaseElement where T : class
    {
        // Чтобы бызовые методы работали исправно каждый наследник
        // должен реализовать метод с получением названия привязанной БД
        public abstract String GetTableName();
        public String GetLastError() => LastError;
        public static String LastError { get; set; }
        public IDataBaseEditor Editor { get; set; }

        public T SelectFirst(String Where = "") 
            => SelectFirst(Editor, GetTableName(), Where);

        // реализуем интерфейс просто ссылаясь на статические методы
        public List<T> Select(String Where = "", List<ISelectArgs> Args = null)
            => Select(Editor, GetTableName(), Where, Args);
        public DataTable SelectData(String Where = "", List<ISelectArgs> Args = null)
            => SelectData(Editor, GetTableName(), Where, Args);
        public Boolean Insert(Dictionary<String, Object> Fields)
            => Insert(Editor, GetTableName(), Fields);
        public Boolean Update(Dictionary<String, Object> Fields, String Where = "")
            => Update(Editor, GetTableName(), Fields, Where);
        public Boolean Delete(String Where = "")
            => Delete(Editor, GetTableName(), Where);
        public Int32 Count(String Where = "")
            => Count(Editor, GetTableName(), Where);
        public Int32 Max(String Field, String Where = "")
            => Max(Editor, GetTableName(), Field, Where);

        public static T SelectFirst(IDataBaseEditor Editor, String Table, String Where = "")
        {
            var data = Select(Editor, Table, Where, new List<ISelectArgs>() { new TOP(1) });
            return (data.Count > 0) ? data[0] as T : null;
        }
        public static List<T> Select(IDataBaseEditor Editor, String Table, String Where = "", List<ISelectArgs> Args = null)
            => FromDataTable(SelectData(Editor, Table, Where, Args));

        public static List<T> FromDataTable(DataTable Data)
        {
            try
            {
                // с помощью рефлексии получаем обобщённый тип
                Type type = typeof(T);
                // получаем интерфейсы типа
                var Types = new List<Type>();
                Types.AddRange(type.GetInterfaces());
                // проверяем чтобы тип реализовывал интерфейс класса данных сущности БД
                Type Interface = Types.Find(x => x.Name.IndexOf("IDataElement") == 0);
                if (Interface != null)
                {
                    // получаем список методов интерфейса. Вдруг поменялись названия
                    foreach (MethodInfo Method in Interface.GetMethods())
                    {
                        // получаем список параметров метода
                        var Parameters = new List<ParameterInfo>();
                        Parameters.AddRange(Method.GetParameters());
                        // првоеряем чтобы метод принимал значение DataTable, так как его мы получаем из БД
                        ParameterInfo ParameterType = Parameters.Find(x => x.ParameterType.Name.IndexOf("DataTable") == 0);
                        if (ParameterType != null && Parameters.Count == 1)
                        {
                            // если всё в порядке, то получаем метод из типа
                            MethodInfo method = type.GetMethod(Method.Name);
                            if (method != null)
                            {
                                // создаём объект обобщённого типа
                                object Class = Activator.CreateInstance(type);
                                // вызываем у него метод
                                object result = method.Invoke(Class, new object[] { Data });
                                // возвращаем результат
                                return (result as List<T>);
                            }
                        }
                    }
                }
                return new List<T>();
            }
            catch (Exception e) { LastError = e.Message; return new List<T>(); }

        }
        public static DataTable SelectData(IDataBaseEditor Editor, String Table, String Where = "", List<ISelectArgs> Args = null)
        {
            try
            {
                if(Editor == null)  throw new Exception("Editor не задан!");
                return Editor.Select(new List<string> { "*" }, Table, Where, Args);
            } catch (Exception e) { LastError = e.Message; return new DataTable(); }
            
        }
        public static Boolean Insert(IDataBaseEditor Editor, String Table, Dictionary<String, Object> Fields)
        {
            try
            {
                if (Editor == null) throw new Exception("Editor не задан!");
                Editor.Insert(Fields, Table);
                return true;
            }
            catch (Exception e) { LastError = e.Message; return false; }
        }
        public static Boolean Update(IDataBaseEditor Editor, String Table, Dictionary<String, Object> Fields, String Where = "")
        {
            try
            {
                if (Editor == null) throw new Exception("Editor не задан!");
                Editor.Update(Fields, Table, Where);
                return true;
            }
            catch (Exception e) { LastError = e.Message; return false; }
        }
        public static Boolean Delete(IDataBaseEditor Editor, String Table, String Where = "")
        {
            try
            {
                if (Editor == null) throw new Exception("Editor не задан!");
                Editor.Delete(Table, Where);
                return true;
            }
            catch (Exception e) { LastError = e.Message; return false; }
        }

        public static Int32 Count(IDataBaseEditor Editor, String Table, String Where = "")
        {
            try
            {
                if (Editor == null) throw new Exception("Editor не задан!");
                var res = Editor.Select(new List<string>(), Table, Where, new List<ISelectArgs>() { new COUNT("*", false) });
                return res.Rows[0].ItemArray[0].ToInt32();
            }
            catch (Exception e) { LastError = e.Message; return -1; }
        }

        public static Int32 Max(IDataBaseEditor Editor, String Table, String Field, String Where = "")
        {
            try
            {
                if (Editor == null) throw new Exception("Editor не задан!");
                return Editor.Select(new List<string>(), Table, Where, new List<ISelectArgs>() { new MAX(Field) }).Rows[0].ItemArray[0].ToInt32();
            }
            catch (Exception e) { LastError = e.Message; return -1; }
        }

    }
}
