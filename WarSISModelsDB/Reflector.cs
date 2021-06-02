using System;
using System.Collections.Generic;

using WarSISDataBase;
using WarSISDataBase.DataBase;
using WarSISDataBase.DataBase.Types;
using WarSISModelsDB.Models.DataBase;

using WarSISModelsDB;
using WarSISModelsDB.Models;
using WarSISModelsDB.Models.Data;
using System.Reflection;

namespace WarSISModelsDB
{
    public static class Reflector
    {
        private static List<Type> PropertyTypes = new List<Type>();
        private static List<Type> SubdivisionTypes = new List<Type>();
        private static List<Type> RankTypes = new List<Type>();
        static Reflector()
        {
            var asm = Assembly.Load("WarSISModelsDB");
            List<Type> Types = new List<Type>();
            Types.AddRange(asm.GetTypes());
            PropertyTypes = Types.FindAll(x => x.FullName.IndexOf("WarSISModelsDB.Models.DataBase.Property") == 0);
            SubdivisionTypes = Types.FindAll(x => x.FullName.IndexOf("WarSISModelsDB.Models.DataBase.Subdivision") == 0);
            RankTypes = Types.FindAll(x => x.FullName.IndexOf("WarSISModelsDB.Models.DataBase.Rank") == 0);
        }

        /// <summary>
        /// Обобщённый метод для получения данных из связанноq сущности
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="DB">Редактор БД</param>
        /// <param name="Array">Массив с типами в котором нужно искать сущность</param>
        /// <param name="TableName">Название сущности в TableName</param>
        /// <param name="ID_Value">ID элемента из сущности</param>
        /// <returns></returns>
        private static IEnumerable<T> GetType<T>(IDataBaseEditor DB, List<Type> Array, String TableName, Int32 ID_Value = -1, String ID_Name = "ID") where T : class
        {
            IEnumerable<T> Res = null;
            Type Type = null;
            foreach (var itm in Array)
            {
                var prop = itm.GetProperty("TableName", BindingFlags.Public | BindingFlags.Static)?.GetValue(null, null).ToString().ToUpper();
                if (prop != null && prop.CompareTo($"{TableName.ToUpper()}") == 0)
                    Type = itm;
            }
            if (Type != null)
            {
                MethodInfo method = Type.GetMethod("Select", BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Static);
                if (method != null)
                {
                    string where = $"[{Type.GetProperty(ID_Name, BindingFlags.Public | BindingFlags.Static).GetValue(null, null)}] = {ID_Value}";
                    // создаём объект обобщённого типа
                    object Class = Activator.CreateInstance(Type);

                    object result = method.Invoke(Class, new object[] { DB, 
                        Type.GetProperty("TableName", BindingFlags.Public |BindingFlags.Static).GetValue(null, null),
                        ((ID_Value > -1) ? where : "") , null});
                    Res = (result as IEnumerable<T>);
                }
            }
            return Res;
        }

        /// <summary>
        /// Обобщённый метод для получения сущности базы данных по названию таблицы
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Array"></param>
        /// <param name="TableName"></param>
        /// <returns></returns>
        private static T GetType<T>(List<Type> Array, String TableName) where T : class
        {
            Type Type = null;
            foreach (var itm in Array)
            {
                var prop = itm.GetProperty("TableName", BindingFlags.Public | BindingFlags.Static)?.GetValue(null, null).ToString().ToUpper();
                if (prop != null && prop.CompareTo($"{TableName.ToUpper()}") == 0)
                    Type = itm;
            }
            return Activator.CreateInstance(Type) as T;
        }

        // to PropertyInSubdivision
        public static IEnumerable<IProperty> GetProperty(this PropertyInSubdivision Item, IDataBaseEditor DB, String PropertyTableName)
        {
            return GetType<IProperty>(DB, PropertyTypes, PropertyTableName, Item.PropertyID);
        }
        public static IEnumerable<ISubdivision> GetSubdivision(this PropertyInSubdivision Item, IDataBaseEditor DB, String SubdivisionTableName)
        {
            return GetType<ISubdivision>(DB, SubdivisionTypes, SubdivisionTableName, Item.SubdivisionID);
        }

        // to Subdivisions
        public static IEnumerable<ISubdivision> GetUpper(this ISubdivision Item, IDataBaseEditor DB, String SubdivisionTableName)
        {
            return GetType<ISubdivision>(DB, SubdivisionTypes, SubdivisionTableName, Item.SubdivisionID);
        }

        // to People
        public static IEnumerable<ISubdivision> GetSubdivision(this People Item, IDataBaseEditor DB, String SubdivisionTableName)
        {
            return GetType<ISubdivision>(DB, SubdivisionTypes, SubdivisionTableName, Item.SubdivisionID);
        }
        public static IEnumerable<IRank> GetRank(this People Item, IDataBaseEditor DB, String RankTableName)
        {
            return GetType<IRank>(DB, RankTypes, RankTableName, Item.ID, ID_Name: "People");
        }

        // to Building
        public static IEnumerable<ISubdivision> GetWarChase(this Building Item, IDataBaseEditor DB, String WarChaseTableName)
        {
            return GetType<ISubdivision>(DB, SubdivisionTypes, WarChaseTableName, Item.WarChaseID);
        }
    
        // to Basic Tables

        public static IDataBaseElement GetSubdivision(this Subdivisions Item, String SubdivisionTableName)
        {
            var Elem = GetType<IDataBaseElement>(SubdivisionTypes, SubdivisionTableName);
            Elem.Editor = Item.Editor;
            return Elem;
        }
        public static IDataBaseElement GetProperty(this Properties Item, String PropertyTableName)
        {
            var Elem = GetType<IDataBaseElement>(PropertyTypes, PropertyTableName);
            Elem.Editor = Item.Editor;
            return Elem;
        }
        public static IDataBaseElement GetRank(this Ranks Item, String RankTableName)
        {
            var Elem = GetType<IDataBaseElement>(RankTypes, RankTableName);
            Elem.Editor = Item.Editor;
            return Elem;
        }
    
        // extension

        //public static IDataBaseElement GetSubdivision(this People People)

    }
}
