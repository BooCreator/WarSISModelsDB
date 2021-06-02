using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;

using WarSISModelsDB;
using WarSISModelsDB.Models;
using WarSISModelsDB.Models.Data;
using WarSISModelsDB.Models.DataBase;
using WarSISModelsDB.Models.DataBase.Property;

namespace WarSISModelsDBTests
{
    [TestClass]
    public class PropertiesTest
    {
        private void DynamicTest<T>(ADataBase<T> Item, List<Dictionary<string, object>> Fields) where T : class
        {
            Item.Editor = TestData.Editor;
            Assert.IsTrue(Item.Delete());

            foreach(var Field in Fields)
                Assert.IsTrue(Item.Insert(Field));

            Assert.AreEqual(Item.Count(), Fields.Count);

            List<T> Sel = Item.Select();
            Assert.AreEqual(Sel.Count, Fields.Count);

            Assert.IsTrue(Item.Delete());
        }

        [TestMethod]
        public void ArtilleryTest()
        {
            Assert.IsTrue(Artilleries.Delete(TestData.Editor, Artilleries.TableName));

            List<Dictionary<string, object>> Fields = new List<Dictionary<string, object>>() {
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

            foreach (var Field in Fields)
                Assert.IsTrue(Artilleries.Insert(TestData.Editor, Artilleries.TableName, Field));

            Assert.AreEqual(Artilleries.Count(TestData.Editor, Artilleries.TableName), Fields.Count);
            Assert.AreEqual(Artilleries.Count(TestData.Editor, Artilleries.TableName, $"{Artilleries.ID} = {1}"), 1);

            var Sel = Artilleries.Select(TestData.Editor, Artilleries.TableName);
            Assert.AreEqual(Sel.Count, Fields.Count);

            for(int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].ID, Fields[i][Artilleries.ID]);
                Assert.AreEqual(Sel[i].Title, Fields[i][Artilleries.Title]);
                Assert.AreEqual(Sel[i].Inventary, Fields[i][Artilleries.Inventary]);
            }

            Dictionary<string, object> Line = new Dictionary<string, object>
            {
                {  Artilleries.Title, "ЗсС-1" }
            };

            Assert.IsTrue(Artilleries.Update(TestData.Editor, Artilleries.TableName, Line, $"{Artilleries.ID} < 2"));

