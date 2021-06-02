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
    public class BasicTest
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
        public void PropertiesTest()
        {
            Assert.IsTrue(Properties.Delete(TestData.Editor, Properties.TableName));

            List<Dictionary<string, object>> Fields = new List<Dictionary<string, object>>() {
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
                    { Properties.Table, "Талица 2" },
                },
                new Dictionary<string, object>
                {
                    { Properties.ID, 2 },
                    { Properties.Title, "Название 3" },
                    { Properties.Table, "Талица 3" },
                }
            };

            foreach (var Field in Fields)
                Assert.IsTrue(Properties.Insert(TestData.Editor, Properties.TableName, Field));

            Assert.AreEqual(Properties.Count(TestData.Editor, Properties.TableName), Fields.Count);
            Assert.AreEqual(Properties.Count(TestData.Editor, Properties.TableName, $"{Properties.ID} = {1}"), 1);

            var Sel = Properties.Select(TestData.Editor, Properties.TableName);
            Assert.AreEqual(Sel.Count, Fields.Count);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].ID, Fields[i][Properties.ID]);
                Assert.AreEqual(Sel[i].Title, Fields[i][Properties.Title]);
                Assert.AreEqual(Sel[i].Table, Fields[i][Properties.Table]);
            }

            Dictionary<string, object> Line = new Dictionary<string, object>
            {
                { Properties.Title, "Название" },
                { Properties.Table, "Талица" },
            };

            Assert.IsTrue(Properties.Update(TestData.Editor, Properties.TableName, Line, $"{Properties.ID} < 2"));

            Sel = Properties.Select(TestData.Editor, Properties.TableName, $"{Properties.ID} < 2");
            Assert.AreEqual(Sel.Count, 2);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].ID, Fields[i][Properties.ID]);
                Assert.AreEqual(Sel[i].Title, Line[Properties.Title]);
                Assert.AreEqual(Sel[i].Table, Line[Properties.Table]);
            }

            Assert.IsTrue(Properties.Delete(TestData.Editor, Properties.TableName));

            DynamicTest(new Properties(), Fields);
        }
        [TestMethod]
        public void RanksTest()
        {
            Assert.IsTrue(Ranks.Delete(TestData.Editor, Ranks.TableName));

            List<Dictionary<string, object>> Fields = new List<Dictionary<string, object>>() {
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
                    { Ranks.Table, "Талица 2" },
                },
                new Dictionary<string, object>
                {
                    { Ranks.ID, 2 },
                    { Ranks.Title, "Название 3" },
                    { Ranks.Table, "Талица 3" },
                }
            };

            foreach (var Field in Fields)
                Assert.IsTrue(Ranks.Insert(TestData.Editor, Ranks.TableName, Field));

            Assert.AreEqual(Ranks.Count(TestData.Editor, Ranks.TableName), Fields.Count);
            Assert.AreEqual(Ranks.Count(TestData.Editor, Ranks.TableName, $"{Ranks.ID} = {1}"), 1);

            var Sel = Ranks.Select(TestData.Editor, Ranks.TableName);
            Assert.AreEqual(Sel.Count, Fields.Count);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].ID, Fields[i][Ranks.ID]);
                Assert.AreEqual(Sel[i].Title, Fields[i][Ranks.Title]);
                Assert.AreEqual(Sel[i].Table, Fields[i][Ranks.Table]);
            }

            Dictionary<string, object> Line = new Dictionary<string, object>
            {
                { Ranks.Title, "Название" },
                { Ranks.Table, "Талица" },
            };

            Assert.IsTrue(Ranks.Update(TestData.Editor, Ranks.TableName, Line, $"{Ranks.ID} < 2"));

            Sel = Ranks.Select(TestData.Editor, Ranks.TableName, $"{Ranks.ID} < 2");
            Assert.AreEqual(Sel.Count, 2);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].ID, Fields[i][Ranks.ID]);
                Assert.AreEqual(Sel[i].Title, Line[Ranks.Title]);
                Assert.AreEqual(Sel[i].Table, Line[Ranks.Table]);
            }

            Assert.IsTrue(Ranks.Delete(TestData.Editor, Ranks.TableName));

            DynamicTest(new Ranks(), Fields);
        }
        [TestMethod]
        public void SubdivisionsTest()
        {
            Assert.IsTrue(Subdivisions.Delete(TestData.Editor, Subdivisions.TableName));

            List<Dictionary<string, object>> Fields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Subdivisions.ID, 0 },
                    { Subdivisions.Title, "Название 1" },
                    { Subdivisions.Table, "Талица 1" },
                },
                new Dictionary<string, object>
                {
                    { Subdivisions.ID, 1 },
                    { Subdivisions.Title, "Название 2" },
                    { Subdivisions.Table, "Талица 2" },
                },
                new Dictionary<string, object>
                {
                    { Subdivisions.ID, 2 },
                    { Subdivisions.Title, "Название 3" },
                    { Subdivisions.Table, "Талица 3" },
                }
            };

            foreach (var Field in Fields)
                Assert.IsTrue(Subdivisions.Insert(TestData.Editor, Subdivisions.TableName, Field));

            Assert.AreEqual(Subdivisions.Count(TestData.Editor, Subdivisions.TableName), Fields.Count);
            Assert.AreEqual(Subdivisions.Count(TestData.Editor, Subdivisions.TableName, $"{Subdivisions.ID} = {1}"), 1);

            var Sel = Subdivisions.Select(TestData.Editor, Subdivisions.TableName);
            Assert.AreEqual(Sel.Count, Fields.Count);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].ID, Fields[i][Subdivisions.ID]);
                Assert.AreEqual(Sel[i].Title, Fields[i][Subdivisions.Title]);
                Assert.AreEqual(Sel[i].Table, Fields[i][Subdivisions.Table]);
            }

            Dictionary<string, object> Line = new Dictionary<string, object>
            {
                { Subdivisions.Title, "Название" },
                { Subdivisions.Table, "Талица" },
            };

            Assert.IsTrue(Subdivisions.Update(TestData.Editor, Subdivisions.TableName, Line, $"{Subdivisions.ID} < 2"));

            Sel = Subdivisions.Select(TestData.Editor, Subdivisions.TableName, $"{Subdivisions.ID} < 2");
            Assert.AreEqual(Sel.Count, 2);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].ID, Fields[i][Subdivisions.ID]);
                Assert.AreEqual(Sel[i].Title, Line[Subdivisions.Title]);
                Assert.AreEqual(Sel[i].Table, Line[Subdivisions.Table]);
            }

            Assert.IsTrue(Subdivisions.Delete(TestData.Editor, Subdivisions.TableName));

            DynamicTest(new Subdivisions(), Fields);
        }
        
        [TestMethod]
        public void PropertiesInSubdivisionsTest()
        {
            Assert.IsTrue(PropertiesInSubdivissions.Delete(TestData.Editor, PropertiesInSubdivissions.TableName));

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
                    { Properties.Table, "Талица 2" },
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

            Subdivisions.Delete(TestData.Editor, Subdivisions.TableName);
            foreach (var Field in SubdivisionFields)
                Assert.IsTrue(Subdivisions.Insert(TestData.Editor, Subdivisions.TableName, Field));

            List<Dictionary<string, object>> Fields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { PropertiesInSubdivissions.Property, 0 },
                    { PropertiesInSubdivissions.PropertyID, -1 },
                    { PropertiesInSubdivissions.Subdivision, 1 },
                    { PropertiesInSubdivissions.SubdivisionID, -1 },
                },
                new Dictionary<string, object>
                {
                    { PropertiesInSubdivissions.Property, 1 },
                    { PropertiesInSubdivissions.PropertyID, -1 },
                    { PropertiesInSubdivissions.Subdivision, 0 },
                    { PropertiesInSubdivissions.SubdivisionID, -1 },
                }
            };

            foreach (var Field in Fields)
                Assert.IsTrue(PropertiesInSubdivissions.Insert(TestData.Editor, PropertiesInSubdivissions.TableName, Field));

            Assert.AreEqual(PropertiesInSubdivissions.Count(TestData.Editor, PropertiesInSubdivissions.TableName), Fields.Count);
            Assert.AreEqual(PropertiesInSubdivissions.Count(TestData.Editor, PropertiesInSubdivissions.TableName, $"{PropertiesInSubdivissions.Property} = {1}"), 1);

            var Sel = PropertiesInSubdivissions.Select(TestData.Editor, PropertiesInSubdivissions.TableName);
            Assert.AreEqual(Sel.Count, Fields.Count);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].Property, Fields[i][PropertiesInSubdivissions.Property]);
                Assert.AreEqual(Sel[i].PropertyID, Fields[i][PropertiesInSubdivissions.PropertyID]);
                Assert.AreEqual(Sel[i].Subdivision, Fields[i][PropertiesInSubdivissions.Subdivision]);
                Assert.AreEqual(Sel[i].SubdivisionID, Fields[i][PropertiesInSubdivissions.SubdivisionID]);
            }

            Dictionary<string, object> Line = new Dictionary<string, object>
            {
                { PropertiesInSubdivissions.PropertyID, 1 },
                { PropertiesInSubdivissions.SubdivisionID, 1 }
            };

            Assert.IsTrue(PropertiesInSubdivissions.Update(TestData.Editor, PropertiesInSubdivissions.TableName, Line, $"{PropertiesInSubdivissions.Property} < 1"));

            Sel = PropertiesInSubdivissions.Select(TestData.Editor, PropertiesInSubdivissions.TableName, $"{PropertiesInSubdivissions.Property} < 1");
            Assert.AreEqual(Sel.Count, 1);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].PropertyID, Line[PropertiesInSubdivissions.PropertyID]);
                Assert.AreEqual(Sel[i].SubdivisionID, Line[PropertiesInSubdivissions.SubdivisionID]);
            }

            Assert.IsTrue(PropertiesInSubdivissions.Delete(TestData.Editor, PropertiesInSubdivissions.TableName));

            DynamicTest(new PropertiesInSubdivissions(), Fields);

            Properties.Delete(TestData.Editor, Properties.TableName);
            Subdivisions.Delete(TestData.Editor, Subdivisions.TableName);
        }
        [TestMethod]
        public void SpecialitiesTest()
        {
            Assert.IsTrue(Specialities.Delete(TestData.Editor, Specialities.TableName));

            List<Dictionary<string, object>> Fields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Specialities.ID, 0 },
                    { Specialities.Title, "Название 1" },
                },
                new Dictionary<string, object>
                {
                    { Specialities.ID, 1 },
                    { Specialities.Title, "Название 2" },
                },
                new Dictionary<string, object>
                {
                    { Specialities.ID, 2 },
                    { Specialities.Title, "Название 3" },
                }
            };

            foreach (var Field in Fields)
                Assert.IsTrue(Specialities.Insert(TestData.Editor, Specialities.TableName, Field));

            Assert.AreEqual(Specialities.Count(TestData.Editor, Specialities.TableName), Fields.Count);
            Assert.AreEqual(Specialities.Count(TestData.Editor, Specialities.TableName, $"{Specialities.ID} = {1}"), 1);

            var Sel = Specialities.Select(TestData.Editor, Specialities.TableName);
            Assert.AreEqual(Sel.Count, Fields.Count);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].ID, Fields[i][Specialities.ID]);
                Assert.AreEqual(Sel[i].Title, Fields[i][Specialities.Title]);
            }

            Dictionary<string, object> Line = new Dictionary<string, object>
            {
                { Specialities.Title, "Название" },
            };

            Assert.IsTrue(Specialities.Update(TestData.Editor, Specialities.TableName, Line, $"{Specialities.ID} < 2"));

            Sel = Specialities.Select(TestData.Editor, Specialities.TableName, $"{Specialities.ID} < 2");
            Assert.AreEqual(Sel.Count, 2);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].Title, Line[Specialities.Title]);
            }

            Assert.IsTrue(Specialities.Delete(TestData.Editor, Specialities.TableName));

            DynamicTest(new Specialities(), Fields);
        }
        [TestMethod]
        public void OwnedSpecialitiesTest()
        {
            Assert.IsTrue(OwnedSpecialities.Delete(TestData.Editor, OwnedSpecialities.TableName));

            Peoples.Delete(TestData.Editor, Peoples.TableName);

            List<Dictionary<string, object>> SpecialityFields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Specialities.ID, 0 },
                    { Specialities.Title, "Название 1" },
                },
                new Dictionary<string, object>
                {
                    { Specialities.ID, 1 },
                    { Specialities.Title, "Название 2" },
                }
            };
            Specialities.Delete(TestData.Editor, Specialities.TableName);
            foreach (var Field in SpecialityFields)
                Assert.IsTrue(Specialities.Insert(TestData.Editor, Specialities.TableName, Field));

            List<Dictionary<string, object>> RankFields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Ranks.ID, 0 },
                    { Ranks.Title, "Название 1" },
                    { Ranks.Table, Soldiers.TableName},
                },
                new Dictionary<string, object>
                {
                    { Ranks.ID, 1 },
                    { Ranks.Title, "Название 2" },
                    { Ranks.Table, Ensigns.TableName },
                }
            };
            Assert.IsTrue(Ranks.Delete(TestData.Editor, Ranks.TableName));
            foreach (var Field in RankFields)
                Assert.IsTrue(Ranks.Insert(TestData.Editor, Ranks.TableName, Field));

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
            Subdivisions.Delete(TestData.Editor, Subdivisions.TableName);
            foreach (var Field in SubdivisionFields)
                Assert.IsTrue(Subdivisions.Insert(TestData.Editor, Subdivisions.TableName, Field));

            List<Dictionary<string, object>> PeopleFields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Peoples.ID, 0 },
                    { Peoples.Name, "ФИО 1" },
                    { Peoples.Rank, 0 },
                    { Peoples.Subdivision, 1 },
                    { Peoples.SubdivisionID, -1 },
                },
                new Dictionary<string, object>
                {
                    { Peoples.ID, 1 },
                    { Peoples.Name, "ФИО 1" },
                    { Peoples.Rank, 1 },
                    { Peoples.Subdivision, 1 },
                    { Peoples.SubdivisionID, -1 },
                },
                new Dictionary<string, object>
                {
                    { Peoples.ID, 2 },
                    { Peoples.Name, "ФИО 1" },
                    { Peoples.Rank, 1 },
                    { Peoples.Subdivision, 0 },
                    { Peoples.SubdivisionID, -1 },
                }
            };
            foreach (var Field in PeopleFields)
                Assert.IsTrue(Peoples.Insert(TestData.Editor, Peoples.TableName, Field));

            List<Dictionary<string, object>> Fields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { OwnedSpecialities.ID, 0 },
                    { OwnedSpecialities.People, 1 },
                    { OwnedSpecialities.Speciality, 0 },
                },
                new Dictionary<string, object>
                {
                    { OwnedSpecialities.ID, 1 },
                    { OwnedSpecialities.People, 0 },
                    { OwnedSpecialities.Speciality, 1 },
                },
                new Dictionary<string, object>
                {
                    { OwnedSpecialities.ID, 2 },
                    { OwnedSpecialities.People, 1 },
                    { OwnedSpecialities.Speciality, 1 },
                }
            };

            foreach (var Field in Fields)
                Assert.IsTrue(OwnedSpecialities.Insert(TestData.Editor, OwnedSpecialities.TableName, Field));

            Assert.AreEqual(OwnedSpecialities.Count(TestData.Editor, OwnedSpecialities.TableName), Fields.Count);
            Assert.AreEqual(OwnedSpecialities.Count(TestData.Editor, OwnedSpecialities.TableName, $"{OwnedSpecialities.ID} = {1}"), 1);

            var Sel = OwnedSpecialities.Select(TestData.Editor, OwnedSpecialities.TableName);
            Assert.AreEqual(Sel.Count, Fields.Count);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].ID, Fields[i][OwnedSpecialities.ID]);
                Assert.AreEqual(Sel[i].People, Fields[i][OwnedSpecialities.People]);
                Assert.AreEqual(Sel[i].Speciality, Fields[i][OwnedSpecialities.Speciality]);
            }

            Dictionary<string, object> Line = new Dictionary<string, object>
            {
                { OwnedSpecialities.People, 0 },
                { OwnedSpecialities.Speciality, 0 },
            };

            Assert.IsTrue(OwnedSpecialities.Update(TestData.Editor, OwnedSpecialities.TableName, Line, $"{OwnedSpecialities.ID} < 2"));

            Sel = OwnedSpecialities.Select(TestData.Editor, OwnedSpecialities.TableName, $"{OwnedSpecialities.ID} < 2");
            Assert.AreEqual(Sel.Count, 2);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].People, Line[OwnedSpecialities.People]);
                Assert.AreEqual(Sel[i].Speciality, Line[OwnedSpecialities.Speciality]);
            }

            Assert.IsTrue(OwnedSpecialities.Delete(TestData.Editor, OwnedSpecialities.TableName));

            DynamicTest(new OwnedSpecialities(), Fields);

            Specialities.Delete(TestData.Editor, Specialities.TableName);
            Peoples.Delete(TestData.Editor, Peoples.TableName);
            Ranks.Delete(TestData.Editor, Ranks.TableName);
            Subdivisions.Delete(TestData.Editor, Subdivisions.TableName);
        }
        [TestMethod]
        public void BuildingsTest()
        {
            Assert.IsTrue(Buildings.Delete(TestData.Editor, Buildings.TableName));

            List<Dictionary<string, object>> SubdivisionFields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Ranks.ID, 0 },
                    { Ranks.Title, "Название 1" },
                    { Ranks.Table, Armies.TableName},
                },
                new Dictionary<string, object>
                {
                    { Ranks.ID, 1 },
                    { Ranks.Title, "Название 2" },
                    { Ranks.Table, Battalions.TableName },
                }
            };
            Subdivisions.Delete(TestData.Editor, Subdivisions.TableName);
            foreach (var Field in SubdivisionFields)
                Subdivisions.Insert(TestData.Editor, Subdivisions.TableName, Field);

            List<Dictionary<string, object>> Fields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Buildings.ID, 0 },
                    { Buildings.Title, "Название 1" },
                    { Buildings.Address, "Талица 1" },
                    { Buildings.WarChase, 0 },
                    { Buildings.WarChaseID, -1 },
                },
                new Dictionary<string, object>
                {
                    { Buildings.ID, 1 },
                    { Buildings.Title, "Название 2" },
                    { Buildings.Address, "Талица 1" },
                    { Buildings.WarChase, 0 },
                    { Buildings.WarChaseID, -1 },
                },
                new Dictionary<string, object>
                {
                    { Buildings.ID, 2 },
                    { Buildings.Title, "Название 3" },
                    { Buildings.Address, "Талица 1" },
                    { Buildings.WarChase, 1 },
                    { Buildings.WarChaseID, -1 },
                }
            };

            foreach (var Field in Fields)
                Assert.IsTrue(Buildings.Insert(TestData.Editor, Buildings.TableName, Field));

            Assert.AreEqual(Buildings.Count(TestData.Editor, Buildings.TableName), Fields.Count);
            Assert.AreEqual(Buildings.Count(TestData.Editor, Buildings.TableName, $"{Buildings.ID} = {1}"), 1);

            var Sel = Buildings.Select(TestData.Editor, Buildings.TableName);
            Assert.AreEqual(Sel.Count, Fields.Count);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].ID, Fields[i][Buildings.ID]);
                Assert.AreEqual(Sel[i].Title, Fields[i][Buildings.Title]);
                Assert.AreEqual(Sel[i].Address, Fields[i][Buildings.Address]);
                Assert.AreEqual(Sel[i].WarChase, Fields[i][Buildings.WarChase]);
                Assert.AreEqual(Sel[i].WarChaseID, Fields[i][Buildings.WarChaseID]);
            }

            Dictionary<string, object> Line = new Dictionary<string, object>
            {
                { Buildings.Title, "Название" },
                { Buildings.Address, "Талица 1" },
            };

            Assert.IsTrue(Buildings.Update(TestData.Editor, Buildings.TableName, Line, $"{Buildings.ID} < 2"));

            Sel = Buildings.Select(TestData.Editor, Buildings.TableName, $"{Buildings.ID} < 2");
            Assert.AreEqual(Sel.Count, 2);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].Title, Line[Buildings.Title]);
                Assert.AreEqual(Sel[i].Address, Line[Buildings.Address]);
            }

            Assert.IsTrue(Buildings.Delete(TestData.Editor, Buildings.TableName));

            Subdivisions.Delete(TestData.Editor, Subdivisions.TableName);

            DynamicTest(new Buildings(), Fields);
        }
        [TestMethod]
        public void PeoplesTest()
        {
            Assert.IsTrue(Peoples.Delete(TestData.Editor, Peoples.TableName));

            List<Dictionary<string, object>> RankFields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Ranks.ID, 0 },
                    { Ranks.Title, "Название 1" },
                    { Ranks.Table, Soldiers.TableName},
                },
                new Dictionary<string, object>
                {
                    { Ranks.ID, 1 },
                    { Ranks.Title, "Название 2" },
                    { Ranks.Table, Ensigns.TableName },
                }
            };
            Ranks.Delete(TestData.Editor, Ranks.TableName);
            foreach (var Field in RankFields)
                Assert.IsTrue(Ranks.Insert(TestData.Editor, Ranks.TableName, Field));

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
            Subdivisions.Delete(TestData.Editor, Subdivisions.TableName);
            foreach (var Field in SubdivisionFields)
                Assert.IsTrue(Subdivisions.Insert(TestData.Editor, Subdivisions.TableName, Field));

            List<Dictionary<string, object>> Fields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Peoples.ID, 0 },
                    { Peoples.Name, "ФИО 1" },
                    { Peoples.Rank, 0 },
                    
                    { Peoples.Subdivision, 1 },
                    { Peoples.SubdivisionID, -1 },
                },
                new Dictionary<string, object>
                {
                    { Peoples.ID, 1 },
                    { Peoples.Name, "ФИО 1" },
                    { Peoples.Rank, 1 },
                    
                    { Peoples.Subdivision, 1 },
                    { Peoples.SubdivisionID, -1 },
                },
                new Dictionary<string, object>
                {
                    { Peoples.ID, 2 },
                    { Peoples.Name, "ФИО 1" },
                    { Peoples.Rank, 1 },
                    
                    { Peoples.Subdivision, 0 },
                    { Peoples.SubdivisionID, -1 },
                }
            };

            foreach (var Field in Fields)
                Assert.IsTrue(Peoples.Insert(TestData.Editor, Peoples.TableName, Field));

            Assert.AreEqual(Peoples.Count(TestData.Editor, Peoples.TableName), Fields.Count);
            Assert.AreEqual(Peoples.Count(TestData.Editor, Peoples.TableName, $"{Peoples.ID} = {1}"), 1);

            var Sel = Peoples.Select(TestData.Editor, Peoples.TableName);
            Assert.AreEqual(Sel.Count, Fields.Count);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].ID, Fields[i][Peoples.ID]);
                Assert.AreEqual(Sel[i].Name, Fields[i][Peoples.Name]);
                Assert.AreEqual(Sel[i].Rank, Fields[i][Peoples.Rank]);
                Assert.AreEqual(Sel[i].Subdivision, Fields[i][Peoples.Subdivision]);
                Assert.AreEqual(Sel[i].SubdivisionID, Fields[i][Peoples.SubdivisionID]);
            }

            Dictionary<string, object> Line = new Dictionary<string, object>
            {
                { Peoples.Name, "ФИО" },
            };

            Assert.IsTrue(Peoples.Update(TestData.Editor, Peoples.TableName, Line, $"{Peoples.ID} < 2"));

            Sel = Peoples.Select(TestData.Editor, Peoples.TableName, $"{Peoples.ID} < 2");
            Assert.AreEqual(Sel.Count, 2);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].Name, Line[Peoples.Name]);
            }

            Assert.IsTrue(Peoples.Delete(TestData.Editor, Peoples.TableName));

            DynamicTest(new Peoples(), Fields);

            Ranks.Delete(TestData.Editor, Ranks.TableName);
            Subdivisions.Delete(TestData.Editor, Subdivisions.TableName);
        }
    
    }
}
