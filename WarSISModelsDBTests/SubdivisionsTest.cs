using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;

using WarSISModelsDB;
using WarSISModelsDB.Models;
using WarSISModelsDB.Models.Data;
using WarSISModelsDB.Models.DataBase;
using WarSISModelsDB.Models.DataBase.Subdivision;

namespace WarSISModelsDBTests
{
    [TestClass]
    public class SubdivisionsTest
    {
        private void DynamicTest<T>(ADataBase<T> Item, List<Dictionary<string, object>> Fields) where T : class
        {
            Item.Editor = TestData.Editor;
            Assert.IsTrue(Item.Delete());

            foreach (var Field in Fields)
                Assert.IsTrue(Item.Insert(Field));

            Assert.AreEqual(Item.Count(), Fields.Count);

            List<T> Sel = Item.Select();
            Assert.AreEqual(Sel.Count, Fields.Count);

            Assert.IsTrue(Item.Delete());
        }

        [TestMethod]
        public void ArmiesTest()
        {
            Assert.IsTrue(Armies.Delete(TestData.Editor, Armies.TableName));

            List<Dictionary<string, object>> Fields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Armies.ID, 0 },
                    { Armies.Title, "Армия-1" },
                    //{ Armies.Commander, 0 },
                    { Armies.Subdivision, 0 },
                    { Armies.SubdivisionID, 0 }
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

            foreach (var Field in Fields)
                Assert.IsTrue(Armies.Insert(TestData.Editor, Armies.TableName, Field));

            Assert.AreEqual(Armies.Count(TestData.Editor, Armies.TableName), Fields.Count);
            Assert.AreEqual(Armies.Count(TestData.Editor, Armies.TableName, $"{Armies.ID} = {1}"), 1);

