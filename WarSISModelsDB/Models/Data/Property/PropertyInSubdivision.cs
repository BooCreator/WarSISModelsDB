
using System;
using System.Reflection;
using System.Collections.Generic;

using WarSISModelsDB.Models.DataBase.Property;
using WarSISDataBase.DataBase;

namespace WarSISModelsDB.Models.Data
{
    public class PropertyInSubdivision : AData<PropertyInSubdivision>
    {

        public Int32 Property { get; set; }
        public Int32 PropertyID { get; set; }
        public Int32 Subdivision { get; set; }
        public Int32 SubdivisionID { get; set; }

        public override PropertyInSubdivision GetElement(object[] Data)
        {
            #region aaa
            /*
            Property Item = Properties.SelectFirst(null, Properties.TableName, $"{Properties.ID} = {Data[2]}");
            if(Item != null)
            {
                Type Type = PropertyTypes.Find(
                    x => x.GetProperty("TableName", BindingFlags.Static)
                    .GetValue(null, null).ToString().ToUpper()
                    .CompareTo($"{Item.Table.Replace("[", "").Replace("]", "").ToUpper()}") == 0);
                if(Type != null)
                {
                    MethodInfo method = Type.GetMethod("SelectFirst", BindingFlags.Static);
                    if (method != null)
                    {
                        // создаём объект обобщённого типа
                        object Class = Activator.CreateInstance(Type);
                        object result = method.Invoke(Class, new object[] { null, Item.Table, 
                            $"{Type.GetProperty("ID", BindingFlags.Static).GetValue(null, null)} = {Data[3]}" });
                        Property = (result as IProperty);
                    }
                }
            
             }
            */
            #endregion
            
            return new PropertyInSubdivision()
            {
                Property = Data[0].ToInt32(),
                PropertyID = Data[1].ToInt32(),
                Subdivision = Data[2].ToInt32(),
                SubdivisionID = Data[3].ToInt32()
            };
        }
    }
}
