using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;

using WarSISModelsDB;
using WarSISModelsDB.Models;
using WarSISModelsDB.Models.Data;
using WarSISModelsDB.Models.DataBase;
using WarSISModelsDB.Models.DataBase.Subdivision;
using WarSISModelsDB.Models.DataBase.Rank;
using WarSISModelsDB.Models.DataBase.Property;

namespace WarSISModelsDBTests
{
    [TestClass]
    public class ExtensionTest
    {
        [TestMethod]
        public void ObjectConvertTest()
        {
            string Int = "12";
            string Double = "12.1";
            string Error1 = "12a";
            string Error2 = "a12";

            Assert.AreEqual(Int.ToInt32(), 12);
            Assert.AreEqual(Double.ToDouble(), 12.1);
            Assert.AreEqual(Error1.ToInt32(), -1);
            Assert.AreEqual(Error2.ToInt32(), -1);
            Assert.AreEqual(Error1.ToDouble(), -1);
            Assert.AreEqual(Error2.ToDouble(), -1);

        }
        [TestMethod]
        public void PropertiesInSubdivissionsTest()
        {
            Assert.IsTrue(PropertiesInSubdivissions.Delete(TestData.Editor, PropertiesInSubdivissions.TableName));

            #region init

            List<Dictionary<string, object>> ArtilleryFields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Artilleries.ID, 0 },
                    { Artilleries.Title, "ЗиС-1" },
                    { Artilleries.Inventary, 12345678 }
                },
                new Dictionary<string, object>
                {
                    { Artilleries.ID, 1 },
                    { Artilleries.Title, "ЗиС-2" },
                    { Artilleries.Inventary, 87654321 }
                },
                new Dictionary<string, object>
                {
                    { Artilleries.ID, 2 },
                    { Artilleries.Title, "ЗиС-3" },
                    { Artilleries.Inventary, 87656781 }
                }
            };
            Assert.IsTrue(Artilleries.Delete(TestData.Editor, Artilleries.TableName));
            foreach (var Field in ArtilleryFields)
                Assert.IsTrue(Artilleries.Insert(TestData.Editor, Artilleries.TableName, Field));

            List<Dictionary<string, object>> ArmyFields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Armies.ID, 0 },
                    { Armies.Title, "Армия-1" },
                    //{ Armies.Commander, 0 },
                    { Armies.Subdivision, -1 },
                    { Armies.SubdivisionID, -1 }
                },
                new Dictionary<string, object>
                {
                    { Armies.ID, 1 },
                    { Armies.Title, "Армия-2" },
                    //{ Armies.Commander, -1 },
                    { Armies.Subdivision, -1 },
                    { Armies.SubdivisionID, -1 }
                },
                new Dictionary<string, object>
                {
                    { Armies.ID, 2 },
                    { Armies.Title, "Армия-3" },
                    //{ Armies.Commander, -1 },
                    { Armies.Subdivision, -1 },
                    { Armies.SubdivisionID, -1 }
                }
            };
            Assert.IsTrue(Armies.Delete(TestData.Editor, Armies.TableName));
            foreach (var Field in ArmyFields)
                Assert.IsTrue(Armies.Insert(TestData.Editor, Armies.TableName, Field));

            List<Dictionary<string, object>> PropertyFields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Properties.ID, 0 },
                    { Properties.Title, "Название 1" },
                    { Properties.Table, "Талица 1" },
                },
                new Dictionary<string, object>
                {
                    { Properties.ID, 1 },
                    { Properties.Title, "Название 2" },
                    { Properties.Table, Artilleries.TableName },
                }
            };
            Properties.Delete(TestData.Editor, Properties.TableName);
            foreach (var Field in PropertyFields)
                Assert.IsTrue(Properties.Insert(TestData.Editor, Properties.TableName, Field));

            List<Dictionary<string, object>> SubdivisionFields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Subdivisions.ID, 0 },
                    { Subdivisions.Title, "Название 1" },
                    { Subdivisions.Table, Armies.TableName},
                },
                new Dictionary<string, object>
                {
                    { Subdivisions.ID, 1 },
                    { Subdivisions.Title, "Название 2" },
                    { Subdivisions.Table, Battalions.TableName },
                }
            };
            Assert.IsTrue(Subdivisions.Delete(TestData.Editor, Subdivisions.TableName));
            foreach (var Field in SubdivisionFields)
                Assert.IsTrue(Subdivisions.Insert(TestData.Editor, Subdivisions.TableName, Field));

            List<Dictionary<string, object>> Fields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { PropertiesInSubdivissions.Property, 1 },
                    { PropertiesInSubdivissions.PropertyID, 0 },
                    { PropertiesInSubdivissions.Subdivision, 0 },
                    { PropertiesInSubdivissions.SubdivisionID, 0 },
                },
                new Dictionary<string, object>
                {
                    { PropertiesInSubdivissions.Property, 1 },
                    { PropertiesInSubdivissions.PropertyID, 2 },
                    { PropertiesInSubdivissions.Subdivision, 0 },
                    { PropertiesInSubdivissions.SubdivisionID, 1 },
                }
            };
            foreach (var Field in Fields)
                Assert.IsTrue(PropertiesInSubdivissions.Insert(TestData.Editor, PropertiesInSubdivissions.TableName, Field));

            #endregion

            var iii = PropertiesInSubdivissions.SelectFirst(TestData.Editor, PropertiesInSubdivissions.TableName, $"{PropertiesInSubdivissions.Subdivision} = 0");
            var iii2 = Properties.SelectFirst(TestData.Editor, Properties.TableName, $"{Properties.ID} = {iii.Property}");
            IEnumerable<IProperty> Res1 = iii.GetProperty(TestData.Editor, iii2.Table);

            iii = PropertiesInSubdivissions.SelectFirst(TestData.Editor, PropertiesInSubdivissions.TableName, $"{PropertiesInSubdivissions.PropertyID} = 2");
            var iii3 = Subdivisions.SelectFirst(TestData.Editor, Subdivisions.TableName, $"{Subdivisions.ID} = {iii.Subdivision}");
            IEnumerable<ISubdivision> Res2 = iii.GetSubdivision(TestData.Editor, iii3.Table);

            foreach (var tmp in Res1)
            {
                Assert.AreEqual(tmp.Title, ArtilleryFields[0][Artilleries.Title]);
                Assert.AreEqual(tmp.Inventary, ArtilleryFields[0][Artilleries.Inventary]);
            }
            foreach (var tmp in Res2)
            {
                Assert.AreEqual(tmp.Title, ArmyFields[1][Armies.Title]);
            }

            Assert.IsTrue(Artilleries.Delete(TestData.Editor, Artilleries.TableName));
            Assert.IsTrue(Armies.Delete(TestData.Editor, Armies.TableName));
            Assert.IsTrue(PropertiesInSubdivissions.Delete(TestData.Editor, PropertiesInSubdivissions.TableName));
            Assert.IsTrue(Properties.Delete(TestData.Editor, Properties.TableName));
            Assert.IsTrue(Subdivisions.Delete(TestData.Editor, Subdivisions.TableName));
        }
        [TestMethod]
        public void SubdivisionTest()
        {
            Assert.IsTrue(Subdivisions.Delete(TestData.Editor, Subdivisions.TableName));

            List<Dictionary<string, object>> SubdivisionFields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Subdivisions.ID, 0 },
                    { Subdivisions.Title, "Армии" },
                    { Subdivisions.Table, Armies.TableName},
                },
                new Dictionary<string, object>
                {
                    { Subdivisions.ID, 1 },
                    { Subdivisions.Title, "Баттальоны" },
                    { Subdivisions.Table, Battalions.TableName },
                }
            };
            Assert.IsTrue(Subdivisions.Delete(TestData.Editor, Subdivisions.TableName));
            foreach (var Field in SubdivisionFields)
                Assert.IsTrue(Subdivisions.Insert(TestData.Editor, Subdivisions.TableName, Field));

            List<Dictionary<string, object>> ArmyFields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Armies.ID, 0 },
                    { Armies.Title, "Армия-1" },
                    //{ Armies.Commander, 0 },
                    { Armies.Subdivision, -1 },
                    { Armies.SubdivisionID, -1 }
                },
                new Dictionary<string, object>
                {
                    { Armies.ID, 1 },
                    { Armies.Title, "Армия-2" },
                    //{ Armies.Commander, -1 },
                    { Armies.Subdivision, -1 },
                    { Armies.SubdivisionID, -1 }
                }
            };
            Assert.IsTrue(Armies.Delete(TestData.Editor, Armies.TableName));
            foreach (var Field in ArmyFields)
                Assert.IsTrue(Armies.Insert(TestData.Editor, Armies.TableName, Field));

            List<Dictionary<string, object>> BattalionFields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Battalions.ID, 0 },
                    { Battalions.Title, "Батальон-1" },
                    //{ Armies.Commander, 0 },
                    { Battalions.Subdivision, 0 },
                    { Battalions.SubdivisionID, 0 }
                },
                new Dictionary<string, object>
                {
                    { Battalions.ID, 1 },
                    { Battalions.Title, "Батальон-2" },
                    //{ Armies.Commander, -1 },
                    { Battalions.Subdivision, 0 },
                    { Battalions.SubdivisionID, 1 }
                }
            };
            Assert.IsTrue(Battalions.Delete(TestData.Editor, Battalions.TableName));
            foreach (var Field in BattalionFields)
                Assert.IsTrue(Battalions.Insert(TestData.Editor, Battalions.TableName, Field));


            var iii = Battalions.SelectFirst(TestData.Editor, Battalions.TableName, $"{Battalions.ID} = 1");
            var iii2 = Subdivisions.SelectFirst(TestData.Editor, Subdivisions.TableName, $"{Subdivisions.ID} = {iii.Subdivision}");
            IEnumerable<ISubdivision> Res = iii.GetUpper(TestData.Editor, iii2.Table);

            foreach (var tmp in Res)
            {
                Assert.AreEqual(tmp.Title, ArmyFields[1][Armies.Title]);
            }

            Assert.IsTrue(Armies.Delete(TestData.Editor, Armies.TableName));
            Assert.IsTrue(Battalions.Delete(TestData.Editor, Battalions.TableName));
            Assert.IsTrue(Subdivisions.Delete(TestData.Editor, Subdivisions.TableName));
        }
        [TestMethod]
        public void PeopleTest()
        {
            Assert.IsTrue(Armies.Delete(TestData.Editor, Armies.TableName));
            Assert.IsTrue(SgMajors.Delete(TestData.Editor, SgMajors.TableName));
            Assert.IsTrue(Peoples.Delete(TestData.Editor, Peoples.TableName));

            List<Dictionary<string, object>> SubdivisionFields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Subdivisions.ID, 0 },
                    { Subdivisions.Title, "Армии" },
                    { Subdivisions.Table, Armies.TableName},
                },
                new Dictionary<string, object>
                {
                    { Subdivisions.ID, 1 },
                    { Subdivisions.Title, "Баттальоны" },
                    { Subdivisions.Table, Battalions.TableName },
                }
            };
            Assert.IsTrue(Subdivisions.Delete(TestData.Editor, Subdivisions.TableName));
            foreach (var Field in SubdivisionFields)
                Assert.IsTrue(Subdivisions.Insert(TestData.Editor, Subdivisions.TableName, Field));

            List<Dictionary<string, object>> ArmyFields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Armies.ID, 0 },
                    { Armies.Title, "Армия-1" },
                    //{ Armies.Commander, 0 },
                    { Armies.Subdivision, -1 },
                    { Armies.SubdivisionID, -1 }
                },
                new Dictionary<string, object>
                {
                    { Armies.ID, 1 },
                    { Armies.Title, "Армия-2" },
                    //{ Armies.Commander, -1 },
                    { Armies.Subdivision, -1 },
                    { Armies.SubdivisionID, -1 }
                }
            };
            foreach (var Field in ArmyFields)
                Assert.IsTrue(Armies.Insert(TestData.Editor, Armies.TableName, Field));

            List<Dictionary<string, object>> RankFields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Ranks.ID, 0 },
                    { Ranks.Title, "Название 1" },
                    { Ranks.Table, "Талица 1" },
                },
                new Dictionary<string, object>
                {
                    { Ranks.ID, 1 },
                    { Ranks.Title, "Название 2" },
                    { Ranks.Table, SgMajors.TableName },
                },
                new Dictionary<string, object>
                {
                    { Ranks.ID, 2 },
                    { Ranks.Title, "Название 3" },
                    { Ranks.Table, "Талица 3" },
                }
            };
            Assert.IsTrue(Ranks.Delete(TestData.Editor, Ranks.TableName));
            foreach (var Field in RankFields)
                Assert.IsTrue(Ranks.Insert(TestData.Editor, Ranks.TableName, Field));
            
            List<Dictionary<string, object>> PeopleFields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Peoples.ID, 0 },
                    { Peoples.Name, "ФИО 1" },
                    { Peoples.Rank, 1 },
                    { Peoples.Subdivision, 0 },
                    { Peoples.SubdivisionID, 1 },
                },
                new Dictionary<string, object>
                {
                    { Peoples.ID, 1 },
                    { Peoples.Name, "ФИО 1" },
                    { Peoples.Rank, 1 },
                    { Peoples.Subdivision, 1 },
                    { Peoples.SubdivisionID, 1 },
                },
            };
            foreach (var Field in PeopleFields)
                Assert.IsTrue(Peoples.Insert(TestData.Editor, Peoples.TableName, Field));

            List<Dictionary<string, object>> SgMajorsFields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { SgMajors.People, 0 },
                },
                new Dictionary<string, object>
                {
                    { SgMajors.People, 1 },
                }
            };
            foreach (var Field in SgMajorsFields)
                Assert.IsTrue(SgMajors.Insert(TestData.Editor, SgMajors.TableName, Field));

            var iii = Peoples.SelectFirst(TestData.Editor, Peoples.TableName);
            var iii2 = Subdivisions.SelectFirst(TestData.Editor, Subdivisions.TableName, $"{Subdivisions.ID} = {iii.Subdivision}");
            IEnumerable<ISubdivision> Res1 = iii.GetSubdivision(TestData.Editor, iii2.Table);
            Console.WriteLine(iii.Name);
            var iii3 = Ranks.SelectFirst(TestData.Editor, Ranks.TableName, $"{Ranks.ID} = {iii.Rank}");
            Console.WriteLine(iii3.Table);
            IEnumerable<IRank> Res2 = iii.GetRank(TestData.Editor, iii3.Table);

            foreach (var tmp in Res1)
            {
                Assert.AreEqual(tmp.Title, ArmyFields[1][Armies.Title]);
            }
            foreach (var tmp in Res2)
            {
                Assert.AreEqual(tmp.People, SgMajorsFields[0][SgMajors.People]);
            }

            Assert.IsTrue(Armies.Delete(TestData.Editor, Armies.TableName));
            Assert.IsTrue(SgMajors.Delete(TestData.Editor, SgMajors.TableName));
            Assert.IsTrue(Peoples.Delete(TestData.Editor, Peoples.TableName));
            Assert.IsTrue(Ranks.Delete(TestData.Editor, Ranks.TableName));
            Assert.IsTrue(Subdivisions.Delete(TestData.Editor, Subdivisions.TableName));
        }
        [TestMethod]
        public void BuildingTest()
        {
            Assert.IsTrue(Subdivisions.Delete(TestData.Editor, Subdivisions.TableName));

            List<Dictionary<string, object>> SubdivisionFields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Subdivisions.ID, 0 },
                    { Subdivisions.Title, "Армии" },
                    { Subdivisions.Table, Armies.TableName},
                },
                new Dictionary<string, object>
                {
                    { Subdivisions.ID, 1 },
                    { Subdivisions.Title, "Баттальоны" },
                    { Subdivisions.Table, Battalions.TableName },
                }
            };
            Assert.IsTrue(Subdivisions.Delete(TestData.Editor, Subdivisions.TableName));
            foreach (var Field in SubdivisionFields)
                Assert.IsTrue(Subdivisions.Insert(TestData.Editor, Subdivisions.TableName, Field));

            List<Dictionary<string, object>> ArmyFields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Armies.ID, 0 },
                    { Armies.Title, "Армия-1" },
                    //{ Armies.Commander, 0 },
                    { Armies.Subdivision, -1 },
                    { Armies.SubdivisionID, -1 }
                },
                new Dictionary<string, object>
                {
                    { Armies.ID, 1 },
                    { Armies.Title, "Армия-2" },
                    //{ Armies.Commander, -1 },
                    { Armies.Subdivision, -1 },
                    { Armies.SubdivisionID, -1 }
                }
            };
            Assert.IsTrue(Armies.Delete(TestData.Editor, Armies.TableName));
            foreach (var Field in ArmyFields)
                Assert.IsTrue(Armies.Insert(TestData.Editor, Armies.TableName, Field));

            List<Dictionary<string, object>> BuildingFields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Buildings.ID, 0 },
                    { Buildings.Title, "Название 1" },
                    { Buildings.Address, "Талица 1" },
                    { Buildings.WarChase, 0 },
                    { Buildings.WarChaseID, 0 },
                },
                new Dictionary<string, object>
                {
                    { Buildings.ID, 1 },
                    { Buildings.Title, "Название 2" },
                    { Buildings.Address, "Талица 1" },
                    { Buildings.WarChase, 0 },
                    { Buildings.WarChaseID, 1 },
                }
            };
            Assert.IsTrue(Buildings.Delete(TestData.Editor, Buildings.TableName));
            foreach (var Field in BuildingFields)
                Assert.IsTrue(Buildings.Insert(TestData.Editor, Buildings.TableName, Field));


            var iii = Buildings.SelectFirst(TestData.Editor, Buildings.TableName, $"{Buildings.ID} = 1");
            var iii2 = Subdivisions.SelectFirst(TestData.Editor, Subdivisions.TableName, $"{Subdivisions.ID} = {iii.WarChase}");
            IEnumerable<ISubdivision> Res = iii.GetWarChase(TestData.Editor, iii2.Table);

            foreach (var tmp in Res)
            {
                Assert.AreEqual(tmp.Title, ArmyFields[1][Armies.Title]);
            }

            Assert.IsTrue(Armies.Delete(TestData.Editor, Armies.TableName));
            Assert.IsTrue(Buildings.Delete(TestData.Editor, Buildings.TableName));
            Assert.IsTrue(Subdivisions.Delete(TestData.Editor, Subdivisions.TableName));
        }
    }
}
