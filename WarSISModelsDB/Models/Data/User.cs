using System;

namespace WarSISModelsDB.Models.Data
{
    public class User : AData<User>
    {
        public Int32 ID { get; set; }
        public String Login { get; set; }
        public String Password { get; set; }
        public Int32 People { get; set; }
        public Int32 Role { get; set; }

        public override User GetElement(object[] Data) =>
            new User()
            {
                ID = Data[0].ToInt32(),
                Login = Data[1].ToString(),
                Password = Data[2].ToString(),
                People = Data[3].ToInt32(),
                Role = Data[4].ToInt32(),
            };
    }
}
