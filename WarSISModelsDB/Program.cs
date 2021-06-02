using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WarSISDataBase;
using WarSISDataBase.DataBase;
using WarSISDataBase.DataBase.Types;
using WarSISModelsDB.Models.DataBase;
using WarSISModelsDB.Models.DataBase.Subdivision;
using WarSISModelsDB.Models.DataBase.Property;

using WarSISModelsDB;
using WarSISModelsDB.Models;
using WarSISModelsDB.Models.Data;
using System.Reflection;

using System.Text.RegularExpressions;

namespace WarSISModelsDB
{

    class Program
    {

        static void Main(string[] args)
        {
            MSSQLEngine DB = new MSSQLEngine(@"Data Source=.\SQLEXPRESS;Initial Catalog=WarSIS_DB;Integrated Security=True");
            IDataBaseElement Data = new Branches()
            {
                Editor = DB,
            };
            Console.WriteLine(Data.Count());
            Console.WriteLine(Data.Max("id"));

            if (Data is IDataBaseSubdivisions subd)
            {
                Dictionary<string, object> Fields = new Dictionary<string, object>()
                    {
                        {subd.SubdivisionIDName, 0},
                        {subd.SubdivisionTableName, 1},
                    };
                if (!Data.Update(Fields, $"{subd.IdName} = {0}"))
                    Console.WriteLine(Data.GetLastError());
            }


            var Items = Ranks.Select(DB, Ranks.Table);
            var Error = Ranks.LastError;
            var ranks = new Ranks() { Editor = DB };
            var Items2 = ranks.Select();
            var Error2 = ranks.GetLastError();
            #region old

            /*Artilleries.Delete(DB, Artilleries.TableName);

            List<Dictionary<string, object>> Fields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Brigades.ID, 0 },
                    { Brigades.Title, "Армия-1" },
                    //{ Brigades.Commander, 0 },
                    { Brigades.Subdivision, 0 },
                    { Brigades.SubdivisionID, 0 }
                },
                new Dictionary<string, object>
                {
                    { Brigades.ID, 1 },
                    { Brigades.Title, "Армия-2" },
                    //{ Brigades.Commander, 0 },
                    { Brigades.Subdivision, 0 },
                    { Brigades.SubdivisionID, 0 }
                },
                new Dictionary<string, object>
                {
                    { Brigades.ID, 2 },
                    { Brigades.Title, "Армия-3" },
                    //{ Brigades.Commander, 0 },
                    { Brigades.Subdivision, 0 },
                    { Brigades.SubdivisionID, 0 }
                }
            };

            var iii = Peoples.SelectFirst(DB, Peoples.TableName);
            var iii2 = Subdivisions.SelectFirst(DB, Subdivisions.TableName, $"{Subdivisions.ID} = {iii.Subdivision}");
            IEnumerable<ISubdivision> Res1 = iii.GetSubdivision(DB, iii2.Table);
            var iii3 = Ranks.SelectFirst(DB, Ranks.TableName, $"{Ranks.ID} = {iii.Rank}");
            IEnumerable<IRank> Res2 = iii.GetRank(DB, iii3.Table);


            Console.ReadLine();

            
            Ranks Context = new Ranks
            {
                Editor = DB
            };
            Console.WriteLine("-----------------//-----------------");
            Console.WriteLine(Ranks.Count(DB, Ranks.TableName, $"{Ranks.ID} = 0"));

            Console.WriteLine("-----------------//-----------------");
            var Item = Context.SelectFirst();
            if(Item != null)
                Console.WriteLine($"{Item.ID} {Item.Table} {Item.Title} {Item.Upper}");

            Console.WriteLine("-----------------//-----------------");
            var Items = Context.Select($"{Ranks.ID} = 3");
            foreach(var item in Items)
            {
                Console.WriteLine($"{item.ID} {item.Table} {item.Title} {item.Upper}");
            }

            Console.WriteLine("-----------------//-----------------");

            var iii = PropertiesInSubdivissions.SelectFirst(DB, PropertiesInSubdivissions.TableName);
            var iii2 = Properties.SelectFirst(DB, Properties.TableName, $"{Properties.ID} = {iii.Property}");
            
            var iii3 = Subdivisions.SelectFirst(DB, Subdivisions.TableName, $"{Subdivisions.ID} = {iii.Subdivision}");

            IEnumerable<IProperty> Res = iii.GetProperty(DB, iii2.Table);

            foreach (var tmp in Res)
            {
                Console.WriteLine($"{tmp.ID} {tmp.Title} {tmp.Inventary}");
            }
            */
            #endregion

            //new Subdivisions().GetSubdivision()

            Console.ReadLine();
        }



    }
}
