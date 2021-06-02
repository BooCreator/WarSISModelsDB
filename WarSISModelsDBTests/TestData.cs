using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WarSISDataBase;
using WarSISDataBase.DataBase;

namespace WarSISModelsDBTests
{
    public static class TestData
    {
        public static IDataBaseEditor Editor =
            new MSSQLEngine(@"Data Source=.\SQLEXPRESS;Initial Catalog=WarSIS_TestDB;Integrated Security=True");
    }
}