            Sel = Artilleries.Select(TestData.Editor, Artilleries.TableName, $"{Artilleries.ID} < 2");
            Assert.AreEqual(Sel.Count, 2);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].Title, Line[Artilleries.Title]);
            }

            Assert.IsTrue(Artilleries.Delete(TestData.Editor, Artilleries.TableName));

            DynamicTest(new Artilleries(), Fields);

        }
        [TestMethod]
        public void AuthomatsTest()
        {
            Assert.IsTrue(Authomats.Delete(TestData.Editor, Authomats.TableName));

            List<Dictionary<string, object>> Fields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Authomats.ID, 0 },
                    { Authomats.Title, "ЗиС-1" },
                    { Authomats.Inventary, 12345678 }
                },
                new Dictionary<string, object>
                {
                    { Authomats.ID, 1 },
                    { Authomats.Title, "ЗиС-2" },
                    { Authomats.Inventary, 87654321 }
                },
                new Dictionary<string, object>
                {
                    { Authomats.ID, 2 },
                    { Authomats.Title, "ЗиС-3" },
                    { Authomats.Inventary, 87656781 }
                }
            };

            foreach (var Field in Fields)
                Assert.IsTrue(Authomats.Insert(TestData.Editor, Authomats.TableName, Field));

            Assert.AreEqual(Authomats.Count(TestData.Editor, Authomats.TableName), Fields.Count);
            Assert.AreEqual(Authomats.Count(TestData.Editor, Authomats.TableName, $"{Authomats.ID} = {1}"), 1);

            var Sel = Authomats.Select(TestData.Editor, Authomats.TableName);
            Assert.AreEqual(Sel.Count, Fields.Count);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].ID, Fields[i][Authomats.ID]);
                Assert.AreEqual(Sel[i].Title, Fields[i][Authomats.Title]);
                Assert.AreEqual(Sel[i].Inventary, Fields[i][Authomats.Inventary]);
            }

            Dictionary<string, object> Line = new Dictionary<string, object>
            {
                {  Authomats.Title, "ЗсС-1" }
            };

            Assert.IsTrue(Authomats.Update(TestData.Editor, Authomats.TableName, Line, $"{Authomats.ID} < 2"));

            Sel = Authomats.Select(TestData.Editor, Authomats.TableName, $"{Authomats.ID} < 2");
            Assert.AreEqual(Sel.Count, 2);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].Title, Line[Authomats.Title]);
            }

            Assert.IsTrue(Authomats.Delete(TestData.Editor, Authomats.TableName));

            DynamicTest(new Authomats(), Fields);
        }
        [TestMethod]
        public void AutomobilsTest()
        {
            Assert.IsTrue(Automobils.Delete(TestData.Editor, Automobils.TableName));

            List<Dictionary<string, object>> Fields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Automobils.ID, 0 },
                    { Automobils.Title, "ЗиС-1" },
                    { Automobils.Inventary, 12345678 }
                },
                new Dictionary<string, object>
                {
                    { Automobils.ID, 1 },
                    { Automobils.Title, "ЗиС-2" },
                    { Automobils.Inventary, 87654321 }
                },
                new Dictionary<string, object>
                {
                    { Automobils.ID, 2 },
                    { Automobils.Title, "ЗиС-3" },
                    { Automobils.Inventary, 87656781 }
                }
            };

            foreach (var Field in Fields)
                Assert.IsTrue(Automobils.Insert(TestData.Editor, Automobils.TableName, Field));

            Assert.AreEqual(Automobils.Count(TestData.Editor, Automobils.TableName), Fields.Count);
            Assert.AreEqual(Automobils.Count(TestData.Editor, Automobils.TableName, $"{Automobils.ID} = {1}"), 1);

            var Sel = Automobils.Select(TestData.Editor, Automobils.TableName);
            Assert.AreEqual(Sel.Count, Fields.Count);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].ID, Fields[i][Automobils.ID]);
                Assert.AreEqual(Sel[i].Title, Fields[i][Automobils.Title]);
                Assert.AreEqual(Sel[i].Inventary, Fields[i][Automobils.Inventary]);
            }

            Dictionary<string, object> Line = new Dictionary<string, object>
            {
                {  Automobils.Title, "ЗсС-1" }
            };

            Assert.IsTrue(Automobils.Update(TestData.Editor, Automobils.TableName, Line, $"{Automobils.ID} < 2"));

            Sel = Automobils.Select(TestData.Editor, Automobils.TableName, $"{Automobils.ID} < 2");
            Assert.AreEqual(Sel.Count, 2);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].Title, Line[Automobils.Title]);
            }

            Assert.IsTrue(Automobils.Delete(TestData.Editor, Automobils.TableName));

            DynamicTest(new Automobils(), Fields);
        }
        [TestMethod]
        public void BMPsTest()
        {
            Assert.IsTrue(BMPs.Delete(TestData.Editor, BMPs.TableName));

            List<Dictionary<string, object>> Fields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { BMPs.ID, 0 },
                    { BMPs.Title, "ЗиС-1" },
                    { BMPs.Inventary, 12345678 }
                },
                new Dictionary<string, object>
                {
                    { BMPs.ID, 1 },
                    { BMPs.Title, "ЗиС-2" },
                    { BMPs.Inventary, 87654321 }
                },
                new Dictionary<string, object>
                {
                    { BMPs.ID, 2 },
                    { BMPs.Title, "ЗиС-3" },
                    { BMPs.Inventary, 87656781 }
                }
            };

            foreach (var Field in Fields)
                Assert.IsTrue(BMPs.Insert(TestData.Editor, BMPs.TableName, Field));

            Assert.AreEqual(BMPs.Count(TestData.Editor, BMPs.TableName), Fields.Count);
            Assert.AreEqual(BMPs.Count(TestData.Editor, BMPs.TableName, $"{BMPs.ID} = {1}"), 1);

            var Sel = BMPs.Select(TestData.Editor, BMPs.TableName);
            Assert.AreEqual(Sel.Count, Fields.Count);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].ID, Fields[i][BMPs.ID]);
                Assert.AreEqual(Sel[i].Title, Fields[i][BMPs.Title]);
                Assert.AreEqual(Sel[i].Inventary, Fields[i][BMPs.Inventary]);
            }

            Dictionary<string, object> Line = new Dictionary<string, object>
            {
                {  BMPs.Title, "ЗсС-1" }
            };

            Assert.IsTrue(BMPs.Update(TestData.Editor, BMPs.TableName, Line, $"{BMPs.ID} < 2"));

            Sel = BMPs.Select(TestData.Editor, BMPs.TableName, $"{BMPs.ID} < 2");
            Assert.AreEqual(Sel.Count, 2);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].Title, Line[BMPs.Title]);
            }

            Assert.IsTrue(BMPs.Delete(TestData.Editor, BMPs.TableName));

            DynamicTest(new BMPs(), Fields);
        }
        [TestMethod]
        public void CarabinsTest()
        {
            Assert.IsTrue(Carabins.Delete(TestData.Editor, Carabins.TableName));

            List<Dictionary<string, object>> Fields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Carabins.ID, 0 },
                    { Carabins.Title, "ЗиС-1" },
                    { Carabins.Inventary, 12345678 }
                },
                new Dictionary<string, object>
                {
                    { Carabins.ID, 1 },
                    { Carabins.Title, "ЗиС-2" },
                    { Carabins.Inventary, 87654321 }
                },
                new Dictionary<string, object>
                {
                    { Carabins.ID, 2 },
                    { Carabins.Title, "ЗиС-3" },
                    { Carabins.Inventary, 87656781 }
                }
            };

            foreach (var Field in Fields)
                Assert.IsTrue(Carabins.Insert(TestData.Editor, Carabins.TableName, Field));

            Assert.AreEqual(Carabins.Count(TestData.Editor, Carabins.TableName), Fields.Count);
            Assert.AreEqual(Carabins.Count(TestData.Editor, Carabins.TableName, $"{Carabins.ID} = {1}"), 1);

            var Sel = Carabins.Select(TestData.Editor, Carabins.TableName);
            Assert.AreEqual(Sel.Count, Fields.Count);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].ID, Fields[i][Carabins.ID]);
                Assert.AreEqual(Sel[i].Title, Fields[i][Carabins.Title]);
                Assert.AreEqual(Sel[i].Inventary, Fields[i][Carabins.Inventary]);
            }

            Dictionary<string, object> Line = new Dictionary<string, object>
            {
                {  Carabins.Title, "ЗсС-1" }
            };

            Assert.IsTrue(Carabins.Update(TestData.Editor, Carabins.TableName, Line, $"{Carabins.ID} < 2"));

            Sel = Carabins.Select(TestData.Editor, Carabins.TableName, $"{Carabins.ID} < 2");
            Assert.AreEqual(Sel.Count, 2);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].Title, Line[Carabins.Title]);
            }

            Assert.IsTrue(Carabins.Delete(TestData.Editor, Carabins.TableName));

            DynamicTest(new Carabins(), Fields);
        }
        [TestMethod]
        public void RocketAmmosTest()
        {
            Assert.IsTrue(RocketAmmos.Delete(TestData.Editor, RocketAmmos.TableName));

            List<Dictionary<string, object>> Fields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { RocketAmmos.ID, 0 },
                    { RocketAmmos.Title, "ЗиС-1" },
                    { RocketAmmos.Inventary, 12345678 }
                },
                new Dictionary<string, object>
                {
                    { RocketAmmos.ID, 1 },
                    { RocketAmmos.Title, "ЗиС-2" },
                    { RocketAmmos.Inventary, 87654321 }
                },
                new Dictionary<string, object>
                {
                    { RocketAmmos.ID, 2 },
                    { RocketAmmos.Title, "ЗиС-3" },
                    { RocketAmmos.Inventary, 87656781 }
                }
            };

            foreach (var Field in Fields)
                Assert.IsTrue(RocketAmmos.Insert(TestData.Editor, RocketAmmos.TableName, Field));

            Assert.AreEqual(RocketAmmos.Count(TestData.Editor, RocketAmmos.TableName), Fields.Count);
            Assert.AreEqual(RocketAmmos.Count(TestData.Editor, RocketAmmos.TableName, $"{RocketAmmos.ID} = {1}"), 1);

            var Sel = RocketAmmos.Select(TestData.Editor, RocketAmmos.TableName);
            Assert.AreEqual(Sel.Count, Fields.Count);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].ID, Fields[i][RocketAmmos.ID]);
                Assert.AreEqual(Sel[i].Title, Fields[i][RocketAmmos.Title]);
                Assert.AreEqual(Sel[i].Inventary, Fields[i][RocketAmmos.Inventary]);
            }

            Dictionary<string, object> Line = new Dictionary<string, object>
            {
                {  RocketAmmos.Title, "ЗсС-1" }
            };

            Assert.IsTrue(RocketAmmos.Update(TestData.Editor, RocketAmmos.TableName, Line, $"{RocketAmmos.ID} < 2"));

            Sel = RocketAmmos.Select(TestData.Editor, RocketAmmos.TableName, $"{RocketAmmos.ID} < 2");
            Assert.AreEqual(Sel.Count, 2);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].Title, Line[RocketAmmos.Title]);
            }

            Assert.IsTrue(RocketAmmos.Delete(TestData.Editor, RocketAmmos.TableName));

            DynamicTest(new RocketAmmos(), Fields);
        }
        [TestMethod]
        public void TractorsTest()
        {
            Assert.IsTrue(Tractors.Delete(TestData.Editor, Tractors.TableName));

            List<Dictionary<string, object>> Fields = new List<Dictionary<string, object>>() {
                new Dictionary<string, object>
                {
                    { Tractors.ID, 0 },
                    { Tractors.Title, "ЗиС-1" },
                    { Tractors.Inventary, 12345678 }
                },
                new Dictionary<string, object>
                {
                    { Tractors.ID, 1 },
                    { Tractors.Title, "ЗиС-2" },
                    { Tractors.Inventary, 87654321 }
                },
                new Dictionary<string, object>
                {
                    { Tractors.ID, 2 },
                    { Tractors.Title, "ЗиС-3" },
                    { Tractors.Inventary, 87656781 }
                }
            };

            foreach (var Field in Fields)
                Assert.IsTrue(Tractors.Insert(TestData.Editor, Tractors.TableName, Field));

            Assert.AreEqual(Tractors.Count(TestData.Editor, Tractors.TableName), Fields.Count);
            Assert.AreEqual(Tractors.Count(TestData.Editor, Tractors.TableName, $"{Tractors.ID} = {1}"), 1);

            var Sel = Tractors.Select(TestData.Editor, Tractors.TableName);
            Assert.AreEqual(Sel.Count, Fields.Count);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].ID, Fields[i][Tractors.ID]);
                Assert.AreEqual(Sel[i].Title, Fields[i][Tractors.Title]);
                Assert.AreEqual(Sel[i].Inventary, Fields[i][Tractors.Inventary]);
            }

            Dictionary<string, object> Line = new Dictionary<string, object>
            {
                {  Tractors.Title, "ЗсС-1" }
            };

            Assert.IsTrue(Tractors.Update(TestData.Editor, Tractors.TableName, Line, $"{Tractors.ID} < 2"));

            Sel = Tractors.Select(TestData.Editor, Tractors.TableName, $"{Tractors.ID} < 2");
            Assert.AreEqual(Sel.Count, 2);

            for (int i = 0; i < Sel.Count; i++)
            {
                Assert.AreEqual(Sel[i].Title, Line[Tractors.Title]);
            }

            Assert.IsTrue(Tractors.Delete(TestData.Editor, Tractors.TableName));

            DynamicTest(new Tractors(), Fields);
        }

    }
}
