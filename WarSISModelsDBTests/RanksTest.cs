using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;

using WarSISModelsDB;
using WarSISModelsDB.Models;
using WarSISModelsDB.Models.Data;
using WarSISModelsDB.Models.DataBase;
using WarSISModelsDB.Models.DataBase.Rank;

namespace WarSISModelsDBTests
{
    [TestClass]
    public class RanksTest
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
        public void CaptainsTest()
        {
            Assert.IsTrue(Captains.Delete(TestData.Editor, Captains.TableName));

            List<Dictionary<string, object>> PeopleFields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Peoples.ID, 0 },
                    { Peoples.Name, "ФИО 1" },
                },
                new Dictionary<string, object>
                {
                    { Peoples.ID, 1 },
                    { Peoples.Name, "ФИО 1" },
                },
                new Dictionary<string, object>
                {
                    { Peoples.ID, 2 },
                    { Peoples.Name, "ФИО 1" },
                }
            };
            Assert.IsTrue(Peoples.Delete(TestData.Editor, Peoples.TableName));
            foreach (var Field in PeopleFields)
                Assert.IsTrue(Peoples.Insert(TestData.Editor, Peoples.TableName, Field));

            List<Dictionary<string, object>> Fields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Captains.People, 0 },
                },
                new Dictionary<string, object>
                {
                    { Captains.People, 1 },
                },
                new Dictionary<string, object>
                {
                    { Captains.People, 2 },
                }
            };

            foreach (var Field in Fields)
                Assert.IsTrue(Captains.Insert(TestData.Editor, Captains.TableName, Field));

            Assert.AreEqual(Captains.Count(TestData.Editor, Captains.TableName), Fields.Count);
            Assert.AreEqual(Captains.Count(TestData.Editor, Captains.TableName, $"{Captains.People} = {1}"), 1);

            var Sel = Captains.Select(TestData.Editor, Captains.TableName);
            Assert.AreEqual(Sel.Count, Fields.Count);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].People, Fields[i][Captains.People]);
            }

            Dictionary<string, object> Line = new Dictionary<string, object>
            {
                {  Captains.People, 3 }
            };

            //Assert.IsTrue(Captains.Update(TestData.Editor, Captains.TableName, Line, $"{Captains.People} < 2"));

            //Sel = Captains.Select(TestData.Editor, Captains.TableName, $"{Captains.People} < 2");
            //Assert.AreEqual(Sel.Count, 2);

            for (int i = 0; i < Sel.Count; i++)
            {
                //Assert.AreEqual(Sel[i].People, Line[Captains.People]);
            }

            Assert.IsTrue(Captains.Delete(TestData.Editor, Captains.TableName));

            DynamicTest(new Captains(), Fields);

            Assert.IsTrue(Peoples.Delete(TestData.Editor, Peoples.TableName));

        }
        [TestMethod]
        public void ColonelsTest()
        {
            Assert.IsTrue(Colonels.Delete(TestData.Editor, Colonels.TableName));

            List<Dictionary<string, object>> PeopleFields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Peoples.ID, 0 },
                    { Peoples.Name, "ФИО 1" },
                },
                new Dictionary<string, object>
                {
                    { Peoples.ID, 1 },
                    { Peoples.Name, "ФИО 1" },
                },
                new Dictionary<string, object>
                {
                    { Peoples.ID, 2 },
                    { Peoples.Name, "ФИО 1" },
                }
            };
            Assert.IsTrue(Peoples.Delete(TestData.Editor, Peoples.TableName));
            foreach (var Field in PeopleFields)
                Assert.IsTrue(Peoples.Insert(TestData.Editor, Peoples.TableName, Field));

            List<Dictionary<string, object>> Fields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Colonels.People, 0 },
                },
                new Dictionary<string, object>
                {
                    { Colonels.People, 1 },
                },
                new Dictionary<string, object>
                {
                    { Colonels.People, 2 },
                }
            };

            foreach (var Field in Fields)
                Assert.IsTrue(Colonels.Insert(TestData.Editor, Colonels.TableName, Field));

            Assert.AreEqual(Colonels.Count(TestData.Editor, Colonels.TableName), Fields.Count);
            Assert.AreEqual(Colonels.Count(TestData.Editor, Colonels.TableName, $"{Colonels.People} = {1}"), 1);

            var Sel = Colonels.Select(TestData.Editor, Colonels.TableName);
            Assert.AreEqual(Sel.Count, Fields.Count);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].People, Fields[i][Colonels.People]);
            }

            Dictionary<string, object> Line = new Dictionary<string, object>
            {
                {  Colonels.People, 3 }
            };

            //Assert.IsTrue(Colonels.Update(TestData.Editor, Colonels.TableName, Line, $"{Colonels.People} < 2"));

            //Sel = Colonels.Select(TestData.Editor, Colonels.TableName, $"{Colonels.People} < 2");
            //Assert.AreEqual(Sel.Count, 2);

            for (int i = 0; i < Sel.Count; i++)
            {
                //Assert.AreEqual(Sel[i].People, Line[Colonels.People]);
            }

            Assert.IsTrue(Colonels.Delete(TestData.Editor, Colonels.TableName));

            DynamicTest(new Colonels(), Fields);

            Assert.IsTrue(Peoples.Delete(TestData.Editor, Peoples.TableName));
        }
        [TestMethod]
        public void CorporalsTest()
        {
            Assert.IsTrue(Corporals.Delete(TestData.Editor, Corporals.TableName));

            List<Dictionary<string, object>> PeopleFields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Peoples.ID, 0 },
                    { Peoples.Name, "ФИО 1" },
                },
                new Dictionary<string, object>
                {
                    { Peoples.ID, 1 },
                    { Peoples.Name, "ФИО 1" },
                },
                new Dictionary<string, object>
                {
                    { Peoples.ID, 2 },
                    { Peoples.Name, "ФИО 1" },
                }
            };
            Assert.IsTrue(Peoples.Delete(TestData.Editor, Peoples.TableName));
            foreach (var Field in PeopleFields)
                Assert.IsTrue(Peoples.Insert(TestData.Editor, Peoples.TableName, Field));

            List<Dictionary<string, object>> Fields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Corporals.People, 0 },
                },
                new Dictionary<string, object>
                {
                    { Corporals.People, 1 },
                },
                new Dictionary<string, object>
                {
                    { Corporals.People, 2 },
                }
            };

            foreach (var Field in Fields)
                Assert.IsTrue(Corporals.Insert(TestData.Editor, Corporals.TableName, Field));

            Assert.AreEqual(Corporals.Count(TestData.Editor, Corporals.TableName), Fields.Count);
            Assert.AreEqual(Corporals.Count(TestData.Editor, Corporals.TableName, $"{Corporals.People} = {1}"), 1);

            var Sel = Corporals.Select(TestData.Editor, Corporals.TableName);
            Assert.AreEqual(Sel.Count, Fields.Count);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].People, Fields[i][Corporals.People]);
            }

            Dictionary<string, object> Line = new Dictionary<string, object>
            {
                {  Corporals.People, 3 }
            };

            //Assert.IsTrue(Corporals.Update(TestData.Editor, Corporals.TableName, Line, $"{Corporals.People} < 2"));

            //Sel = Corporals.Select(TestData.Editor, Corporals.TableName, $"{Corporals.People} < 2");
            //Assert.AreEqual(Sel.Count, 2);

            for (int i = 0; i < Sel.Count; i++)
            {
                //Assert.AreEqual(Sel[i].People, Line[Corporals.People]);
            }

            Assert.IsTrue(Corporals.Delete(TestData.Editor, Corporals.TableName));

            DynamicTest(new Corporals(), Fields);

            Assert.IsTrue(Peoples.Delete(TestData.Editor, Peoples.TableName));
        }
        [TestMethod]
        public void EnsignsTest()
        {
            Assert.IsTrue(Ensigns.Delete(TestData.Editor, Ensigns.TableName));

            List<Dictionary<string, object>> PeopleFields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Peoples.ID, 0 },
                    { Peoples.Name, "ФИО 1" },
                },
                new Dictionary<string, object>
                {
                    { Peoples.ID, 1 },
                    { Peoples.Name, "ФИО 1" },
                },
                new Dictionary<string, object>
                {
                    { Peoples.ID, 2 },
                    { Peoples.Name, "ФИО 1" },
                }
            };
            Assert.IsTrue(Peoples.Delete(TestData.Editor, Peoples.TableName));
            foreach (var Field in PeopleFields)
                Assert.IsTrue(Peoples.Insert(TestData.Editor, Peoples.TableName, Field));

            List<Dictionary<string, object>> Fields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Ensigns.People, 0 },
                },
                new Dictionary<string, object>
                {
                    { Ensigns.People, 1 },
                },
                new Dictionary<string, object>
                {
                    { Ensigns.People, 2 },
                }
            };

            foreach (var Field in Fields)
                Assert.IsTrue(Ensigns.Insert(TestData.Editor, Ensigns.TableName, Field));

            Assert.AreEqual(Ensigns.Count(TestData.Editor, Ensigns.TableName), Fields.Count);
            Assert.AreEqual(Ensigns.Count(TestData.Editor, Ensigns.TableName, $"{Ensigns.People} = {1}"), 1);

            var Sel = Ensigns.Select(TestData.Editor, Ensigns.TableName);
            Assert.AreEqual(Sel.Count, Fields.Count);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].People, Fields[i][Ensigns.People]);
            }

            Dictionary<string, object> Line = new Dictionary<string, object>
            {
                {  Ensigns.People, 3 }
            };

            //Assert.IsTrue(Ensigns.Update(TestData.Editor, Ensigns.TableName, Line, $"{Ensigns.People} < 2"));

            //Sel = Ensigns.Select(TestData.Editor, Ensigns.TableName, $"{Ensigns.People} < 2");
            //Assert.AreEqual(Sel.Count, 2);

            for (int i = 0; i < Sel.Count; i++)
            {
                //Assert.AreEqual(Sel[i].People, Line[Ensigns.People]);
            }

            Assert.IsTrue(Ensigns.Delete(TestData.Editor, Ensigns.TableName));

            DynamicTest(new Ensigns(), Fields);

            Assert.IsTrue(Peoples.Delete(TestData.Editor, Peoples.TableName));
        }
        [TestMethod]
        public void GeneralsTest()
        {
            Assert.IsTrue(Generals.Delete(TestData.Editor, Generals.TableName));

            List<Dictionary<string, object>> PeopleFields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Peoples.ID, 0 },
                    { Peoples.Name, "ФИО 1" },
                },
                new Dictionary<string, object>
                {
                    { Peoples.ID, 1 },
                    { Peoples.Name, "ФИО 1" },
                },
                new Dictionary<string, object>
                {
                    { Peoples.ID, 2 },
                    { Peoples.Name, "ФИО 1" },
                }
            };
            Assert.IsTrue(Peoples.Delete(TestData.Editor, Peoples.TableName));
            foreach (var Field in PeopleFields)
                Assert.IsTrue(Peoples.Insert(TestData.Editor, Peoples.TableName, Field));

            List<Dictionary<string, object>> Fields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Generals.People, 0 },
                },
                new Dictionary<string, object>
                {
                    { Generals.People, 1 },
                },
                new Dictionary<string, object>
                {
                    { Generals.People, 2 },
                }
            };

            foreach (var Field in Fields)
                Assert.IsTrue(Generals.Insert(TestData.Editor, Generals.TableName, Field));

            Assert.AreEqual(Generals.Count(TestData.Editor, Generals.TableName), Fields.Count);
            Assert.AreEqual(Generals.Count(TestData.Editor, Generals.TableName, $"{Generals.People} = {1}"), 1);

            var Sel = Generals.Select(TestData.Editor, Generals.TableName);
            Assert.AreEqual(Sel.Count, Fields.Count);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].People, Fields[i][Generals.People]);
            }

            Dictionary<string, object> Line = new Dictionary<string, object>
            {
                {  Generals.People, 3 }
            };

            //Assert.IsTrue(Generals.Update(TestData.Editor, Generals.TableName, Line, $"{Generals.People} < 2"));

            //Sel = Generals.Select(TestData.Editor, Generals.TableName, $"{Generals.People} < 2");
            //Assert.AreEqual(Sel.Count, 2);

            for (int i = 0; i < Sel.Count; i++)
            {
                //Assert.AreEqual(Sel[i].People, Line[Generals.People]);
            }

            Assert.IsTrue(Generals.Delete(TestData.Editor, Generals.TableName));

            DynamicTest(new Generals(), Fields);

            Assert.IsTrue(Peoples.Delete(TestData.Editor, Peoples.TableName));
        }
        [TestMethod]
        public void LieutenantsTest()
        {
            Assert.IsTrue(Lieutenants.Delete(TestData.Editor, Lieutenants.TableName));

            List<Dictionary<string, object>> PeopleFields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Peoples.ID, 0 },
                    { Peoples.Name, "ФИО 1" },
                },
                new Dictionary<string, object>
                {
                    { Peoples.ID, 1 },
                    { Peoples.Name, "ФИО 1" },
                },
                new Dictionary<string, object>
                {
                    { Peoples.ID, 2 },
                    { Peoples.Name, "ФИО 1" },
                }
            };
            Assert.IsTrue(Peoples.Delete(TestData.Editor, Peoples.TableName));
            foreach (var Field in PeopleFields)
                Assert.IsTrue(Peoples.Insert(TestData.Editor, Peoples.TableName, Field));

            List<Dictionary<string, object>> Fields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Lieutenants.People, 0 },
                },
                new Dictionary<string, object>
                {
                    { Lieutenants.People, 1 },
                },
                new Dictionary<string, object>
                {
                    { Lieutenants.People, 2 },
                }
            };

            foreach (var Field in Fields)
                Assert.IsTrue(Lieutenants.Insert(TestData.Editor, Lieutenants.TableName, Field));

            Assert.AreEqual(Lieutenants.Count(TestData.Editor, Lieutenants.TableName), Fields.Count);
            Assert.AreEqual(Lieutenants.Count(TestData.Editor, Lieutenants.TableName, $"{Lieutenants.People} = {1}"), 1);

            var Sel = Lieutenants.Select(TestData.Editor, Lieutenants.TableName);
            Assert.AreEqual(Sel.Count, Fields.Count);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].People, Fields[i][Lieutenants.People]);
            }

            Dictionary<string, object> Line = new Dictionary<string, object>
            {
                {  Lieutenants.People, 3 }
            };

            //Assert.IsTrue(Lieutenants.Update(TestData.Editor, Lieutenants.TableName, Line, $"{Lieutenants.People} < 2"));

            //Sel = Lieutenants.Select(TestData.Editor, Lieutenants.TableName, $"{Lieutenants.People} < 2");
            //Assert.AreEqual(Sel.Count, 2);

            for (int i = 0; i < Sel.Count; i++)
            {
                //Assert.AreEqual(Sel[i].People, Line[Lieutenants.People]);
            }

            Assert.IsTrue(Lieutenants.Delete(TestData.Editor, Lieutenants.TableName));

            DynamicTest(new Lieutenants(), Fields);

            Assert.IsTrue(Peoples.Delete(TestData.Editor, Peoples.TableName));
        }
        [TestMethod]
        public void LtColonelsTest()
        {
            Assert.IsTrue(LtColonels.Delete(TestData.Editor, LtColonels.TableName));

            List<Dictionary<string, object>> PeopleFields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Peoples.ID, 0 },
                    { Peoples.Name, "ФИО 1" },
                },
                new Dictionary<string, object>
                {
                    { Peoples.ID, 1 },
                    { Peoples.Name, "ФИО 1" },
                },
                new Dictionary<string, object>
                {
                    { Peoples.ID, 2 },
                    { Peoples.Name, "ФИО 1" },
                }
            };
            Assert.IsTrue(Peoples.Delete(TestData.Editor, Peoples.TableName));
            foreach (var Field in PeopleFields)
                Assert.IsTrue(Peoples.Insert(TestData.Editor, Peoples.TableName, Field));

            List<Dictionary<string, object>> Fields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { LtColonels.People, 0 },
                },
                new Dictionary<string, object>
                {
                    { LtColonels.People, 1 },
                },
                new Dictionary<string, object>
                {
                    { LtColonels.People, 2 },
                }
            };

            foreach (var Field in Fields)
                Assert.IsTrue(LtColonels.Insert(TestData.Editor, LtColonels.TableName, Field));

            Assert.AreEqual(LtColonels.Count(TestData.Editor, LtColonels.TableName), Fields.Count);
            Assert.AreEqual(LtColonels.Count(TestData.Editor, LtColonels.TableName, $"{LtColonels.People} = {1}"), 1);

            var Sel = LtColonels.Select(TestData.Editor, LtColonels.TableName);
            Assert.AreEqual(Sel.Count, Fields.Count);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].People, Fields[i][LtColonels.People]);
            }

            Dictionary<string, object> Line = new Dictionary<string, object>
            {
                {  LtColonels.People, 3 }
            };

            //Assert.IsTrue(LtColonels.Update(TestData.Editor, LtColonels.TableName, Line, $"{LtColonels.People} < 2"));

            //Sel = LtColonels.Select(TestData.Editor, LtColonels.TableName, $"{LtColonels.People} < 2");
            //Assert.AreEqual(Sel.Count, 2);

            for (int i = 0; i < Sel.Count; i++)
            {
                //Assert.AreEqual(Sel[i].People, Line[LtColonels.People]);
            }

            Assert.IsTrue(LtColonels.Delete(TestData.Editor, LtColonels.TableName));

            DynamicTest(new LtColonels(), Fields);

            Assert.IsTrue(Peoples.Delete(TestData.Editor, Peoples.TableName));
        }
        [TestMethod]
        public void MajorsTest()
        {
            Assert.IsTrue(Majors.Delete(TestData.Editor, Majors.TableName));

            List<Dictionary<string, object>> PeopleFields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Peoples.ID, 0 },
                    { Peoples.Name, "ФИО 1" },
                },
                new Dictionary<string, object>
                {
                    { Peoples.ID, 1 },
                    { Peoples.Name, "ФИО 1" },
                },
                new Dictionary<string, object>
                {
                    { Peoples.ID, 2 },
                    { Peoples.Name, "ФИО 1" },
                }
            };
            Assert.IsTrue(Peoples.Delete(TestData.Editor, Peoples.TableName));
            foreach (var Field in PeopleFields)
                Assert.IsTrue(Peoples.Insert(TestData.Editor, Peoples.TableName, Field));

            List<Dictionary<string, object>> Fields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Majors.People, 0 },
                },
                new Dictionary<string, object>
                {
                    { Majors.People, 1 },
                },
                new Dictionary<string, object>
                {
                    { Majors.People, 2 },
                }
            };

            foreach (var Field in Fields)
                Assert.IsTrue(Majors.Insert(TestData.Editor, Majors.TableName, Field));

            Assert.AreEqual(Majors.Count(TestData.Editor, Majors.TableName), Fields.Count);
            Assert.AreEqual(Majors.Count(TestData.Editor, Majors.TableName, $"{Majors.People} = {1}"), 1);

            var Sel = Majors.Select(TestData.Editor, Majors.TableName);
            Assert.AreEqual(Sel.Count, Fields.Count);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].People, Fields[i][Majors.People]);
            }

            Dictionary<string, object> Line = new Dictionary<string, object>
            {
                {  Majors.People, 3 }
            };

            //Assert.IsTrue(Majors.Update(TestData.Editor, Majors.TableName, Line, $"{Majors.People} < 2"));

            //Sel = Majors.Select(TestData.Editor, Majors.TableName, $"{Majors.People} < 2");
            //Assert.AreEqual(Sel.Count, 2);

            for (int i = 0; i < Sel.Count; i++)
            {
                //Assert.AreEqual(Sel[i].People, Line[Majors.People]);
            }

            Assert.IsTrue(Majors.Delete(TestData.Editor, Majors.TableName));

            DynamicTest(new Majors(), Fields);

            Assert.IsTrue(Peoples.Delete(TestData.Editor, Peoples.TableName));
        }
        [TestMethod]
        public void SergeantsTest()
        {
            Assert.IsTrue(Sergeants.Delete(TestData.Editor, Sergeants.TableName));

            List<Dictionary<string, object>> PeopleFields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Peoples.ID, 0 },
                    { Peoples.Name, "ФИО 1" },
                },
                new Dictionary<string, object>
                {
                    { Peoples.ID, 1 },
                    { Peoples.Name, "ФИО 1" },
                },
                new Dictionary<string, object>
                {
                    { Peoples.ID, 2 },
                    { Peoples.Name, "ФИО 1" },
                }
            };
            Assert.IsTrue(Peoples.Delete(TestData.Editor, Peoples.TableName));
            foreach (var Field in PeopleFields)
                Assert.IsTrue(Peoples.Insert(TestData.Editor, Peoples.TableName, Field));

            List<Dictionary<string, object>> Fields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Sergeants.People, 0 },
                },
                new Dictionary<string, object>
                {
                    { Sergeants.People, 1 },
                },
                new Dictionary<string, object>
                {
                    { Sergeants.People, 2 },
                }
            };

            foreach (var Field in Fields)
                Assert.IsTrue(Sergeants.Insert(TestData.Editor, Sergeants.TableName, Field));

            Assert.AreEqual(Sergeants.Count(TestData.Editor, Sergeants.TableName), Fields.Count);
            Assert.AreEqual(Sergeants.Count(TestData.Editor, Sergeants.TableName, $"{Sergeants.People} = {1}"), 1);

            var Sel = Sergeants.Select(TestData.Editor, Sergeants.TableName);
            Assert.AreEqual(Sel.Count, Fields.Count);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].People, Fields[i][Sergeants.People]);
            }

            Dictionary<string, object> Line = new Dictionary<string, object>
            {
                {  Sergeants.People, 3 }
            };

            //Assert.IsTrue(Sergeants.Update(TestData.Editor, Sergeants.TableName, Line, $"{Sergeants.People} < 2"));

            //Sel = Sergeants.Select(TestData.Editor, Sergeants.TableName, $"{Sergeants.People} < 2");
            //Assert.AreEqual(Sel.Count, 2);

            for (int i = 0; i < Sel.Count; i++)
            {
                //Assert.AreEqual(Sel[i].People, Line[Sergeants.People]);
            }

            Assert.IsTrue(Sergeants.Delete(TestData.Editor, Sergeants.TableName));

            DynamicTest(new Sergeants(), Fields);

            Assert.IsTrue(Peoples.Delete(TestData.Editor, Peoples.TableName));
        }
        [TestMethod]
        public void SgMajorsTest()
        {
            Assert.IsTrue(SgMajors.Delete(TestData.Editor, SgMajors.TableName));

            List<Dictionary<string, object>> PeopleFields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Peoples.ID, 0 },
                    { Peoples.Name, "ФИО 1" },
                },
                new Dictionary<string, object>
                {
                    { Peoples.ID, 1 },
                    { Peoples.Name, "ФИО 1" },
                },
                new Dictionary<string, object>
                {
                    { Peoples.ID, 2 },
                    { Peoples.Name, "ФИО 1" },
                }
            };
            Assert.IsTrue(Peoples.Delete(TestData.Editor, Peoples.TableName));
            foreach (var Field in PeopleFields)
                Assert.IsTrue(Peoples.Insert(TestData.Editor, Peoples.TableName, Field));

            List<Dictionary<string, object>> Fields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { SgMajors.People, 0 },
                },
                new Dictionary<string, object>
                {
                    { SgMajors.People, 1 },
                },
                new Dictionary<string, object>
                {
                    { SgMajors.People, 2 },
                }
            };

            foreach (var Field in Fields)
                Assert.IsTrue(SgMajors.Insert(TestData.Editor, SgMajors.TableName, Field));

            Assert.AreEqual(SgMajors.Count(TestData.Editor, SgMajors.TableName), Fields.Count);
            Assert.AreEqual(SgMajors.Count(TestData.Editor, SgMajors.TableName, $"{SgMajors.People} = {1}"), 1);

            var Sel = SgMajors.Select(TestData.Editor, SgMajors.TableName);
            Assert.AreEqual(Sel.Count, Fields.Count);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].People, Fields[i][SgMajors.People]);
            }

            Dictionary<string, object> Line = new Dictionary<string, object>
            {
                {  SgMajors.People, 3 }
            };

            //Assert.IsTrue(SgMajors.Update(TestData.Editor, SgMajors.TableName, Line, $"{SgMajors.People} < 2"));

            //Sel = SgMajors.Select(TestData.Editor, SgMajors.TableName, $"{SgMajors.People} < 2");
            //Assert.AreEqual(Sel.Count, 2);

            for (int i = 0; i < Sel.Count; i++)
            {
                //Assert.AreEqual(Sel[i].People, Line[SgMajors.People]);
            }

            Assert.IsTrue(SgMajors.Delete(TestData.Editor, SgMajors.TableName));

            DynamicTest(new SgMajors(), Fields);

            Assert.IsTrue(Peoples.Delete(TestData.Editor, Peoples.TableName));
        }
        [TestMethod]
        public void SoldiersTest()
        {
            Assert.IsTrue(Soldiers.Delete(TestData.Editor, Soldiers.TableName));

            List<Dictionary<string, object>> PeopleFields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Peoples.ID, 0 },
                    { Peoples.Name, "ФИО 1" },
                },
                new Dictionary<string, object>
                {
                    { Peoples.ID, 1 },
                    { Peoples.Name, "ФИО 1" },
                },
                new Dictionary<string, object>
                {
                    { Peoples.ID, 2 },
                    { Peoples.Name, "ФИО 1" },
                }
            };
            Assert.IsTrue(Peoples.Delete(TestData.Editor, Peoples.TableName));
            foreach (var Field in PeopleFields)
                Assert.IsTrue(Peoples.Insert(TestData.Editor, Peoples.TableName, Field));

            List<Dictionary<string, object>> Fields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Soldiers.People, 0 },
                },
                new Dictionary<string, object>
                {
                    { Soldiers.People, 1 },
                },
                new Dictionary<string, object>
                {
                    { Soldiers.People, 2 },
                }
            };

            foreach (var Field in Fields)
                Assert.IsTrue(Soldiers.Insert(TestData.Editor, Soldiers.TableName, Field));

            Assert.AreEqual(Soldiers.Count(TestData.Editor, Soldiers.TableName), Fields.Count);
            Assert.AreEqual(Soldiers.Count(TestData.Editor, Soldiers.TableName, $"{Soldiers.People} = {1}"), 1);

            var Sel = Soldiers.Select(TestData.Editor, Soldiers.TableName);
            Assert.AreEqual(Sel.Count, Fields.Count);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].People, Fields[i][Soldiers.People]);
            }

            Dictionary<string, object> Line = new Dictionary<string, object>
            {
                {  Soldiers.People, 3 }
            };

            //Assert.IsTrue(Soldiers.Update(TestData.Editor, Soldiers.TableName, Line, $"{Soldiers.People} < 2"));

            //Sel = Soldiers.Select(TestData.Editor, Soldiers.TableName, $"{Soldiers.People} < 2");
            //Assert.AreEqual(Sel.Count, 2);

            for (int i = 0; i < Sel.Count; i++)
            {
                //Assert.AreEqual(Sel[i].People, Line[Soldiers.People]);
            }

            Assert.IsTrue(Soldiers.Delete(TestData.Editor, Soldiers.TableName));

            DynamicTest(new Soldiers(), Fields);

            Assert.IsTrue(Peoples.Delete(TestData.Editor, Peoples.TableName));
        }
    }
}