            var Sel = Armies.Select(TestData.Editor, Armies.TableName);
            Assert.AreEqual(Sel.Count, Fields.Count);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].ID, Fields[i][Armies.ID]);
                Assert.AreEqual(Sel[i].Title, Fields[i][Armies.Title]);
                //Assert.AreEqual(Sel[i].Commander, Fields[i][Armies.Commander]);
                Assert.AreEqual(Sel[i].Subdivision, Fields[i][Armies.Subdivision]);
                Assert.AreEqual(Sel[i].SubdivisionID, Fields[i][Armies.SubdivisionID]);
            }

            Dictionary<string, object> Line = new Dictionary<string, object>
            {
                {  Armies.Title, "Просто армия" }
            };

            Assert.IsTrue(Armies.Update(TestData.Editor, Armies.TableName, Line, $"{Armies.ID} < 2"));

            Sel = Armies.Select(TestData.Editor, Armies.TableName, $"{Armies.ID} < 2");
            Assert.AreEqual(Sel.Count, 2);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].Title, Line[Armies.Title]);
            }

            Assert.IsTrue(Armies.Delete(TestData.Editor, Armies.TableName));

            DynamicTest(new Armies(), Fields);
        }
        [TestMethod]
        public void BattalionsTest()
        {
            Assert.IsTrue(Battalions.Delete(TestData.Editor, Battalions.TableName));

            List<Dictionary<string, object>> Fields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Battalions.ID, 0 },
                    { Battalions.Title, "Армия-1" },
                    //{ Battalions.Commander, 0 },
                    { Battalions.Subdivision, 0 },
                    { Battalions.SubdivisionID, 0 }
                },
                new Dictionary<string, object>
                {
                    { Battalions.ID, 1 },
                    { Battalions.Title, "Армия-2" },
                    //{ Battalions.Commander, 0 },
                    { Battalions.Subdivision, 0 },
                    { Battalions.SubdivisionID, 0 }
                },
                new Dictionary<string, object>
                {
                    { Battalions.ID, 2 },
                    { Battalions.Title, "Армия-3" },
                    //{ Battalions.Commander, 0 },
                    { Battalions.Subdivision, 0 },
                    { Battalions.SubdivisionID, 0 }
                }
            };

            foreach (var Field in Fields)
                Assert.IsTrue(Battalions.Insert(TestData.Editor, Battalions.TableName, Field));

            Assert.AreEqual(Battalions.Count(TestData.Editor, Battalions.TableName), Fields.Count);
            Assert.AreEqual(Battalions.Count(TestData.Editor, Battalions.TableName, $"{Battalions.ID} = {1}"), 1);

            var Sel = Battalions.Select(TestData.Editor, Battalions.TableName);
            Assert.AreEqual(Sel.Count, Fields.Count);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].ID, Fields[i][Battalions.ID]);
                Assert.AreEqual(Sel[i].Title, Fields[i][Battalions.Title]);
                ////Assert.AreEqual(Sel[i].Commander, Fields[i][Battalions.Commander]);
                Assert.AreEqual(Sel[i].Subdivision, Fields[i][Battalions.Subdivision]);
                Assert.AreEqual(Sel[i].SubdivisionID, Fields[i][Battalions.SubdivisionID]);
            }

            Dictionary<string, object> Line = new Dictionary<string, object>
            {
                {  Battalions.Title, "Просто армия" }
            };

            Assert.IsTrue(Battalions.Update(TestData.Editor, Battalions.TableName, Line, $"{Battalions.ID} < 2"));

            Sel = Battalions.Select(TestData.Editor, Battalions.TableName, $"{Battalions.ID} < 2");
            Assert.AreEqual(Sel.Count, 2);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].Title, Line[Battalions.Title]);
            }

            Assert.IsTrue(Battalions.Delete(TestData.Editor, Battalions.TableName));

            DynamicTest(new Battalions(), Fields);
        }
        [TestMethod]
        public void BranchesTest()
        {
            Assert.IsTrue(Branches.Delete(TestData.Editor, Branches.TableName));

            Assert.IsTrue(Platoons.Delete(TestData.Editor, Platoons.TableName));

            List<Dictionary<string, object>> CompanyFields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Companies.ID, 0 },
                    { Companies.Title, "Армия-1" },
                    //{ Companies.Commander, 0 },
                    { Companies.Subdivision, 0 },
                    { Companies.SubdivisionID, 0 }
                },
                new Dictionary<string, object>
                {
                    { Companies.ID, 1 },
                    { Companies.Title, "Армия-2" },
                    //{ Companies.Commander, 0 },
                    { Companies.Subdivision, 0 },
                    { Companies.SubdivisionID, 0 }
                }
            };
            Assert.IsTrue(Companies.Delete(TestData.Editor, Companies.TableName));
            foreach (var Field in CompanyFields)
                Assert.IsTrue(Companies.Insert(TestData.Editor, Companies.TableName, Field));

            List<Dictionary<string, object>> PlatoonsFields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Platoons.ID, 0 },
                    { Platoons.Title, "Армия-1" },
                    //{ Platoons.Commander, 0 },
                    { Platoons.SubdivisionID, 0 }
                },
                new Dictionary<string, object>
                {
                    { Platoons.ID, 1 },
                    { Platoons.Title, "Армия-2" },
                    //{ Platoons.Commander, 0 },
                    { Platoons.SubdivisionID, 1 },
                }
            };
            foreach (var Field in PlatoonsFields)
                Assert.IsTrue(Platoons.Insert(TestData.Editor, Platoons.TableName, Field));

            List<Dictionary<string, object>> BuildingFields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Buildings.ID, 0 },
                    { Buildings.Title, "Название 1" },
                    { Buildings.Address, "Талица 1" }
                },
                new Dictionary<string, object>
                {
                    { Buildings.ID, 1 },
                    { Buildings.Title, "Название 2" },
                    { Buildings.Address, "Талица 1" }
                }
            };
            Assert.IsTrue(Buildings.Delete(TestData.Editor, Buildings.TableName));
            foreach (var Field in BuildingFields)
                Assert.IsTrue(Buildings.Insert(TestData.Editor, Buildings.TableName, Field));

            List<Dictionary<string, object>> Fields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Branches.ID, 0 },
                    { Branches.Title, "Армия-1" },
                    //{ Branches.Commander, 0 },
                    { Branches.SubdivisionID, 0 },
                    { Branches.Building, 1 }
                },
                new Dictionary<string, object>
                {
                    { Branches.ID, 1 },
                    { Branches.Title, "Армия-2" },
                    //{ Branches.Commander, 0 },
                    { Branches.SubdivisionID, 1 },
                    { Branches.Building, 0 }
                },
                new Dictionary<string, object>
                {
                    { Branches.ID, 2 },
                    { Branches.Title, "Армия-3" },
                    //{ Branches.Commander, 0 },
                    { Branches.SubdivisionID, 0 },
                    //{ Branches.Building, 2 }
                }
            };

            foreach (var Field in Fields)
                Assert.IsTrue(Branches.Insert(TestData.Editor, Branches.TableName, Field));

            Assert.AreEqual(Branches.Count(TestData.Editor, Branches.TableName), Fields.Count);
            Assert.AreEqual(Branches.Count(TestData.Editor, Branches.TableName, $"{Branches.ID} = {1}"), 1);

            var Sel = Branches.Select(TestData.Editor, Branches.TableName);
            Assert.AreEqual(Sel.Count, Fields.Count);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].ID, Fields[i][Branches.ID]);
                Assert.AreEqual(Sel[i].Title, Fields[i][Branches.Title]);
                ////Assert.AreEqual(Sel[i].Commander, Fields[i][Branches.Commander]);
                Assert.AreEqual(Sel[i].SubdivisionID, Fields[i][Branches.SubdivisionID]);
                if(Fields[i].ContainsKey(Branches.Building))
                    Assert.AreEqual(Sel[i].Building, Fields[i][Branches.Building]);
            }

            Dictionary<string, object> Line = new Dictionary<string, object>
            {
                {  Branches.Title, "Просто армия" }
            };

            Assert.IsTrue(Branches.Update(TestData.Editor, Branches.TableName, Line, $"{Branches.ID} < 2"));

            Sel = Branches.Select(TestData.Editor, Branches.TableName, $"{Branches.ID} < 2");
            Assert.AreEqual(Sel.Count, 2);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].Title, Line[Branches.Title]);
            }

            Assert.IsTrue(Branches.Delete(TestData.Editor, Branches.TableName));

            DynamicTest(new Branches(), Fields);

            Assert.IsTrue(Platoons.Delete(TestData.Editor, Platoons.TableName));
            Assert.IsTrue(Companies.Delete(TestData.Editor, Companies.TableName));
            Assert.IsTrue(Buildings.Delete(TestData.Editor, Buildings.TableName));
        }
        [TestMethod]
        public void BrigadesTest()
        {
            Assert.IsTrue(Brigades.Delete(TestData.Editor, Brigades.TableName));

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

            foreach (var Field in Fields)
                Assert.IsTrue(Brigades.Insert(TestData.Editor, Brigades.TableName, Field));

            Assert.AreEqual(Brigades.Count(TestData.Editor, Brigades.TableName), Fields.Count);
            Assert.AreEqual(Brigades.Count(TestData.Editor, Brigades.TableName, $"{Brigades.ID} = {1}"), 1);

            var Sel = Brigades.Select(TestData.Editor, Brigades.TableName);
            Assert.AreEqual(Sel.Count, Fields.Count);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].ID, Fields[i][Brigades.ID]);
                Assert.AreEqual(Sel[i].Title, Fields[i][Brigades.Title]);
                ////Assert.AreEqual(Sel[i].Commander, Fields[i][Brigades.Commander]);
                Assert.AreEqual(Sel[i].Subdivision, Fields[i][Brigades.Subdivision]);
                Assert.AreEqual(Sel[i].SubdivisionID, Fields[i][Brigades.SubdivisionID]);
            }

            Dictionary<string, object> Line = new Dictionary<string, object>
            {
                {  Brigades.Title, "Просто армия" }
            };

            Assert.IsTrue(Brigades.Update(TestData.Editor, Brigades.TableName, Line, $"{Brigades.ID} < 2"));

            Sel = Brigades.Select(TestData.Editor, Brigades.TableName, $"{Brigades.ID} < 2");
            Assert.AreEqual(Sel.Count, 2);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].Title, Line[Brigades.Title]);
            }

            Assert.IsTrue(Brigades.Delete(TestData.Editor, Brigades.TableName));

            DynamicTest(new Brigades(), Fields);
        }
        [TestMethod]
        public void CompaniesTest()
        {
            Assert.IsTrue(Companies.Delete(TestData.Editor, Companies.TableName));

            List<Dictionary<string, object>> Fields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Companies.ID, 0 },
                    { Companies.Title, "Армия-1" },
                    //{ Companies.Commander, 0 },
                    { Companies.Subdivision, 0 },
                    { Companies.SubdivisionID, 0 }
                },
                new Dictionary<string, object>
                {
                    { Companies.ID, 1 },
                    { Companies.Title, "Армия-2" },
                    //{ Companies.Commander, 0 },
                    { Companies.Subdivision, 0 },
                    { Companies.SubdivisionID, 0 }
                },
                new Dictionary<string, object>
                {
                    { Companies.ID, 2 },
                    { Companies.Title, "Армия-3" },
                    //{ Companies.Commander, 0 },
                    { Companies.Subdivision, 0 },
                    { Companies.SubdivisionID, 0 }
                }
            };

            foreach (var Field in Fields)
                Assert.IsTrue(Companies.Insert(TestData.Editor, Companies.TableName, Field));

            Assert.AreEqual(Companies.Count(TestData.Editor, Companies.TableName), Fields.Count);
            Assert.AreEqual(Companies.Count(TestData.Editor, Companies.TableName, $"{Companies.ID} = {1}"), 1);

            var Sel = Companies.Select(TestData.Editor, Companies.TableName);
            Assert.AreEqual(Sel.Count, Fields.Count);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].ID, Fields[i][Companies.ID]);
                Assert.AreEqual(Sel[i].Title, Fields[i][Companies.Title]);
                ////Assert.AreEqual(Sel[i].Commander, Fields[i][Companies.Commander]);
                Assert.AreEqual(Sel[i].Subdivision, Fields[i][Companies.Subdivision]);
                Assert.AreEqual(Sel[i].SubdivisionID, Fields[i][Companies.SubdivisionID]);
            }

            Dictionary<string, object> Line = new Dictionary<string, object>
            {
                {  Companies.Title, "Просто армия" }
            };

            Assert.IsTrue(Companies.Update(TestData.Editor, Companies.TableName, Line, $"{Companies.ID} < 2"));

            Sel = Companies.Select(TestData.Editor, Companies.TableName, $"{Companies.ID} < 2");
            Assert.AreEqual(Sel.Count, 2);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].Title, Line[Companies.Title]);
            }

            Assert.IsTrue(Companies.Delete(TestData.Editor, Companies.TableName));

            DynamicTest(new Companies(), Fields);
        }
        [TestMethod]
        public void CorpsesTest()
        {
            Assert.IsTrue(Corpses.Delete(TestData.Editor, Corpses.TableName));

            List<Dictionary<string, object>> Fields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Corpses.ID, 0 },
                    { Corpses.Title, "Армия-1" },
                    //{ Corpses.Commander, 0 },
                    { Corpses.Subdivision, 0 },
                    { Corpses.SubdivisionID, 0 }
                },
                new Dictionary<string, object>
                {
                    { Corpses.ID, 1 },
                    { Corpses.Title, "Армия-2" },
                    //{ Corpses.Commander, 0 },
                    { Corpses.Subdivision, 0 },
                    { Corpses.SubdivisionID, 0 }
                },
                new Dictionary<string, object>
                {
                    { Corpses.ID, 2 },
                    { Corpses.Title, "Армия-3" },
                    //{ Corpses.Commander, 0 },
                    { Corpses.Subdivision, 0 },
                    { Corpses.SubdivisionID, 0 }
                }
            };

            foreach (var Field in Fields)
                Assert.IsTrue(Corpses.Insert(TestData.Editor, Corpses.TableName, Field));

            Assert.AreEqual(Corpses.Count(TestData.Editor, Corpses.TableName), Fields.Count);
            Assert.AreEqual(Corpses.Count(TestData.Editor, Corpses.TableName, $"{Corpses.ID} = {1}"), 1);

            var Sel = Corpses.Select(TestData.Editor, Corpses.TableName);
            Assert.AreEqual(Sel.Count, Fields.Count);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].ID, Fields[i][Corpses.ID]);
                Assert.AreEqual(Sel[i].Title, Fields[i][Corpses.Title]);
                //Assert.AreEqual(Sel[i].Commander, Fields[i][Corpses.Commander]);
                Assert.AreEqual(Sel[i].Subdivision, Fields[i][Corpses.Subdivision]);
                Assert.AreEqual(Sel[i].SubdivisionID, Fields[i][Corpses.SubdivisionID]);
            }

            Dictionary<string, object> Line = new Dictionary<string, object>
            {
                {  Corpses.Title, "Просто армия" }
            };

            Assert.IsTrue(Corpses.Update(TestData.Editor, Corpses.TableName, Line, $"{Corpses.ID} < 2"));

            Sel = Corpses.Select(TestData.Editor, Corpses.TableName, $"{Corpses.ID} < 2");
            Assert.AreEqual(Sel.Count, 2);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].Title, Line[Corpses.Title]);
            }

            Assert.IsTrue(Corpses.Delete(TestData.Editor, Corpses.TableName));

            DynamicTest(new Corpses(), Fields);
        }
        [TestMethod]
        public void DivisionsTest()
        {
            Assert.IsTrue(Divisions.Delete(TestData.Editor, Divisions.TableName));

            List<Dictionary<string, object>> Fields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Divisions.ID, 0 },
                    { Divisions.Title, "Армия-1" },
                    //{ Divisions.Commander, 0 },
                    { Divisions.Subdivision, 0 },
                    { Divisions.SubdivisionID, 0 }
                },
                new Dictionary<string, object>
                {
                    { Divisions.ID, 1 },
                    { Divisions.Title, "Армия-2" },
                    //{ Divisions.Commander, 0 },
                    { Divisions.Subdivision, 0 },
                    { Divisions.SubdivisionID, 0 }
                },
                new Dictionary<string, object>
                {
                    { Divisions.ID, 2 },
                    { Divisions.Title, "Армия-3" },
                    //{ Divisions.Commander, 0 },
                    { Divisions.Subdivision, 0 },
                    { Divisions.SubdivisionID, 0 }
                }
            };

            foreach (var Field in Fields)
                Assert.IsTrue(Divisions.Insert(TestData.Editor, Divisions.TableName, Field));

            Assert.AreEqual(Divisions.Count(TestData.Editor, Divisions.TableName), Fields.Count);
            Assert.AreEqual(Divisions.Count(TestData.Editor, Divisions.TableName, $"{Divisions.ID} = {1}"), 1);

            var Sel = Divisions.Select(TestData.Editor, Divisions.TableName);
            Assert.AreEqual(Sel.Count, Fields.Count);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].ID, Fields[i][Divisions.ID]);
                Assert.AreEqual(Sel[i].Title, Fields[i][Divisions.Title]);
                //Assert.AreEqual(Sel[i].Commander, Fields[i][Divisions.Commander]);
                Assert.AreEqual(Sel[i].Subdivision, Fields[i][Divisions.Subdivision]);
                Assert.AreEqual(Sel[i].SubdivisionID, Fields[i][Divisions.SubdivisionID]);
            }

            Dictionary<string, object> Line = new Dictionary<string, object>
            {
                {  Divisions.Title, "Просто армия" }
            };

            Assert.IsTrue(Divisions.Update(TestData.Editor, Divisions.TableName, Line, $"{Divisions.ID} < 2"));

            Sel = Divisions.Select(TestData.Editor, Divisions.TableName, $"{Divisions.ID} < 2");
            Assert.AreEqual(Sel.Count, 2);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].Title, Line[Divisions.Title]);
            }

            Assert.IsTrue(Divisions.Delete(TestData.Editor, Divisions.TableName));

            DynamicTest(new Divisions(), Fields);
        }
        [TestMethod]
        public void PlatoonsTest()
        {
            Assert.IsTrue(Platoons.Delete(TestData.Editor, Platoons.TableName));

            List<Dictionary<string, object>> CompanyFields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Companies.ID, 0 },
                    { Companies.Title, "Армия-1" },
                    //{ Companies.Commander, 0 },
                    { Companies.Subdivision, 0 },
                    { Companies.SubdivisionID, 0 }
                },
                new Dictionary<string, object>
                {
                    { Companies.ID, 1 },
                    { Companies.Title, "Армия-2" },
                    //{ Companies.Commander, 0 },
                    { Companies.Subdivision, 0 },
                    { Companies.SubdivisionID, 0 }
                }
            };
            Assert.IsTrue(Companies.Delete(TestData.Editor, Companies.TableName));
            foreach (var Field in CompanyFields)
                Assert.IsTrue(Companies.Insert(TestData.Editor, Companies.TableName, Field));

            List<Dictionary<string, object>> Fields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Platoons.ID, 0 },
                    { Platoons.Title, "Армия-1" },
                    //{ Platoons.Commander, 0 },
                    { Platoons.SubdivisionID, 0 }
                },
                new Dictionary<string, object>
                {
                    { Platoons.ID, 1 },
                    { Platoons.Title, "Армия-2" },
                    //{ Platoons.Commander, 0 },
                    { Platoons.SubdivisionID, 1 },
                },
                new Dictionary<string, object>
                {
                    { Platoons.ID, 2 },
                    { Platoons.Title, "Армия-3" },
                    //{ Platoons.Commander, 0 },
                    { Platoons.SubdivisionID, 1 },
                }
            };

            foreach (var Field in Fields)
                Assert.IsTrue(Platoons.Insert(TestData.Editor, Platoons.TableName, Field));

            Assert.AreEqual(Platoons.Count(TestData.Editor, Platoons.TableName), Fields.Count);
            Assert.AreEqual(Platoons.Count(TestData.Editor, Platoons.TableName, $"{Platoons.ID} = {1}"), 1);

            var Sel = Platoons.Select(TestData.Editor, Platoons.TableName);
            Assert.AreEqual(Sel.Count, Fields.Count);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].ID, Fields[i][Platoons.ID]);
                Assert.AreEqual(Sel[i].Title, Fields[i][Platoons.Title]);
                //Assert.AreEqual(Sel[i].Commander, Fields[i][Platoons.Commander]);
                Assert.AreEqual(Sel[i].SubdivisionID, Fields[i][Platoons.SubdivisionID]);
            }

            Dictionary<string, object> Line = new Dictionary<string, object>
            {
                {  Platoons.Title, "Просто армия" }
            };

            Assert.IsTrue(Platoons.Update(TestData.Editor, Platoons.TableName, Line, $"{Platoons.ID} < 2"));

            Sel = Platoons.Select(TestData.Editor, Platoons.TableName, $"{Platoons.ID} < 2");
            Assert.AreEqual(Sel.Count, 2);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].Title, Line[Platoons.Title]);
            }

            Assert.IsTrue(Platoons.Delete(TestData.Editor, Platoons.TableName));

            DynamicTest(new Platoons(), Fields);

            Assert.IsTrue(Companies.Delete(TestData.Editor, Companies.TableName));
        }
        [TestMethod]
        public void RegimentsTest()
        {
            Assert.IsTrue(Regiments.Delete(TestData.Editor, Regiments.TableName));

            List<Dictionary<string, object>> Fields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Regiments.ID, 0 },
                    { Regiments.Title, "Армия-1" },
                    //{ Regiments.Commander, 0 },
                    { Regiments.Subdivision, 0 },
                    { Regiments.SubdivisionID, 0 }
                },
                new Dictionary<string, object>
                {
                    { Regiments.ID, 1 },
                    { Regiments.Title, "Армия-2" },
                    //{ Regiments.Commander, 0 },
                    { Regiments.Subdivision, 0 },
                    { Regiments.SubdivisionID, 0 }
                },
                new Dictionary<string, object>
                {
                    { Regiments.ID, 2 },
                    { Regiments.Title, "Армия-3" },
                    //{ Regiments.Commander, 0 },
                    { Regiments.Subdivision, 0 },
                    { Regiments.SubdivisionID, 0 }
                }
            };

            foreach (var Field in Fields)
                Assert.IsTrue(Regiments.Insert(TestData.Editor, Regiments.TableName, Field));

            Assert.AreEqual(Regiments.Count(TestData.Editor, Regiments.TableName), Fields.Count);
            Assert.AreEqual(Regiments.Count(TestData.Editor, Regiments.TableName, $"{Regiments.ID} = {1}"), 1);

            var Sel = Regiments.Select(TestData.Editor, Regiments.TableName);
            Assert.AreEqual(Sel.Count, Fields.Count);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].ID, Fields[i][Regiments.ID]);
                Assert.AreEqual(Sel[i].Title, Fields[i][Regiments.Title]);
                //Assert.AreEqual(Sel[i].Commander, Fields[i][Regiments.Commander]);
                Assert.AreEqual(Sel[i].Subdivision, Fields[i][Regiments.Subdivision]);
                Assert.AreEqual(Sel[i].SubdivisionID, Fields[i][Regiments.SubdivisionID]);
            }

            Dictionary<string, object> Line = new Dictionary<string, object>
            {
                {  Regiments.Title, "Просто армия" }
            };

            Assert.IsTrue(Regiments.Update(TestData.Editor, Regiments.TableName, Line, $"{Regiments.ID} < 2"));

            Sel = Regiments.Select(TestData.Editor, Regiments.TableName, $"{Regiments.ID} < 2");
            Assert.AreEqual(Sel.Count, 2);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].Title, Line[Regiments.Title]);
            }

            Assert.IsTrue(Regiments.Delete(TestData.Editor, Regiments.TableName));

            DynamicTest(new Regiments(), Fields);
        }
    }
}
